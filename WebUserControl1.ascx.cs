using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeSheet_git.WebService_1S;
using System.Xml;

namespace TimeSheet_git
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public WebUserControl1()
        { }
        public WebUserControl1(XmlNodeList DTD)
        {
            int hash = DTD.GetHashCode();
            SSSS.ID = hash.ToString();
            SSSS.SelectedIndex = SSSS.Items.IndexOf(SSSS.Items.FindByText(DTD[3].ChildNodes[0].Value));
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}