using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using static tools.quaryData;

namespace web
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userId"] == null)
            {
                Response.Write("<script>window.location.href = \"./page/login/Login.aspx\";</script>");
                return;
            }
            string userId = Request.Cookies["userId"].Value;
            string sql = "SELECT * FROM USERLIST WHERE ID = '" + userId + "'";
            DataSet ds = QuaryUser(sql);
            string userPerm = ds.Tables[0].Rows[0]["PERMISSION"].ToString();
            string userByna = ds.Tables[0].Rows[0]["BYNAME"].ToString();
            string userFace = ds.Tables[0].Rows[0]["URLFACE"].ToString();
            addByname(userByna);
            addFace(userFace);

            Session["UserID"] = userId;
            Session["UserName"] = ds.Tables[0].Rows[0]["BYNAME"];
            //查看是否文件转储有未下载文件
            {
                string sqlstr = "SELECT BYNAME FROM USERLIST WHERE ID = " + userId;
                DataSet userDs = QuaryUser(sqlstr);
                sqlstr = "SELECT * FROM CLOUDDISK WHERE RECIVER = '" + userDs.Tables[0].Rows[0]["BYNAME"].ToString() + "' AND DOWNSTATUS = 0";
                DataSet cloudFilesDs = QuaryUser(sqlstr);
                if (cloudFilesDs.Tables[0].Rows.Count > 0)
                {
                    if (cloudFilesDs.Tables[0].Rows.Count > 99)
                        NewCloudFilesVal.Value = "99+";
                    else NewCloudFilesVal.Value = cloudFilesDs.Tables[0].Rows.Count.ToString();
                }
            }
        }
        protected void addByname(string userByna)
        {
            byname1.InnerText = userByna;
            byname2.InnerText = userByna;
        }
        protected void addFace(string userFace)
        {
            face1.Attributes.Add("src", userFace);
            face2.Attributes.Add("src", userFace);
        }

    }
}