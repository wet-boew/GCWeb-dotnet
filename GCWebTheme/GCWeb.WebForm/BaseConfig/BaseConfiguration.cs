using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GCWeb.WebForm.BaseConfig
{
    public class BaseConfiguration : ConfigurationSection
    {
        public static BaseConfiguration GetWebConfig()
        {
            if (ConfigurationManager.GetSection("baseConfiguration") is BaseConfiguration config)
                return config;

            return new BaseConfiguration();
        }

        [ConfigurationProperty("applicationName", IsRequired = false)]
        public virtual string ApplicationName
        {
            get { return this["applicationName"] as string; }
            set { this["applicationName"] = value; }
        }

        [ConfigurationProperty("defaultLanguage", IsRequired = false)]
        public virtual string DefaultLanguage
        {
            get { return this["defaultLanguage"] as string; }
            set { this["defaultLanguage"] = value; }
        }

        [ConfigurationProperty("searchBarEnabled", IsRequired = false)]
        public virtual bool SearchBarEnabled
        {
            get { return (this["searchBarEnabled"] as bool?) ?? false; }
            set { this["searchBarEnabled"] = value; }
        }
    }
}