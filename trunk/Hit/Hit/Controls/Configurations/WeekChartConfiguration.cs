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
            InitializeWeekChartConfiguration(workDayIsVisible, workDayIsVisible, workDayIsVisible, workDayIsVisible, workDayIsVisible, weekEndIsVisible, weekEndIsVisible);
        }

        public WeekChartConfiguration(bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday)
        {
            InitializeWeekChartConfiguration(monday, tuesday, wednesday, thursday, friday, saturday, sunday);
        }

        private void InitializeWeekChartConfiguration(bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday)
        {
            MondayIsVisible = monday;
            TuesdayIsVisible = tuesday;
            WednesdayIsVisible = wednesday;
            ThursdayIsVisible = thursday;
            FridayIsVisible = friday;

            SaturdayIsVisible = saturday;
            SundayIsVisible = sunday;
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
