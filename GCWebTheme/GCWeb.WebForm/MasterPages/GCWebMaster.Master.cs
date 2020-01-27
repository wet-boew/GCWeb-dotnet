using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GCWeb.WebForm
{
    public partial class SiteMaster : MasterPage
    {
        public virtual string PageDateModified
        {
            get
            {
                if (!(ViewState["PageDateModified"] is string str))
                {
                    System.IO.FileInfo objInfo = new System.IO.FileInfo(Server.MapPath(Request.ServerVariables.Get("SCRIPT_NAME")));
                    return String.Format("{0:yyyy-MM-dd}", objInfo.LastWriteTime.Date);
                }
                else
                    return str;
            }
            set { ViewState["PageDateModified"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}