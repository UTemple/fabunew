using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page.coordinateconvert
{
    public partial class WGSConvert2GZTempletDl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string infullpathstr = Request.QueryString["filefullpath"];
            string infilenamestr = Request.QueryString["filename"];
            if(infullpathstr !=null && infullpathstr.Length > 0 && infilenamestr!=null && infilenamestr.Length > 0)
            {
                DownLoadTheFile("转换后-"+infilenamestr, infullpathstr);
                Directory.Delete(infullpathstr.Substring(0, (infullpathstr.Length - infilenamestr.Length)),true);
            }
            else //下载模板
            {
                string fileName = "坐标转换文件模板.xlsx";//显示给客户端文件名

                string filePath = "";//路径
                DataTable filepathtb = QuaryExcel("SELECT FILEPATH FROM [GLOBALCONFIG$]").Tables[0];
                if (filepathtb.Rows.Count > 0)
                {
                    filePath = filepathtb.Rows[0]["FILEPATH"].ToString();
                }
                filePath += "CoordinateConvert\\";
                string fileFullPath = filePath + fileName;

                DownLoadTheFile(fileName, fileFullPath);
            }
            Response.End();
        }

        protected void DownLoadTheFile(string filename, string filefullpath)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filefullpath);

            if (fileInfo.Exists == true)
            {
                const long ChunkSize = 102400;//100K 每次读取文件，只读取100K，这样可以缓解服务器的压力
                byte[] buffer = new byte[ChunkSize];

                Response.Clear();
                System.IO.FileStream iStream = System.IO.File.OpenRead(filefullpath);
                long dataLengthToRead = iStream.Length;//获取下载的文件总大小
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(filename));
                Response.AddHeader("Content-Length", dataLengthToRead.ToString());
                while (dataLengthToRead > 0 && Response.IsClientConnected)
                {
                    int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
                    Response.OutputStream.Write(buffer, 0, lengthRead);
                    Response.Flush();
                    dataLengthToRead = dataLengthToRead - lengthRead;
                }
                iStream.Close();
            }
            else
            {
                LayuiMsg("服务器中没有找到"+ filename + "，请联系管理人员！");
            }
        }

        protected void LayuiMsg(string msg)
        {
            retdiv.InnerHtml = "<script>layui.use('layer', function(){var layer = layui.layer;layer.msg('" + msg
                                      + "', {icon: 7,time: 5000,area: '300',btnAlign: 'c',btn: ['确认']}, function(){window.close();});});</script>";
        }
    }
}