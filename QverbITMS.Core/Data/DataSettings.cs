using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using QverbITMS.Core.Extensions;

namespace QverbITMS.Core.Data
{
    public class DataSettings
    {
        private static DataSettings s_current = null;
        private static Func<DataSettings> s_settingsFactory = new Func<DataSettings>(() => new DataSettings());

        private DataSettings()
        {
            RawDataSettings = new Dictionary<string, string>();
        }

        #region Static members

        public static void SetDefaultFactory(Func<DataSettings> factory)
        {
            //Guard.ArgumentNotNull(() => factory);

            s_settingsFactory = factory;
        }

        public static DataSettings Current
        {
            get
            {

                if (s_current == null)
                {
                    s_current = s_settingsFactory();
                    s_current.Load();
                }


                return s_current;
            }
        }

        #endregion

        #region Instance members

        public Version AppVersion
        {
            get;
            set;
        }

        public string DataProvider
        {
            get;
            set;
        }


        public string DataConnectionString
        {
            get;
            set;
        }

        public bool IsSqlServer
        {
            get;
            set;
        }

        public IDictionary<string, string> RawDataSettings
        {
            get;
            private set;
        }

        public bool IsValid()
        {
            return this.DataProvider.HasValue() && this.DataConnectionString.HasValue();
        }

        public virtual bool Load()
        {

            // read from config
            //    if (settings.ContainsKey("AppVersion"))
            //    {
            //        this.AppVersion = new Version(settings["AppVersion"]);
            //    }
            
            //todo : supply Data Provider
            this.DataProvider = "EFv6.1.1";
           

            //todo : check if null etc.
            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            this.DataConnectionString = con;
           

            return true;

        }

        public void Reset()
        {

            this.RawDataSettings.Clear();
            this.AppVersion = null;
            this.DataProvider = null;
            this.DataConnectionString = null;

        }

        public virtual bool Save()
        {
            if (!this.IsValid())
                return false;

            return true;

            //using (s_rwLock.GetWriteLock())
            //{
            //    string filePath = Path.Combine(CommonHelper.MapPath("~/App_Data/"), FILENAME);
            //    if (!File.Exists(filePath))
            //    {
            //        using (File.Create(filePath))
            //        {
            //            // we use 'using' to close the file after it's created
            //        }
            //    }

            //    var text = SerializeSettings();
            //    File.WriteAllText(filePath, text);

            //    return true;
            //}
        }

        #endregion


    }
}