using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GCWeb.WebForm
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                phSearchBar.Visible = SearchBarEnabled;
            }
        }

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
        public string PageDateModified
        {
            get { return ((BaseConfig.BasePage)Page).PageDateModified; }
        }
        public string Language
        {
            get { return ((BaseConfig.BasePage)Page).Language; }
            set { ((BaseConfig.BasePage)Page).Language = value; }
        }
        public bool SearchBarEnabled
        {
            get { return ((BaseConfig.BasePage)Page).SearchBarEnabled; }
        }
        #endregion

        protected void lnkLanguage_Click(object sender, EventArgs e)
        {
            this.Language = this.Language == "en" ? "fr" : "en";
            Response.Redirect(Request.RawUrl);
            //string currrentCulture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en" ? "fr-CA" : "en-CA";
            //Response.Redirect(Request.RawUrl + "?lang=" + this.Language == "en" ? "fr" : "en");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(currrentCulture);
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(currrentCulture);

            //Response.Redirect(Request.RawUrl);
        }
    }
}