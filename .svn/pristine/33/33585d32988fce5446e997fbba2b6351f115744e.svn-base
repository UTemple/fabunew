using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;
//using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.IO.Compression;

namespace web.page.docsummary
{
    public partial class topographicDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = Request.QueryString["fname"];
            if (fileName != null)
            {
                //下载权限判断
                string permissinsql = "SELECT TOPOGRAPHIC FROM PERMISSION WHERE USERID = " + Request.Cookies["userId"].Value;
                DataSet userPerinfo = QuaryUser(permissinsql);
                bool canLoad = false;
                if (userPerinfo.Tables[0].Rows.Count > 0)
                {
                    int permission = Convert.ToInt32(userPerinfo.Tables[0].Rows[0]["TOPOGRAPHIC"].ToString());
                    if (permission == 1)
                        canLoad = true;
                }
                if (canLoad == false)
                {
                    //Response.Write("<script>window.location.href = \"../noPermission.html\";</script>");
                    LayuiMsg("没有下载权限，如有需要请联系智慧所开通！");
                    return;
                }

                if (fileName.IndexOf(',') == -1)//下载单个文件
                {
                    string fileFullPath = @"E:\Ourgis_ProjectFiles\TopographicFiles\\" + fileName;

                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileFullPath);

                    if (fileInfo.Exists == true)
                    {
                        const long ChunkSize = 102400;//100K 每次读取文件，只读取100K，这样可以缓解服务器的压力
                        byte[] buffer = new byte[ChunkSize];

                        Response.Clear();
                        System.IO.FileStream iStream = System.IO.File.OpenRead(fileFullPath);
                        long dataLengthToRead = iStream.Length;//获取下载的文件总大小
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
                        Response.AddHeader("Content-Length", dataLengthToRead.ToString());
                        while (dataLengthToRead > 0 && Response.IsClientConnected)
                        {
                            int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
                            Response.OutputStream.Write(buffer, 0, lengthRead);
                            Response.Flush();
                            dataLengthToRead = dataLengthToRead - lengthRead;
                        }
                        iStream.Close();
                        LogTopographicDownLoad(fileName + " single"); //单个文件下载，加single标记
                        Response.End();
                    }
                    else
                    {
                        //Response.Write("<script languge='javascript'>alert('服务器中没有找到此文件！');</script>");
                        LayuiMsg("服务器中没有找到此文件！");
                    }
                }
                else //批量下载文件，最大一次1000个文件
                {
                    string[] filenamearray = fileName.Split(',');
                    if (filenamearray.Length > 1000)
                    {
                        LayuiMsg("本次下载文件数过多，批量下载文件最大个数为1000个！");
                    }
                    else
                    {
                        string zipfilename = "Topographic_" + DateTime.Now.ToFileTime().ToString() + ".zip";
                        using (ZipArchive ziparc = ZipFile.Open(@"E:\Ourgis_ProjectFiles\TopographicFiles\\" + zipfilename, ZipArchiveMode.Create))
                        {
                            foreach (string item in filenamearray)
                            {
                                ziparc.CreateEntryFromFile(@"E:\Ourgis_ProjectFiles\TopographicFiles\\" + item, item);
                                LogTopographicDownLoad(item + " multi"); //批量文件下载，加multi标记
                            }
                        }

                        FileInfo zipfilelast = new FileInfo(@"E:\Ourgis_ProjectFiles\TopographicFiles\\" + zipfilename);
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(zipfilename));
                        Response.AddHeader("Content-Length", zipfilelast.Length.ToString());
                        byte []buffer = new byte[zipfilelast.Length];
                        FileStream tmpfs = zipfilelast.Open(FileMode.Open);
                        tmpfs.Read(buffer, 0, (int)zipfilelast.Length);
                        //topodlDiv.InnerHtml = "";
                        Response.BinaryWrite(buffer);
                        Response.Flush();
                        tmpfs.Close();
                        zipfilelast.Delete();
                        Response.End();
                    }
                }
            }
            else LayuiMsg("客户端信息不全，下载文件出错！");//Response.Write("<script languge='javascript'>alert('客户端信息不全，下载文件出错！');</script>");
        }

        protected void LogTopographicDownLoad(string filename)
        {
            //记录下载文件日志（文件类型，文件说明，文件名，项目名，操作人，部门，日期，文件所属项目或部门，操作类型），表名称“REC_DOWNLOADFILE”
            string sqlstr = "SELECT BYNAME,DEPARTMENT FROM USERLIST WHERE ID = " + Request.Cookies["userId"].Value;
            DataSet userds = QuaryUser(sqlstr);
            string username = userds.Tables[0].Rows[0]["BYNAME"].ToString();
            string userdept = userds.Tables[0].Rows[0]["DEPARTMENT"].ToString();
            string nowtime = DateTime.Now.ToLocalTime().ToString();
            sqlstr = "INSERT INTO REC_DOWNLOADFILE VALUES('地形图','地形图','" + filename + "',' ','" + username + "','" + userdept
                        + "',to_date('" + nowtime + "','yyyy/mm/dd HH24:MI:SS'),'地形图','下载')";
            OperateUser(sqlstr);
        }

        protected void LayuiMsg(string msg)
        {
            topodlDiv.InnerHtml = "<script>layui.use('layer', function(){var layer = layui.layer;layer.msg('" + msg
                                      + "', {icon: 7,time: 5000,area: '300',btnAlign: 'c',btn: ['确认']}, function(){window.close();});});</script>";
        }
    }
}