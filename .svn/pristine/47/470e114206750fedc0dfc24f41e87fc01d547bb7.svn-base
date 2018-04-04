using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using static tools.quaryData;

namespace web.page.sitemail
{
    /// <summary>
    /// cloudDiskFileOper 的摘要说明
    /// </summary>
    public class cloudDiskFileOper : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string operType = context.Request["type"];
            string fileId = context.Request["fileid"];
            if (operType == "0") //下载
            {
                DownloadCloudFile(fileId, context);
            }
            else if (operType == "1") //删除
            {
                DeleteCloudFile(fileId);
            }
            context.Response.Write("<script languge='javascript'>parent.location.href=parent.location.href;</script>");
        }

        public void DownloadCloudFile(string fileid, HttpContext context)
        {
            string sqlstr = "SELECT * FROM CLOUDDISK WHERE ID = " + fileid;
            DataSet downFileDs = QuaryUser(sqlstr);
            if (downFileDs.Tables[0].Rows.Count > 0)
            {
                string fileName = downFileDs.Tables[0].Rows[0]["FILENAME"].ToString();//显示给客户端文件名
                string filePath = downFileDs.Tables[0].Rows[0]["FILEPATH"].ToString();//路径
                string fileFullPath = filePath + fileName;

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileFullPath);

                if (fileInfo.Exists == true)
                {
                    const long ChunkSize = 102400;//100K 每次读取文件，只读取100K，这样可以缓解服务器的压力
                    byte[] buffer = new byte[ChunkSize];

                    context.Response.Clear();
                    System.IO.FileStream iStream = System.IO.File.OpenRead(fileFullPath);
                    long dataLengthToRead = iStream.Length;//获取下载的文件总大小
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
                    context.Response.AddHeader("Content-Length", dataLengthToRead.ToString());
                    while (dataLengthToRead > 0 && context.Response.IsClientConnected)
                    {
                        int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
                        context.Response.OutputStream.Write(buffer, 0, lengthRead);
                        context.Response.Flush();
                        dataLengthToRead = dataLengthToRead - lengthRead;
                    }
                    iStream.Close();
                    //修改该文件的DOWNLOADSTATUS
                    sqlstr = "UPDATE CLOUDDISK SET DOWNSTATUS = 1 WHERE ID = " + fileid;
                    OperateUser(sqlstr);
                    context.Response.End();
                }
                else
                {
                    context.Response.Write("<script languge='javascript'>alert('服务器中没有找到此文件！');</script>");
                    //LayuiMsg("服务器中没有找到此文件！");
                }
            }
        }

        public void DeleteCloudFile(string fileid)
        {
            string sqlstr = "SELECT * FROM CLOUDDISK WHERE ID = " + fileid;
            DataSet delFileDs = QuaryUser(sqlstr);
            if (delFileDs.Tables[0].Rows.Count > 0)
            {
                if (Directory.Exists(delFileDs.Tables[0].Rows[0]["FILEPATH"].ToString()) == true)
                {
                    DirectoryInfo delDir = new DirectoryInfo(delFileDs.Tables[0].Rows[0]["FILEPATH"].ToString());
                    delDir.Delete(true);
                }
                sqlstr = "DELETE FROM CLOUDDISK WHERE ID = " + fileid;
                OperateUser(sqlstr);
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}