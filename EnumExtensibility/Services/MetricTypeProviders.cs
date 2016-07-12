namespace EnumExtensibility.Services
{
    // The request model
    public class MetricCellTypeRequest
    {
        public string Type { get; set; }
    }

    // The Interface
    public interface IMetricCellType
    {
        bool CanHandle(MetricCellTypeRequest request);
        string GetView();
    }

    // Implementations of the interface
    public class TextMetricCellType : IMetricCellType
    {
        public bool CanHandle(MetricCellTypeRequest request)
        {
            return request.Type.Equals("Text");
        }

        public string GetView()
        {
            return "TextView";
        }
    }

    public class StateLabelMetricCellType : IMetricCellType
    {
        public bool CanHandle(MetricCellTypeRequest request)
        {
            return request.Type.Equals("StateLabel");
        }

        public string GetView()
        {
            return "StateLabelView";
        }
    }

    public class OtherMetricCellType : IMetricCellType
    {
        public bool CanHandle(MetricCellTypeRequest request)
        {
            return request.Type.Equals("Other");
        }

        public string GetView()
        {
            return "OtherView";
        }
    }

    //public class ExtendedMetricCellType : IMetricCellType
    //{
    //    public bool CanHandle(MetricCellTypeRequest request)
    //    {
    //        return request.Type.Equals("Extended");
    //    }

    //    public string GetView()
    //    {
    //        return "ExtendedView";
    //    }
    //}
}
