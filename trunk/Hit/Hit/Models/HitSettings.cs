using System.Runtime.Serialization;

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
    }
}
