using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EnumExtensibility.Services;

namespace EnumExtensibility.Infrastructure
{
    public class IoCInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register the interface and all its implementations.
            container.Register(Classes.FromThisAssembly()
                                      .BasedOn<IMetricCellType>()
                                      .WithService.FromInterface());

            // Let IoC resolve the Controllers.
            container.Register(Classes.FromThisAssembly().Where(x => x.Name.Contains("Controller")));
        }
    }
}
