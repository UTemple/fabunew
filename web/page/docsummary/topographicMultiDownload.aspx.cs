using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page.docsummary
{
    public partial class topographicMultiDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

            string fileNames = Request.QueryString["fnames"];
            if (fileNames.IndexOf(',') != -1)
            {
                string[] filenamearray = fileNames.Split(',');
                foreach (string namestr in filenamearray)
                {
                    topomultidlDiv.InnerHtml += "<iframe src=\"topographicDownload.aspx?fname=" + namestr + "\" style=\"display:none\"></iframe>";
                }
            }
            return;
        }

        protected void LayuiMsg(string msg)
        {
            topomultidlDiv.InnerHtml = "<script>layui.use('layer', function(){var layer = layui.layer;layer.msg('" + msg
                                      + "', {icon: 7,time: 5000,area: '300',btnAlign: 'c',btn: ['确认']}, function(){window.close();});});</script>";
        }
    }
}