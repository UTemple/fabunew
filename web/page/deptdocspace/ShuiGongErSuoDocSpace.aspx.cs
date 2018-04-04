using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page
{
    public partial class ShuiGongErSuoDocSpace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string deptid = Request.QueryString["deptid"];
            if (deptid == null)
            {
                Response.Write("<script languge='javascript'>alert('没有指定正确的部门号！');</script>");
                return;
            }

            string pername = string.Empty;
            if (deptid == "sges")
                pername = "SGESDOC";//水工二所资料权限
            
            //删除文件
            string delfileid = Request.QueryString["deleteid"];
            if (delfileid != null && delfileid.Length > 0)
            {
                string delestr = "SELECT * FROM DEPT_DOC WHERE ID = " + delfileid;
                DataSet todelfile = QuaryUser(delestr);
                if (todelfile.Tables[0].Rows.Count > 0)
                {
                    //判断是否有删除权限
                    string delpername = string.Empty;
                    if (todelfile.Tables[0].Rows[0]["DOCBELONGDEPT"].ToString() == "水工建筑二所")
                    {
                        delpername = "SGESDOC";
                    }
                    delestr = "SELECT " + delpername + " FROM PERMISSION WHERE USERID = " + Request.Cookies["userId"].Value;
                    DataSet delperds = QuaryUser(delestr);
                    if (delperds.Tables[0].Rows.Count == 0 || delperds.Tables[0].Rows[0][delpername].ToString() != "2")
                    {
                        Response.Write("<script languge='javascript'>alert('无权限删除该文件！');</script>");
                        return;
                    }
                    
                    File.Delete(todelfile.Tables[0].Rows[0]["PATH"].ToString() + todelfile.Tables[0].Rows[0]["FILENAME"].ToString());
                    delestr = "DELETE FROM DEPT_DOC WHERE ID = " + delfileid;
                    OperateUser(delestr);
                    //记录删除文件日志（文件类型，文件说明，文件名，项目名，操作人，操作人部门，日期，文件所属项目或部门，操作类型），表名称“REC_DOWNLOADFILE”
                    delestr = "SELECT BYNAME,DEPARTMENT FROM USERLIST WHERE ID = " + Request.Cookies["userId"].Value;
                    DataSet userds = QuaryUser(delestr);
                    string username = userds.Tables[0].Rows[0]["BYNAME"].ToString();
                    string userdept = userds.Tables[0].Rows[0]["DEPARTMENT"].ToString();
                    string filedetail = todelfile.Tables[0].Rows[0]["NAME"].ToString();
                    string filename = todelfile.Tables[0].Rows[0]["FILENAME"].ToString();
                    string filebelong = todelfile.Tables[0].Rows[0]["DOCBELONGDEPT"].ToString();
                    string nowtime = DateTime.Now.ToLocalTime().ToString();
                    delestr = "INSERT INTO REC_DOWNLOADFILE VALUES('部门文件','" + filedetail + "','" + filename + "','" + filebelong +"','" + username + "','" + userdept
                                + "',to_date('" + nowtime + "','yyyy/mm/dd HH24:MI:SS'),'"+ filebelong + "','删除')";
                    OperateUser(delestr);
                }
                Response.Write("<script languge='javascript'>location.replace('./ShuiGongErSuoDocSpace.aspx?deptid=" + deptid + "');</script>");
                return;
            }

            //判断能否上传
            bool canload = false;
            string sqlstr = "SELECT " + pername + " FROM PERMISSION WHERE USERID = " + Request.Cookies["userId"].Value;
            DataSet userperds = QuaryUser(sqlstr);
            if (userperds.Tables[0].Rows.Count > 0)
            {
                if (userperds.Tables[0].Rows[0][pername].ToString() == "1" || userperds.Tables[0].Rows[0][pername].ToString() == "2")
                    canload = true;
            }
            if (canload == false)
            {
                loadupload.InnerHtml = "<tr><td colspan=\"2\">无上传权限</td></tr>";
            }
            //ProjectFilesLoad(filetype, prosystemid);
            listPageDeptDiv.InnerHtml = "<iframe id=\"listfilepage\" frameborder=\"0\" width=\"100%\" height=\"600px\" src=\"./DeptFilesList.aspx?deptid=" + deptid + "\" onload=\"LoadHeight(this)\">抱歉！该页面不支持您的浏览器！</iframe>";
        }

        protected void btnSaveDeptFile_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //获取部门存储资料路径
                string deptid = Request.QueryString["deptid"];
                string deptstr = string.Empty;
                string deptdocpath = string.Empty;
                if (deptid == null)
                {
                    return;
                }
                else if (deptid == "sges")
                {
                    deptdocpath = @"E:\\Ourgis_ProjectFiles\\DeptFiles\\SGESDir\\";
                    deptstr = "水工建筑二所";
                }

                string sqlstr = string.Empty;
                
                string filename = FileUpload1.FileName;
                string pathToCheck = deptdocpath + filename;
                string tmpfilename = string.Empty;
                //已有相同文件名的文件，对此次上传文件重命名
                if (File.Exists(pathToCheck))
                {
                    int counter = 2;
                    while (File.Exists(pathToCheck))
                    {
                        tmpfilename = "(" + counter.ToString() + ")" + filename;
                        pathToCheck = deptdocpath + tmpfilename;
                        counter++;
                    }
                    filename = tmpfilename;
                }

                string docpathonly = deptdocpath;
                deptdocpath += filename;
                FileUpload1.SaveAs(deptdocpath);

                //增加新条目到对应的文件信息表
                sqlstr = "SELECT ID FROM DEPT_DOC ORDER BY ID DESC";
                DataSet fileinfods = QuaryUser(sqlstr);
                string fileidstr = string.Empty;
                if (fileinfods.Tables[0].Rows.Count > 0)
                {
                    fileidstr = (Convert.ToInt32(fileinfods.Tables[0].Rows[0]["ID"].ToString()) + 1).ToString();
                }
                else if (fileinfods.Tables[0].Rows.Count == 0)
                {
                    fileidstr = "1";
                }
                    
                string filedetail = filedetailinput.Value;
                sqlstr = "SELECT * FROM USERLIST WHERE ID = " + Request.Cookies["userId"].Value;
                DataSet userds = QuaryUser(sqlstr);
                string username = userds.Tables[0].Rows[0]["BYNAME"].ToString();
                string userdept = userds.Tables[0].Rows[0]["DEPARTMENT"].ToString();
                string uploadtime = DateTime.Now.ToLocalTime().ToString();//获取上传者信息及上传时间
                //文件大小
                FileInfo savefileinfo = new FileInfo(deptdocpath);
                string filesize = ((float)savefileinfo.Length / (1024 * 1024)).ToString("F2") + "M";//获取文件大小，以“M”为单位
                sqlstr = "INSERT INTO DEPT_DOC VALUES (" + fileidstr + ",'" + filedetail + "','" + filename + "','" + docpathonly
                            + "','" + username + "','" + userdept + "',to_date('" + uploadtime + "','yyyy/mm/dd HH24:MI:SS')"
                            + ",'" + filesize + "','" + deptstr + "')";
                OperateUser(sqlstr);
                    
                Response.Write("<script languge='javascript'>location.replace('./ShuiGongErSuoDocSpace.aspx?deptid=" + deptid + "');</script>");
                
            }
        }
    }
}