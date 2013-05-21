using System.IO;
using Hit.Models;
using Hit.Stores.Base;
using UseAbilities.XML.Serialization;

namespace Hit.Stores
{
    //ToDo: Make this class singleton
    public class HitSettingsStore : XmlStore<HitSettings>
    {
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
                IsTotalsVisible = false
            });

            return SerializationUtility.Deserialize<HitSettings>(FileName);
        }
    }
}
