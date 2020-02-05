using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace GCWeb.WebForm.BaseConfig
{
    public class BasePage : System.Web.UI.Page
    {
        #region Page Events
        protected override void InitializeCulture()
        {
            if (!string.IsNullOrEmpty(Request["lang"]))
            {
                Session["lang"] = Request["lang"];
            }
            else if (Session["lang"] == null)
            {
                Session["lang"] = Config.DefaultLanguage;
            }

            string lang = Session["lang"].ToString();
            string culture = string.Empty;

            if (lang.ToLower().Contains("fr"))
            {
                culture = "fr-CA";
            }
            else
            {
                culture = "en-CA";
            }

            var cultureInfo = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Global Configuration Object
        /// </summary>
        public GlobalConfiguration Config
        {
            get
            {
                if (ViewState["Config"] == null)
                {
                    ViewState["Config"] = new GlobalConfiguration();
                }
                return (GlobalConfiguration)ViewState["Config"];
            }
            set { ViewState["Config"] = value; }
        }
        /// <summary>
        /// A language of the resource.
        /// </summary>
        /// <remarks>
        /// Two-letter language. Default is English ("en").
        /// </remarks>
        public virtual string Language
        {
            get
            {
                if (!(Session["lang"] is string str))
                {
                    return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
                }
                else
                    return str;
            }
            set { Session["lang"] = value; }
        }
        public virtual string PageDateModified
        {
            get
            {
                if (!(ViewState["PageDateModified"] is string str))
                {
                    System.IO.FileInfo objInfo = new System.IO.FileInfo(Server.MapPath(Request.ServerVariables.Get("SCRIPT_NAME")));
                    return objInfo.LastWriteTime.Date.ToString("d");
                }
                else
                    return str;
            }
            set { ViewState["PageDateModified"] = value; }
        }
        public virtual bool SearchBarEnabled
        {
            get { return (ViewState["IsReviewing"] as bool?) ?? Config.SearchBarEnabled; }
            set { ViewState["SearchBarEnabled"] = value; }
        }
        #endregion
    }
}