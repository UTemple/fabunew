using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page.project
{
    public partial class projectFilesDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filetypestr = Request.QueryString["filetype"];
            string filetypeforuser = string.Empty;
            string fileidstr = Request.QueryString["fileid"];
            string filetable = string.Empty;
            if (filetypestr != null && fileidstr != null)
            {
                //下载权限判断
                string permissinsql = "SELECT PROJECT FROM PERMISSION WHERE USERID = " + Request.Cookies["userId"].Value;
                DataSet userPerinfo = QuaryUser(permissinsql);
                bool canLoad = false;
                if (userPerinfo.Tables[0].Rows.Count > 0)
                {
                    int projectpermission = Convert.ToInt32(userPerinfo.Tables[0].Rows[0]["PROJECT"].ToString());
                    if (projectpermission == 2)
                        canLoad = true;
                }
                if (canLoad == false)
                {
                    Response.Write("<script>window.location.href = \"../noPermission.html\";</script>");
                    return;
                }

                if (filetypestr == "1")
                {
                    filetable = "PRO_PROPOSAL";
                    filetypeforuser = "项目建议书";
                }
                else if (filetypestr == "2")
                {
                    filetable = "PRO_FEASIBILITY_STUDY";
                    filetypeforuser = "可行性研究报告"; 
                }
                else if (filetypestr == "3")
                {
                    filetable = "PRO_PRELIMINARY_DESIGN";
                    filetypeforuser = "初步设计"; 
                }
                else if (filetypestr == "4")
                {
                    filetable = "PRO_DETAILED_DESIGN";
                    filetypeforuser = "施工图及招标";
                }
                else if (filetypestr == "5")
                {
                    filetable = "PRO_DESIGN_CHANGE";
                    filetypeforuser = "设计变更";
                }
                else if (filetypestr == "6")
                {
                    filetable = "PRO_CALCULATION";
                    filetypeforuser = "计算书";
                }
                else
                {
                    //Response.Write("<script languge='javascript'>alert('客户端下载文件类型出错！');</script>");
                    LayuiMsg("客户端下载文件类型出错！");
                    return;
                }

                string sqlstr = "SELECT * FROM " + filetable + " WHERE ID = " + fileidstr;
                DataSet fileds = QuaryUser(sqlstr);
                if (fileds.Tables[0].Rows.Count > 0)
                {
                    string fileName = fileds.Tables[0].Rows[0]["FILENAME"].ToString();//显示给客户端文件名
                    string filePath = fileds.Tables[0].Rows[0]["PATH"].ToString();//路径
                    string fileFullPath = filePath+fileName;

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
                        //记录下载文件日志（文件类型，文件说明，文件名，项目名，操作人，部门，日期，文件所属项目或部门，操作类型），表名称“REC_DOWNLOADFILE”
                        sqlstr = "SELECT NAME FROM PROJECT_INFO WHERE SYSTEMID = " + fileds.Tables[0].Rows[0]["SYSID"].ToString();
                        DataSet projectds = QuarySde(sqlstr);
                        sqlstr = "SELECT BYNAME,DEPARTMENT FROM USERLIST WHERE ID = " +Request.Cookies["userId"].Value;
                        DataSet userds = QuaryUser(sqlstr);
                        string username = userds.Tables[0].Rows[0]["BYNAME"].ToString();
                        string userdept = userds.Tables[0].Rows[0]["DEPARTMENT"].ToString();
                        string filedetail = fileds.Tables[0].Rows[0]["NAME"].ToString();
                        string projectname = projectds.Tables[0].Rows[0]["NAME"].ToString();
                        string nowtime = DateTime.Now.ToLocalTime().ToString();
                        sqlstr = "INSERT INTO REC_DOWNLOADFILE VALUES('" + filetypeforuser +"','"+ filedetail+"','"+ fileName+"','"+ projectname+"','"+ username+"','"+userdept
                                    +"',to_date('"+ nowtime+ "','yyyy/mm/dd HH24:MI:SS'),'"+ projectname + "','下载')";
                        OperateUser(sqlstr);
                        Response.End();
                        //Response.Close();
                    }
                    else
                    {
                        //Response.Write("<script languge='javascript'>alert('服务器中没有找到此文件！');</script>");
                        LayuiMsg("服务器中没有找到此文件！");
                    }
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