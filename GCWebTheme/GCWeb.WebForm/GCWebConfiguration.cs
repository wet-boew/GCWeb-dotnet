using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GCWeb.WebForm
{
    public class GCWebConfiguration : ConfigurationSection
    {
        internal static GCWebConfiguration GetConfiguration()
        {
            GCWebConfiguration config = (GCWebConfiguration)System.Configuration.ConfigurationManager.GetSection("GCWebConfiguration");
            if (config != null) return config;

            return new GCWebConfiguration();
        }

        [ConfigurationProperty("ApplicationName", DefaultValue = "", IsRequired = false)]
        public string ApplicationName
        {
            get { return (string)this["ApplicationName"]; }
            set { this["ApplicationName"] = value; }
        }

        [ConfigurationProperty("DefaultLanguage", DefaultValue = "en", IsRequired = false)]
        public string DefaultLanguage
        {
            get { return (string)this["DefaultLanguage"]; }
            set { this["DefaultLanguage"] = value; }
        }
    }
}