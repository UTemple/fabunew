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
    public partial class DeptFilesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string deptidstr = Request.QueryString["deptid"];
            string pernamestr = string.Empty;
            if (deptidstr == "sges")
            {
                deptidstr = "水工建筑二所";
                pernamestr = "SGESDOC";
            }
            DeptFilesLoad(deptidstr, pernamestr);
        }
        protected void DeptFilesLoad(string deptid, string pername)
        {
            string sqlstr = string.Empty;
            sqlstr = "SELECT * FROM DEPT_DOC WHERE DOCBELONGDEPT = '" + deptid + "' ORDER BY FILENAME ASC";

            DataSet fileds = QuaryUser(sqlstr);
            if (fileds.Tables[0].Rows.Count > 0)
            {
                //判断能否让用户下载，删除文件
                string buttonstr = "<td>无操作权限</td>";
                string sqluserstr = "SELECT "+ pername + " FROM PERMISSION WHERE USERID = " + Request.Cookies["userId"].Value;
                DataSet userperds = QuaryUser(sqluserstr);

                foreach (DataRow temprow in fileds.Tables[0].Rows)
                {
                    if (userperds.Tables[0].Rows[0][pername].ToString() == "1")//只能下载，不能删除
                        buttonstr = "<td><a class=\"layui-btn downloadfile\" data-id=\"" + temprow["ID"].ToString() + "\" >下载</a></td>";
                    else if (userperds.Tables[0].Rows[0][pername].ToString() == "2")//能下载，删除
                        buttonstr = "<td><a class=\"layui-btn downloadfile\" data-id=\"" + temprow["ID"].ToString() + "\" >下载</a>"
                                            + "<a class=\"layui-btn layui-btn-danger deletefile\" data-id=\"" + temprow["ID"].ToString() + "\" >删除</a></td>";
                    files_content.InnerHtml += "<tr>"
                                                    + "<td>" + temprow["FILENAME"].ToString() + "</td>"
                                                    + "<td>" + temprow["NAME"].ToString() + "</td>"
                                                    + "<td>" + temprow["FILESIZE"].ToString() + "</td>"
                                                    + "<td>" + temprow["UPLOAD_PERSON"].ToString() + "</td>"
                                                    + "<td>" + temprow["UPLOAD_DEPT"].ToString() + "</td>"
                                                    + "<td>" + temprow["UPLOAD_TIME"].ToString() + "</td>"
                                                    + buttonstr
                                               + "</tr>";
                }
            }
            else files_content.InnerHtml = "<tr><td colspan=\"7\">暂无数据</td></tr>";
        }
    }
}