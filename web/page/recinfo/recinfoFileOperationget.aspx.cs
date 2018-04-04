using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;
using static tools.ConvertJson;
using System.Data;
using System.Text;

namespace web.page.recinfo
{
    public partial class recinfoFileOperationget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = QuaryUser("SELECT * FROM REC_DOWNLOADFILE ORDER BY DOWNLOADDATE DESC");
            foreach (DataRow tmprow in ds.Tables[0].Rows)
            {
                if (tmprow["OPTTYPE"].ToString().Length == 0)
                {
                    tmprow["OPTTYPE"] = "下载";
                }
            }

            Response.Clear();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/json";
            Response.Write(ToJson(ds));
            Response.Flush();
            Response.End();
        }
    }
}