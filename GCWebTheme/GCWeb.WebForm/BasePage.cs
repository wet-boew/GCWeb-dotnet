using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace GCWeb.WebForm
{
    public class BasePage : System.Web.UI.Page
    {
        #region Page Events
        protected override void InitializeCulture()
        {
            string userCulture = null;
            string pattern = "^\\S+-(\\S+).aspx\\S*$";
            Match m = default(Match);

            m = Regex.Match(Request.RawUrl, pattern, RegexOptions.IgnoreCase);

            if (m.Success)
            {
                string lang = m.Groups[1].Value;

                switch (lang)
                {
                    case "e":
                    case "en":
                    case "eng":
                        userCulture = "en-ca";
                        break;
                    case "f":
                    case "fr":
                    case "fra":
                        userCulture = "fr-ca";
                        break;
                    default:
                        int langLength = (m.Groups[1].Value.Length);

                        if (langLength == 2)
                        {
                            userCulture = string.Format("{0}-{1}", lang, lang.ToUpper());
                        }
                        else
                        {
                            userCulture = "en-ca";
                        }
                        break;
                }

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCulture);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCulture);
            }
        }
        #endregion

        #region Public properties
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
                if (!(ViewState["PageLanguage"] is string str))
                {
                    return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
                }
                else
                    return str;
            }
            set
            {
                ViewState["PageLanguage"] = value;
            }
        }
        #endregion
    }
}