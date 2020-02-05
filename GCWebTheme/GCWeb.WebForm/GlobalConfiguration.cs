using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCWeb.WebForm
{
    [Serializable]
    public class GlobalConfiguration : BaseConfig.BaseConfiguration
    {
        public GlobalConfiguration()
        {
            // comment that section if you want to config your application with your own settings
            var config = BaseConfig.BaseConfiguration.GetWebConfig();
            ApplicationName = config.ApplicationName;
            DefaultLanguage = config.DefaultLanguage;
            SearchBarEnabled = config.SearchBarEnabled;


            // exemple of custom config
            // ApplicationName = "My own Application Name";
        }
    }
}