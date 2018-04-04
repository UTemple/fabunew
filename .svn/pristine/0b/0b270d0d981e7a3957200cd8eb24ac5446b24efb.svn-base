using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page.formpages
{
    public partial class drainageInfoSumget1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sumtypestr = Request.QueryString["sumtype"];
            string tablestr = Request.QueryString["table"];

            if (sumtypestr == null || sumtypestr != "2")    //默认是行政区方式统计
                sumtypestr = "DISTRICT";
            else sumtypestr = "OWNERDEPT";

            string sqlstr = string.Empty;
            if (tablestr == "PS_PIPE_ZY") //排水管道
            {
                sqlstr = "SELECT " + sumtypestr + ",sum(LENGTH) AS DATAVAL FROM PS_PIPE_ZY GROUP BY " + sumtypestr + " ORDER BY DATAVAL DESC";
            }
            else if (tablestr == "PS_CANAL_ZY") //排水沟渠
            {
                sqlstr = "SELECT " + sumtypestr + ",sum(LENGTH) AS DATAVAL FROM PS_CANAL_ZY GROUP BY " + sumtypestr + " ORDER BY DATAVAL DESC";
            }
            else if (tablestr == "PS_WELL_ZY") //窨井
            {
                sqlstr = "SELECT " + sumtypestr + ",count(*) AS DATAVAL FROM PS_WELL_ZY GROUP BY " + sumtypestr + " ORDER BY DATAVAL DESC";
            }
            else if (tablestr == "PS_COMB_ZY") //雨水口
            {
                sqlstr = "SELECT " + sumtypestr + ",count(*) AS DATAVAL FROM PS_COMB_ZY GROUP BY " + sumtypestr + " ORDER BY DATAVAL DESC";
            }

            DataSet infods = QuarySde(sqlstr);
            string jsonstr = "[";
            if (infods.Tables[0].Rows.Count > 0)
            {
                double unknown_data = 0d;
                double sum_data = 0d;
                foreach (DataRow tmprow in infods.Tables[0].Rows)
                {
                    if (tmprow[sumtypestr] == null || tmprow[sumtypestr].ToString().Length == 0)
                    {
                        unknown_data += Convert.ToDouble(tmprow["DATAVAL"]);
                    }
                    else
                    {
                        bool allspace = true;//判断名称是否全是空格
                        foreach (char tmpc in tmprow[sumtypestr].ToString())
                        {
                            if (tmpc != ' ')//不全都是空格
                            {
                                allspace = false;
                                break;
                            }
                        }
                        if (allspace == false)
                        {
                            jsonstr += "{\"SubTypeVal\": \"" + tmprow[sumtypestr].ToString() + "\",\"DataVal\": " + Convert.ToDouble(tmprow["DATAVAL"]).ToString("f2") + "},";
                        }
                        else unknown_data += Convert.ToDouble(tmprow["DATAVAL"]);
                    }
                    sum_data += Convert.ToDouble(tmprow["DATAVAL"]);
                }
                jsonstr += "{\"SubTypeVal\": \"未划分归属\",\"DataVal\": " + unknown_data.ToString("f2") + "},";
                jsonstr += "{\"SubTypeVal\": \"总计\",\"DataVal\": " + sum_data.ToString("f2") + "}]";
                Response.Write(jsonstr);
                Response.Flush();
                Response.End();
            }
        }
    }
}