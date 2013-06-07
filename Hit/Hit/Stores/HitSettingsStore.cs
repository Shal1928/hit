using System.Collections.Generic;
using System.IO;
using Hit.Controls.Configurations;
using Hit.Models;
using Hit.Stores.Base;
using UseAbilities.XML.Serialization;

namespace Hit.Stores
{
    public class HitSettingsStore : XmlStore<HitSettings>
    {
        #region Singleton implementation

        private HitSettingsStore()
        {

        }

        private static readonly HitSettingsStore Instance = new HitSettingsStore();
        public static HitSettingsStore GetInstance()
        {
            return Instance;
        }

        #endregion
        
        private const string FILE_NAME = "HitSettings.xml";
        public override string FileName
        {
            get
            {
                return FILE_NAME;
            }
        }

        public override HitSettings Load()
        {
            if (!File.Exists(FileName)) base.Save(new HitSettings
            {
                IsTotalsVisible = false,
                IsABBYYWeekChartVisible = false,
                IsFILENETWeekChartVisible = false,
                IsSAPWeekChartVisible = false,
                IsEnvironmentWeekChartVisible = false,
                WeekChartConfigurationList = new List<WeekChartConfiguration>
                                                       {
                                                           //ABBYY
                                                           new WeekChartConfiguration
                                                               {
                                                                   MondayIsVisible = true,
                                                                   TuesdayIsVisible = true,
                                                                   WednesdayIsVisible = true,
                                                                   ThursdayIsVisible = true,
                                                                   FridayIsVisible = true,
                                                                   SaturdayIsVisible = true,
                                                                   SundayIsVisible = true
                                                               },
                                                            //FILNET
                                                            new WeekChartConfiguration
                                                               {
                                                                   MondayIsVisible = true,
                                                                   TuesdayIsVisible = true,
                                                                   WednesdayIsVisible = true,
                                                                   ThursdayIsVisible = true,
                                                                   FridayIsVisible = true,
                                                                   SaturdayIsVisible = true,
                                                                   SundayIsVisible = true
                                                               },
                                                            //SAP
                                                            new WeekChartConfiguration
                                                               {
                                                                   MondayIsVisible = true,
                                                                   TuesdayIsVisible = true,
                                                                   WednesdayIsVisible = true,
                                                                   ThursdayIsVisible = true,
                                                                   FridayIsVisible = true,
                                                                   SaturdayIsVisible = true,
                                                                   SundayIsVisible = true
                                                               },
                                                            //Environment
                                                            new WeekChartConfiguration
                                                               {
                                                                   MondayIsVisible = true,
                                                                   TuesdayIsVisible = true,
                                                                   WednesdayIsVisible = true,
                                                                   ThursdayIsVisible = true,
                                                                   FridayIsVisible = true,
                                                                   SaturdayIsVisible = true,
                                                                   SundayIsVisible = true
                                                               }
                                                       }
            });

            return SerializationUtility.Deserialize<HitSettings>(FileName);
        }
    }
}
