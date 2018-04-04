using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;
using static tools.ConvertJson;

namespace web.page.recinfo
{
    public partial class recinfoLoginDetailget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Request.QueryString["id"];
            string startTime = Request.QueryString["st"];
            string endTime = Request.QueryString["et"];
            if (userName != null && userName.Length > 0)
            {
                string sqlstr = "SELECT * FROM LOGINREC WHERE NAME = '" + userName + "'";
                if (startTime != null && startTime != string.Empty && endTime != null && endTime != string.Empty)
                {
                    startTime += " 00:00:00";
                    endTime += " 23:59:59";
                    sqlstr += " AND LOGINTIME >= to_date('" + startTime + "', 'yyyy/mm/dd HH24:MI:SS') AND LOGINTIME <= to_date('" + endTime + "', 'yyyy/mm/dd HH24:MI:SS')";
                }
                sqlstr += " ORDER BY LOGINTIME DESC";
                DataSet userloginDs = QuaryUser(sqlstr);
                Response.Clear();
                Response.ContentEncoding = Encoding.UTF8;
                Response.ContentType = "application/json";
                Response.Write(ToJson(userloginDs));
                Response.Flush();
                Response.End();
            }
        }
    }
}