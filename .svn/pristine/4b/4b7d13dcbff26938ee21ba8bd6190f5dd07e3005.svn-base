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
    public partial class cloudDisk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCloudSaveFile_Click(object sender, EventArgs e)
        {
            //查找接收人是否存在
            string sqluser = "SELECT * FROM USERLIST WHERE BYNAME = '" + ReciverInfo.Text + "'";
            DataSet recUserInfoDs = QuaryUser(sqluser);
            if (recUserInfoDs.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script languge='javascript'>alert('找不到该用户！');</script>");
                return;
            }
            sqluser = "SELECT * FROM USERLIST WHERE ID = " + Request.Cookies["userId"].Value;
            DataSet sendUserInfoDs = QuaryUser(sqluser);
            if (sendUserInfoDs.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script languge='javascript'>alert('请先登录！');</script>");
                return;
            }

            if (FileUpload1.HasFile)
            {
                //临时创建一个存储路径，当接收者下载完毕后删除
                string savePath = @"E:\\Ourgis_ProjectFiles\\CloudDiskFolder\\" + Guid.NewGuid().ToString() + "\\\\";
                string saveSqlPath = savePath;
                Directory.CreateDirectory(savePath);
                if (!Directory.Exists(savePath))
                {
                    Response.Write("<script languge='javascript'>alert('创建临时存储文件夹出错！');</script>");
                    return;
                }
                
                string filename = FileUpload1.FileName;
                //string pathToCheck = savePath + filename;
                //string tmpfilename = string.Empty;
                //已有相同文件名的文件，对此次上传文件重命名
                //if (File.Exists(pathToCheck))
                //{
                //    int counter = 2;
                //    while (File.Exists(pathToCheck))
                //    {
                //        tmpfilename = "(" + counter.ToString() + ")" + filename;
                //        pathToCheck = savePath + tmpfilename;
                //        counter++;
                //    }
                //    filename = tmpfilename;
                //}

                savePath += filename;
                FileUpload1.SaveAs(savePath);

                //增加新条目到CLOUDDISK表
                DataSet idDs = QuaryUser("SELECT ID FROM CLOUDDISK ORDER BY ID DESC");
                string idstr = "1";
                if (idDs.Tables[0].Rows.Count > 0)
                {
                    idstr = (Convert.ToInt32(idDs.Tables[0].Rows[0]["ID"].ToString()) + 1).ToString();
                }
                FileInfo savefileinfo = new FileInfo(savePath);
                string filesize = ((float)savefileinfo.Length / (1024 * 1024)).ToString("F2") + "M";//获取文件大小，以“M”为单位
                string nowtime = DateTime.Now.ToLocalTime().ToString();
                string sqlstr = "INSERT INTO CLOUDDISK VALUES (" + idstr + ",'" + sendUserInfoDs.Tables[0].Rows[0]["BYNAME"]
                                                                    + "','" + recUserInfoDs.Tables[0].Rows[0]["BYNAME"]
                                                                    + "','" + filename + "','" + saveSqlPath
                                                                    + "','" + filesize + "',to_date('" + nowtime + "','yyyy/mm/dd HH24:MI:SS')"
                                                                    + ", 0)";   //下载状态为0，表示没被下载
                OperateUser(sqlstr);
                    
                Response.Write("<script languge='javascript'>location.replace('./cloudDisk.aspx');</script>");
            }
        }
    }
}