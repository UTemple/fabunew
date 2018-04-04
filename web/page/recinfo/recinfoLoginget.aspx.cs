using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;
using static tools.ConvertJson;

namespace web.page.recinfo
{
    public partial class recinfoLoginget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataSet ds = QuaryUser("SELECT * FROM LOGINREC ORDER BY LOGINTIME DESC");

            //Response.Clear();
            //Response.ContentEncoding = Encoding.UTF8;
            //Response.ContentType = "application/json";
            //Response.Write(ToJson(ds));
            //Response.Flush();
            //Response.End();

            string startTime = Request.QueryString["st"];
            string endTime = Request.QueryString["et"];
            string startTime_format = startTime + " 00:00:00";
            string endTime_format = endTime + " 23:59:59";
            string[] deptlist = { "院领导", "技术质量办", "经营部", "办公室", "财务科", "建筑景观所", "造价中心", "信息中心", "水工建筑一所", "水工建筑二所", "市政所", "机电给排水室", "规划所", "建设项目部", "岩土室", "测量室", "资源环境所", "智慧所", "第三方部门" };
            string jsonstr = "[";
            string sqlstr = "SELECT * FROM USERLIST WHERE DEPARTMENT = '";
            foreach (string tmpstr in deptlist)
            {
                DataSet userds = QuaryUser(sqlstr + tmpstr + "' ORDER BY NAME ASC");
                if (userds.Tables[0].Rows.Count > 0)
                {
                    jsonstr += "{\"DeptName\": \""+ tmpstr + "\",\"UserCount\": "+ userds.Tables[0].Rows.Count + ",\"DetailInfo\": [";
                    for (int i = 0; i < userds.Tables[0].Rows.Count; i++)
                    {
                        DataSet loginds;
                        if (startTime != null && startTime != string.Empty && endTime != null && endTime != string.Empty)
                        {
                            string sql = "SELECT * FROM LOGINREC WHERE NAME = '" + userds.Tables[0].Rows[i]["NAME"] + "' AND LOGINTIME >= to_date('" + startTime_format + "', 'yyyy/mm/dd HH24:MI:SS') AND LOGINTIME <= to_date('" + endTime_format + "', 'yyyy/mm/dd HH24:MI:SS') ORDER BY LOGINTIME DESC";
                            loginds = QuaryUser(sql);
                        }
                        else
                        {
                            loginds = QuaryUser("SELECT * FROM LOGINREC WHERE NAME = '" + userds.Tables[0].Rows[i]["NAME"] + "' ORDER BY LOGINTIME DESC");
                        }
                        if (loginds.Tables[0].Rows.Count > 0)
                        {
                            jsonstr += "{\"Name\": \"" + userds.Tables[0].Rows[i]["NAME"] + "\""
                                        + ",\"ByName\": \"" + userds.Tables[0].Rows[i]["BYNAME"] + "\""
                                        + ",\"LastIP\": \"" + loginds.Tables[0].Rows[0]["IP"] + "\""    //最近一次的登陆ip
                                        + ",\"LoginCnt\": " + loginds.Tables[0].Rows.Count
                                        + ",\"LastLoginTime\": \"" + loginds.Tables[0].Rows[0]["LOGINTIME"] + "\""
                                        + "},";
                        }
                        else
                        {
                            jsonstr += "{\"Name\": \"" + userds.Tables[0].Rows[i]["NAME"] + "\""
                                        + ",\"ByName\": \"" + userds.Tables[0].Rows[i]["BYNAME"] + "\""
                                        + ",\"LastIP\": \"\""    //最近一次的登陆ip为空
                                        + ",\"LoginCnt\": 0"
                                        + ",\"LastLoginTime\": \"\""
                                        + "},";
                        }
                        
                    }
                    //去除最后一个逗号
                    jsonstr = jsonstr.Remove(jsonstr.Length - 1, 1);
                    jsonstr += "]},";
                }
                else
                {
                    //该部门下不存在用户，忽略此部门
                }
            }
            //去除最后一个逗号
            jsonstr = jsonstr.Remove(jsonstr.Length - 1, 1);
            jsonstr += "]";
            Response.Write(jsonstr);
            Response.Flush();
            Response.End();
        }
    }
}