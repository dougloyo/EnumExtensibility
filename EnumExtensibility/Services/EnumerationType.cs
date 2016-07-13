using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EnumExtensibility.Services
{
    public interface IEnumerationType<TResponse>
    {
        TResponse GetValueForConstant(string constant);
    }

    public interface IMyMetricTypeEnumerationType : IEnumerationType<int> { }

    public class MyMetricTypeEnumeration : IMyMetricTypeEnumerationType
    {
        private enum MetricTypeEnum
        {
            Text,
            StatusLabel,
            Other,
        }
        public int GetValueForConstant(string constant)
        {
            return (int)Enum.Parse(typeof(MetricTypeEnum), constant);
        }
    }
}
