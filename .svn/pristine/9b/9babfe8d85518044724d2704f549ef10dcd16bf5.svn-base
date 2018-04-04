using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page.deptdocspace
{
    public partial class DeptFilesDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileidstr = Request.QueryString["fileid"];
            if (fileidstr != null)
            {
                //获取文件属于哪个部门
                string sqlstr = "SELECT * FROM DEPT_DOC WHERE ID = " + fileidstr;
                DataSet deptfilesinfo = QuaryUser(sqlstr);
                if (deptfilesinfo.Tables[0].Rows.Count > 0)
                {
                    string deptbelong = deptfilesinfo.Tables[0].Rows[0]["DOCBELONGDEPT"].ToString();
                    string pernamestr = string.Empty;
                    if (deptbelong == "水工建筑二所")
                        pernamestr = "SGESDOC";

                    //下载权限判断
                    string permissinsql = "SELECT "+ pernamestr + " FROM PERMISSION WHERE USERID = " + Request.Cookies["userId"].Value;
                    DataSet userPerinfo = QuaryUser(permissinsql);
                    bool canLoad = false;
                    if (userPerinfo.Tables[0].Rows.Count > 0)
                    {
                        int docpermission = Convert.ToInt32(userPerinfo.Tables[0].Rows[0][pernamestr].ToString());
                        if (docpermission > 0)//1可以下载，2可下载删除
                            canLoad = true;
                    }
                    if (canLoad == false)
                    {
                        Response.Write("<script>window.location.href = \"../noPermission.html\";</script>");
                        return;
                    }

                    string fileName = deptfilesinfo.Tables[0].Rows[0]["FILENAME"].ToString();//显示给客户端文件名
                    string filePath = deptfilesinfo.Tables[0].Rows[0]["PATH"].ToString();//路径
                    string fileFullPath = filePath + fileName;

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
                        //记录下载文件日志（文件类型，文件说明，文件名，项目名，操作人，操作人部门，日期，文件所属项目或部门，操作类型），表名称“REC_DOWNLOADFILE”
                        sqlstr = "SELECT BYNAME,DEPARTMENT FROM USERLIST WHERE ID = " + Request.Cookies["userId"].Value;
                        DataSet userds = QuaryUser(sqlstr);
                        string username = userds.Tables[0].Rows[0]["BYNAME"].ToString();
                        string userdept = userds.Tables[0].Rows[0]["DEPARTMENT"].ToString();
                        string filedetail = deptfilesinfo.Tables[0].Rows[0]["NAME"].ToString();
                        string nowtime = DateTime.Now.ToLocalTime().ToString();
                        sqlstr = "INSERT INTO REC_DOWNLOADFILE VALUES('部门文件','" + filedetail + "','" + fileName + "','" + deptbelong + "','" + username + "','" + userdept
                                    + "',to_date('" + nowtime + "','yyyy/mm/dd HH24:MI:SS'),'"+ deptbelong + "','下载')";
                        OperateUser(sqlstr);
                        Response.End();
                        //Response.Close();
                    }
                    else
                    {
                        LayuiMsg("服务器中没有找到此文件！");
                    }
                }
                else
                {
                    LayuiMsg("数据库中没有找到此文件！");
                }
            }
            else LayuiMsg("客户端信息不全，下载文件出错！");//Response.Write("<script languge='javascript'>alert('客户端信息不全，下载文件出错！');</script>");
        }

        protected void LayuiMsg(string msg)
        {
            endDldiv.InnerHtml = "<script>layui.use('layer', function(){var layer = layui.layer;layer.msg('" + msg
                                      + "', {icon: 7,time: 5000,area: '300',btnAlign: 'c',btn: ['确认']}, function(){window.close();});});</script>";
        }
    }
}