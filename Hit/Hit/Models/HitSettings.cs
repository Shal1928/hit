using System.Collections.Generic;
using System.Runtime.Serialization;
using Hit.Controls.Configurations;

namespace Hit.Models
{
    [DataContract]
    public class HitSettings
    {
        [DataMember]
        public bool IsTotalsVisible
        {
            get;
            set;
        }
        
        [DataMember]
        public bool IsABBYYWeekChartVisible
        {
            get;
            set;
        }

        [DataMember]
        public bool IsFILENETWeekChartVisible
        {
            get;
            set;
        }

        [DataMember]
        public bool IsSAPWeekChartVisible
        {
            get;
            set;
        }

        [DataMember]
        public bool IsEnvironmentWeekChartVisible
        {
            get;
            set;
        }

        [DataMember]
        public List<WeekChartConfiguration> WeekChartConfigurationList
        {
            get;
            set;
        }

        [DataMember]
        public WeekChartDisplayType DisplayType
        {
            get;
            set;
        }
    }
}
