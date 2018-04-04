using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page.sitemail
{
    public partial class cloudDiskSendFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = Request.Cookies["userId"].Value;
            if (userid.Length == 0)
            {
                Response.Write("<script>window.location.href = \"../NotLogin.html\";</script>");
                return;
            }

            string sqlstr = "SELECT * FROM USERLIST WHERE ID = " + userid;
            DataSet senderDs = QuaryUser(sqlstr);
            string userByName = senderDs.Tables[0].Rows[0]["BYNAME"].ToString();

            sqlstr = "SELECT * FROM CLOUDDISK WHERE SENDER = '" + userByName + "' ORDER BY UPTIME DESC";
            DataSet filesDs = QuaryUser(sqlstr);
            string recvStatus = string.Empty;
            if (filesDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow temprow in filesDs.Tables[0].Rows)
                {
                    if (temprow["DOWNSTATUS"].ToString() == "0")
                        recvStatus = "<td style=\"color:red\">未接收</td>";
                    else recvStatus = "<td style=\"color:green\">已接收</td>";
                    files_content.InnerHtml += "<tr>"
                                            + "<td>" + temprow["RECIVER"].ToString() + "</td>"
                                            + "<td>" + temprow["FILENAME"].ToString() + "</td>"
                                            + "<td>" + temprow["FILESIZE"].ToString() + "</td>"
                                            + "<td>" + temprow["UPTIME"].ToString() + "</td>"
                                            + recvStatus
                                            //+ "<td><a class=\"layui-btn deletefile\" data-id=\"" + temprow["ID"].ToString() + "\" >删除</a>"
                                            + "<td><a class=\"layui-btn layui-btn-danger deletefile\" data-id=\"" + temprow["ID"].ToString() + "\" >删除</a>"
                                            //+ "<td><asp:Button runat=\"server\" class=\"layui-btn layui-btn-danger\"  CommandName=\"DeleteFile\"  CommandArgument=\"" + temprow["ID"].ToString() + "\" OnCommand=\"DeleteCloudFile\" Text=\"删除\">删除</asp:Button>"
                                            + "</tr>";
                }
            }
            else files_content.InnerHtml = "<tr><td colspan=\"6\">暂无数据</td></tr>";
        }

        //public void DeleteCloudFile(Object sender, CommandEventArgs e)
        //{
        //    string cmdArgs = e.CommandArgument.ToString();
        //    string sqlstr = "SELECT * FROM CLOUDDISK WHERE ID = " + cmdArgs;
        //    DataSet delFileDs = QuaryUser(sqlstr);
        //    if (delFileDs.Tables[0].Rows.Count > 0)
        //    {
        //        DirectoryInfo delDir = new DirectoryInfo(delFileDs.Tables[0].Rows[0]["FILEPATH"].ToString());
        //        delDir.Delete(true);
        //        sqlstr = "DELETE FROM CLOUDDISK WHERE ID = " + cmdArgs;
        //        OperateUser(sqlstr);
        //    }
        //}
    }
}