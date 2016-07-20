using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using TimeSheet_git.WebService_1S;

namespace TimeSheet_git
{
    public partial class WebForm_Main : System.Web.UI.Page
    {
        Portal proxy;
        string UserName;
        private Property[][] Res;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserName = HttpContext.Current.User.Identity.Name.Replace("GAZCOMPLECT\\", "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            proxy = new Portal();
            proxy.Credentials = new NetworkCredential("Portal", "Lo(Ju12");

            proxy.QueryToDatabaseCompleted += proxy_QueryToDatabaseCompleted;
            proxy.QueryToDatabaseAsync(UserName, DateTime.Parse(TextBox1.Text), DateTime.Parse(TextBox2.Text));
        }

        protected void proxy_QueryToDatabaseCompleted(object sender, QueryToDatabaseCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null && e.Result != null)
                DrawTable(e.Result);   
        }

        private void DrawTable(Property[][] property)
        {
            Table MyTable = new Table();
            MyTable.CssClass = "table-bordered";
            int i = 0;
            TableHeaderRow THeader = new TableHeaderRow();
            TableHeaderCell THCell1 = new TableHeaderCell();
            THCell1.Text = "ФИО <br /> Должность <br /> Таб.№";
            THeader.Cells.Add(THCell1);
            foreach (Property[] p in property)
            {
                TableRow TRow = new TableRow(); 
                TableCell TCell = new TableCell();
                TCell.Text = "<b>" + p[0].Value.ToString() + "</b><br />";
                TCell.Text += p[2].Value.ToString();
                TCell.Text += "<br /><b>" + p[1].Value.ToString() + "</b>";
                TRow.Cells.Add(TCell);
                int ii = 0;
                foreach (XmlNode rr in ((System.Xml.XmlNode[])((p[3].Value))))
                {
                    if (rr.GetType().Name == "XmlElement")
                    {
                        if (i == 0)
                        {
                            TableHeaderCell THCell = new TableHeaderCell();
                            THCell.Text = DateTime.Parse(rr.ChildNodes[1].ChildNodes[0].Value).Day.ToString();
                            THeader.Cells.Add(THCell);
                        }
                        XmlNode d = rr.ChildNodes[0];
                        ////rr.ChildNodes[1].ChildNodes[0].Value - date
                        //// rr.ChildNodes[3].ChildNodes[0].Value - typeofday

                        WebUserControl1 WebUserControl = new WebUserControl1(rr.ChildNodes);
                        
                        TableCell TDayCell = new TableCell();
                        
                        //TDayCell.ID = TCell.Text + ii.ToString();
                        //TDayCell.Text = rr.ChildNodes[3].ChildNodes[0].Value;
                        //AjaxControlToolkit.DropDownExtender DropD = new AjaxControlToolkit.DropDownExtender();
                        //DropD.DropDownControlID = "DropPanel";
                        //DropD.TargetControlID = TDayCell.ID;
                        TDayCell.Controls.Add(WebUserControl);
                        TRow.Cells.Add(TDayCell);
                        ii++;
                    }
                }
                if (i == 0)
                {
                    MyTable.Rows.Add(THeader);
                    i = 1;
                }
                MyTable.Rows.Add(TRow);
                // stroki risovat'
            }
            MyTable.Style.Add("table-bordered", "border");
            form1.Controls.Add(MyTable);
        }
    }
}