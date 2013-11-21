using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;

namespace Asp {
    
    public static class AppSettingsStatic {

        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration(null);

        public static string GetSettingValue(string _settingName) {
            string result = null;

            if (rootWebConfig != null && rootWebConfig.AppSettings != null) {
                result = rootWebConfig.AppSettings.Settings[_settingName].Value;
            }

            return result;
        }


    }

}