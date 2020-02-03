using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCWeb.WebForm
{
    [Serializable]
    public class GlobalConfiguration
    {
        public string ApplicationName { get; set; }
        public string DefaultLanguage { get; set; }

        public GlobalConfiguration()
        {
            var config = BaseConfig.BaseConfiguration.GetWebConfig();
            ApplicationName = config.ApplicationName;
            DefaultLanguage = config.DefaultLanguage;
        }
    }
}