using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page.sitemail
{
    public partial class cloudDiskRecvFiles : System.Web.UI.Page
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

            sqlstr = "SELECT * FROM CLOUDDISK WHERE RECIVER = '" + userByName + "' ORDER BY UPTIME DESC";
            DataSet filesDs = QuaryUser(sqlstr);
            string downStatus = string.Empty;
            if (filesDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow temprow in filesDs.Tables[0].Rows)
                {
                    if (temprow["DOWNSTATUS"].ToString() == "0")
                        downStatus = "<td style=\"color:red\">未下载</td>";
                    else downStatus = "<td style=\"color:green\">已下载</td>";
                    files_content.InnerHtml += "<tr>"
                                            + "<td>" + temprow["SENDER"].ToString() + "</td>"
                                            + "<td>" + temprow["FILENAME"].ToString() + "</td>"
                                            + "<td>" + temprow["FILESIZE"].ToString() + "</td>"
                                            + "<td>" + temprow["UPTIME"].ToString() + "</td>"
                                            + downStatus
                                            + "<td><a class=\"layui-btn downloadfile\" data-id=\"" + temprow["ID"].ToString() + "\" >下载</a>"
                                            //+ "<td><asp:Button runat=\"server\" class=\"layui-btn\"  CommandName=\"DownloadFile\"  CommandArgument=\"" + temprow["ID"].ToString() + "\" OnCommand=\"DownloadCloudFile\" Text=\"下载\">下载</asp:Button>"
                                            + "</tr>";
                }
            }
            else files_content.InnerHtml = "<tr><td colspan=\"6\">暂无数据</td></tr>";
        }

        //public void DownloadCloudFile(Object sender, CommandEventArgs e)
        //{
        //    string cmdArgs = e.CommandArgument.ToString();
        //    string sqlstr = "SELECT * FROM CLOUDDISK WHERE ID = " + cmdArgs;
        //    DataSet downFileDs = QuaryUser(sqlstr);
        //    if (downFileDs.Tables[0].Rows.Count > 0)
        //    {
        //        string fileName = downFileDs.Tables[0].Rows[0]["FILENAME"].ToString();//显示给客户端文件名
        //        string filePath = downFileDs.Tables[0].Rows[0]["FILEPATH"].ToString();//路径
        //        string fileFullPath = filePath + fileName;

        //        System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileFullPath);

        //        if (fileInfo.Exists == true)
        //        {
        //            const long ChunkSize = 102400;//100K 每次读取文件，只读取100K，这样可以缓解服务器的压力
        //            byte[] buffer = new byte[ChunkSize];

        //            Response.Clear();
        //            System.IO.FileStream iStream = System.IO.File.OpenRead(fileFullPath);
        //            long dataLengthToRead = iStream.Length;//获取下载的文件总大小
        //            Response.ContentType = "application/octet-stream";
        //            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
        //            Response.AddHeader("Content-Length", dataLengthToRead.ToString());
        //            while (dataLengthToRead > 0 && Response.IsClientConnected)
        //            {
        //                int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
        //                Response.OutputStream.Write(buffer, 0, lengthRead);
        //                Response.Flush();
        //                dataLengthToRead = dataLengthToRead - lengthRead;
        //            }

        //            //修改该文件的DOWNLOADSTATUS
        //            sqlstr = "UPDATE CLOUDDISK SET DOWNSTATUS = 1 WHERE ID = " + cmdArgs;
        //            OperateUser(sqlstr);
        //            Response.End();
        //        }
        //        else
        //        {
        //            Response.Write("<script languge='javascript'>alert('服务器中没有找到此文件！');</script>");
        //            //LayuiMsg("服务器中没有找到此文件！");
        //        }
        //    }
        //}
    }
}