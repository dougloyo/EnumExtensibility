using System;
using System.Linq;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using EnumExtensibility.Services;

namespace EnumExtensibility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Init container.
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel, true));
            // Install and register dependencies.
            container.Install(FromAssembly.This());

            // Resolve Controllers and call Get method.
            var controller0 = container.Resolve<Controller0>();
            controller0.Get(new Controller0.MetricCellTypeEnumRequest { Type = MetricTypeEnum.StatusLabel  });

            var controller1 = container.Resolve<Controller1>();
            controller1.Get(new MetricCellTypeRequest { Type = "Text" });

            var controller2 = new Controller2(new MyMetricTypeEnumeration());
            controller2.Get(new MetricCellTypeRequest { Type = "Other" });

            // Wait for a key press before exit.
            Console.WriteLine("Press Any Key to close");
            Console.ReadKey();
        }
    }

    public class Controller0
    {
        public class MetricCellTypeEnumRequest
        {
            public MetricTypeEnum Type { get; set; }
        }

        //private readonly SomeDependency service;

        //public Controller0(SomeDependency service)
        //{
        //    this.service = service;
        //}

        public void Get(MetricCellTypeEnumRequest request)
        {
            string model;

            // Not extensible code... 
            // We have to change the enum and this method...
            switch (request.Type)
            {
                case MetricTypeEnum.Text:
                    model = "Text";
                    break;
                case MetricTypeEnum.StatusLabel:
                    model = "StatusLabel";
                    break;
                case MetricTypeEnum.Other:
                    model = "Other";
                    break;
                default:
                    model = "Not supported";
                    break;
            }

            Console.WriteLine("Controller 0: " + model);
        }
    }

    public class Controller1
    {
        private readonly IMetricCellType[] metricCellTypes;

        public Controller1(IMetricCellType[] metricCellTypes)
        {
            this.metricCellTypes = metricCellTypes;
        }

        public void Get(MetricCellTypeRequest request)
        {
            // Simple code that is extensible.
            var model = metricCellTypes.Single(x => x.CanHandle(request)).GetView();
            Console.WriteLine("Controller 1: " + model);
        }
    }

    public class Controller2
    {
        private readonly IMyMetricTypeEnumerationType metricTypeEnumType;

        public Controller2(IMyMetricTypeEnumerationType metricTypeParam)
        {
            this.metricTypeEnumType = metricTypeParam;
        }

        public void Get(MetricCellTypeRequest request)
        {
            var model = metricTypeEnumType.GetValueForConstant(request.Type);
            Console.WriteLine("Controller 2: " + model);
        }
    }
}
