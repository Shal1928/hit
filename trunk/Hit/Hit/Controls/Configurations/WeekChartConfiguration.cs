using System.Runtime.Serialization;

namespace Hit.Controls.Configurations
{
    [DataContract]
    public class WeekChartConfiguration
    {
        [DataMember]
        public bool MondayIsVisible
        {
            get; 
            set;
        }

        [DataMember]
        public bool TuesdayIsVisible
        {
            get;
            set;
        }

        [DataMember]
        public bool WednesdayIsVisible
        {
            get;
            set;
        }

        [DataMember]
        public bool ThursdayIsVisible
        {
            get;
            set;
        }

        [DataMember]
        public bool FridayIsVisible
        {
            get;
            set;
        }

        [DataMember]
        public bool SaturdayIsVisible
        {
            get;
            set;
        }

        [DataMember]
        public bool SundayIsVisible
        {
            get;
            set;
        }
    }
}
