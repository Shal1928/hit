using System.Runtime.Serialization;

namespace Hit.Controls.Configurations
{
    [DataContract]
    public class WeekChartConfiguration
    {
        public WeekChartConfiguration()
        {
            //
        }

        public WeekChartConfiguration(bool workDayIsVisible, bool weekEndIsVisible = false)
        {
            MondayIsVisible = workDayIsVisible;
            TuesdayIsVisible = workDayIsVisible;
            WednesdayIsVisible = workDayIsVisible;
            ThursdayIsVisible = workDayIsVisible;
            FridayIsVisible = workDayIsVisible;

            SaturdayIsVisible = weekEndIsVisible;
            SundayIsVisible = weekEndIsVisible;
        }

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
