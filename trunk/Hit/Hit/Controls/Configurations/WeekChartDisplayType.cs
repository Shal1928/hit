using System.Runtime.Serialization;

namespace Hit.Controls.Configurations
{
    [DataContract]
    public enum WeekChartDisplayType
    {
        [EnumMember]
        All = 0,
        [EnumMember]
        WorkDays,
        [EnumMember]
        TodayAndYesterday,
        //[DataMember]
        //TodayAndYesterdayWithoutWeekend
    }
}
