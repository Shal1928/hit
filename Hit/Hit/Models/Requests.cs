//using System;
//using System.Data.Objects.DataClasses;
//using System.Runtime.Serialization;
//using Hit.Models.Base;

//namespace Hit.Models
//{
//    [EdmEntityType(NamespaceName = "HitsModel", Name = "Requests")]
//    [Serializable()]
//    [DataContract(IsReference = true)]
//    public class Requests : UniqueObject
//    {
//        [DataMember]
//        public int RequestThemesId
//        {
//            get; 
//            set;
//        }

//        [DataMember]
//        public int RequestTypesId
//        {
//            get;
//            set;
//        }

//        [DataMember]
//        public DateTime RequestDate
//        {
//            get;
//            set;
//        }
//    }
//}
