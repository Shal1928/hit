using System.Runtime.Serialization;
using Hit.Models.Base;

namespace Hit.Models
{
    public class RequestThemes : UniqueObject
    {
        [DataMember]
        public string RequestTheme
        {
            get;
            set;
        }
    }
}
