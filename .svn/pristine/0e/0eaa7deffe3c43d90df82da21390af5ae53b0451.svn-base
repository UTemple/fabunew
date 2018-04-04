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
    public partial class drainageInfoSumget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string[] districtlist = {"白云区", "从化区", "番禺区", "海珠区", "花都区", "黄浦区", "荔湾区", "南沙区", "天河区", "越秀区", "增城区"};
            string[] attrlist = {"污水", "雨水", "雨污合流"};
            string[] pipediameterlist = { "管径≤300mm", "300mm<管径<600mm", "管径≥600mm" };
            string[] canalwidthlist = { "渠宽<1m", "1m≤渠宽<2m", "渠宽≥2m" };
            string[] uselist = { };

            string sumtypestr = Request.QueryString["sumtype"];
            string tablestr = Request.QueryString["Select2"];
            string selectstr = Request.QueryString["Select1"];
            //string jsonstr = "[";
            string jsonstr = string.Empty;

            if (sumtypestr == null || sumtypestr != "2")    //默认是行政区方式统计
                sumtypestr = "DISTRICT";
            else sumtypestr = "OWNERDEPT";

            string sqlstr = string.Empty;
            string sqlfieldstr = string.Empty;
            if (tablestr == "PS_PIPE_ZY") //排水管道
            {
                //sqlstr = "SELECT " + sumtypestr + ",sum(LENGTH) AS DATAVAL FROM PS_PIPE_ZY GROUP BY " + sumtypestr + " ORDER BY DATAVAL DESC";
                if (selectstr != "2" || selectstr ==null) //雨污类别
                {
                    jsonstr = GetAssignDataOfDrainage(tablestr, sumtypestr, "雨污");
                }
                else //管径
                {
                    jsonstr = GetAssignDataOfDrainage(tablestr, sumtypestr, "管径");
                }
            }
            else if (tablestr == "PS_CANAL_ZY") //排水沟渠
            {
                //sqlstr = "SELECT " + sumtypestr + ",sum(LENGTH) AS DATAVAL FROM PS_CANAL_ZY GROUP BY " + sumtypestr + " ORDER BY DATAVAL DESC";
                if (selectstr != "2" || selectstr == null) //雨污类别
                {
                    jsonstr = GetAssignDataOfDrainage(tablestr, sumtypestr, "雨污");
                }
                else //渠宽
                {
                    jsonstr = GetAssignDataOfDrainage(tablestr, sumtypestr, "渠宽");
                }
            }
            else if (tablestr == "PS_WELL_ZY") //窨井
            {
                sqlstr = "SELECT " + sumtypestr + ",count(*) AS DATAVAL FROM PS_WELL_ZY GROUP BY " + sumtypestr + " ORDER BY DATAVAL DESC";
            }
            else if (tablestr == "PS_COMB_ZY") //雨水口
            {
                sqlstr = "SELECT " + sumtypestr + ",count(*) AS DATAVAL FROM PS_COMB_ZY GROUP BY " + sumtypestr + " ORDER BY DATAVAL DESC";
            }
            
            Response.Write(jsonstr);
            Response.Flush();
            Response.End();
        }

        string GetAssignDataOfDrainage(string tablename, string sumtype, string condtype)//要查的表名，统计类型：行政区或权属单位，数据分类条件：按雨污或按管径或按渠宽等
        {
            if (tablename == null || tablename.Length == 0 || sumtype == null || sumtype.Length == 0)
            {
                Console.WriteLine("drainageInfoSumget.aspx.cs:GetAssignDataOfDrainage, input param error!");
                return string.Empty;
            }

            string jsonstr = "[";
            string sqlstr = "SELECT " + sumtype + ",";
            string[] conds = {"","",""};
            double unknown_data1 = 0d, unknown_data2 = 0d, unknown_data3 = 0d;
            double sum_data1 = 0d, sum_data2 = 0d, sum_data3 = 0d;
            if (condtype == "雨污")
            {
                conds[0] = "污水"; conds[1] = "雨水"; conds[2] = "雨污合流";
                sqlstr += "SORT,sum(LENGTH) AS DATAVAL FROM "+ tablename + " GROUP BY " + sumtype + ",SORT ORDER BY " + sumtype + " DESC";
                DataSet tmpds = QuarySde(sqlstr);
                if (tmpds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow tmprow in tmpds.Tables[0].Rows)
                    {
                        bool allspace = true;//判断名称是否全是空格
                        foreach (char tmpc in tmprow[sumtype].ToString())
                        {
                            if (tmpc != ' ')//不全都是空格
                            {
                                allspace = false;
                                break;
                            }
                        }
                        //统计总的数据
                        if (tmprow["SORT"].ToString() == conds[0])
                        {
                            sum_data1 += Convert.ToDouble(tmprow["DATAVAL"]);
                        }
                        else if (tmprow["SORT"].ToString() == conds[1])
                        {
                            sum_data2 += Convert.ToDouble(tmprow["DATAVAL"]);
                        }
                        else if (tmprow["SORT"].ToString() == conds[2])
                        {
                            sum_data3 += Convert.ToDouble(tmprow["DATAVAL"]);
                        }

                        if (tmprow[sumtype] == null || tmprow[sumtype].ToString().Length == 0 || allspace == true)
                        {
                            //统计行政区或权属单位为空的数据
                            if (tmprow["SORT"].ToString() == conds[0])
                            {
                                unknown_data1 += Convert.ToDouble(tmprow["DATAVAL"]);
                            }
                            else if (tmprow["SORT"].ToString() == conds[1])
                            {
                                unknown_data2 += Convert.ToDouble(tmprow["DATAVAL"]);
                            }
                            else if (tmprow["SORT"].ToString() == conds[2])
                            {
                                unknown_data3 += Convert.ToDouble(tmprow["DATAVAL"]);
                            }
                        }
                        else
                        {
                            if (allspace == false)
                            {
                                jsonstr += "{\"SubTypeVal\": \"" + tmprow[sumtype].ToString() + "\",\"SubType2Val\": \"" + tmprow["SORT"].ToString() + "\",\"DataVal\": " + Convert.ToDouble(tmprow["DATAVAL"]).ToString("f2") + "},";
                            }
                        }
                    }
                }
            }
            else if (tablename == "PS_PIPE_ZY")
            {
                //if (condtype == "雨污")
                //{
                //    conds[0] = "污水"; conds[1] = "雨水"; conds[2] = "雨污合流";
                //    sqlstr += "SORT,sum(LENGTH) AS DATAVAL FROM PS_PIPE_ZY GROUP BY " + sumtype + ",SORT ORDER BY " + sumtype + " DESC";
                //    DataSet tmpds = QuarySde(sqlstr);
                //    if (tmpds.Tables[0].Rows.Count > 0)
                //    {
                //        foreach (DataRow tmprow in tmpds.Tables[0].Rows)
                //        {
                //            bool allspace = true;//判断名称是否全是空格
                //            foreach (char tmpc in tmprow[sumtype].ToString())
                //            {
                //                if (tmpc != ' ')//不全都是空格
                //                {
                //                    allspace = false;
                //                    break;
                //                }
                //            }
                //            //统计总的数据
                //            if (tmprow["SORT"].ToString() == conds[0])
                //            {
                //                sum_data1 += Convert.ToDouble(tmprow["DATAVAL"]);
                //            }
                //            else if (tmprow["SORT"].ToString() == conds[1])
                //            {
                //                sum_data2 += Convert.ToDouble(tmprow["DATAVAL"]);
                //            }
                //            else if (tmprow["SORT"].ToString() == conds[2])
                //            {
                //                sum_data3 += Convert.ToDouble(tmprow["DATAVAL"]);
                //            }

                //            if (tmprow[sumtype] == null || tmprow[sumtype].ToString().Length == 0 || allspace == true)
                //            {
                //                //统计行政区或权属单位为空的数据
                //                if (tmprow["SORT"].ToString() == conds[0])
                //                {
                //                    unknown_data1 += Convert.ToDouble(tmprow["DATAVAL"]);
                //                }
                //                else if (tmprow["SORT"].ToString() == conds[1])
                //                {
                //                    unknown_data2 += Convert.ToDouble(tmprow["DATAVAL"]);
                //                }
                //                else if (tmprow["SORT"].ToString() == conds[2])
                //                {
                //                    unknown_data3 += Convert.ToDouble(tmprow["DATAVAL"]);
                //                }
                //            }
                //            else
                //            {
                //                if (allspace == false)
                //                {
                //                    jsonstr += "{\"SubTypeVal\": \"" + tmprow[sumtype].ToString() + "\",\"SubType2Val\": \"" + tmprow["SORT"].ToString() + "\",\"DataVal\": " + Convert.ToDouble(tmprow["DATAVAL"]).ToString("f2") + "},";
                //                }
                //            }
                //        }
                //    }
                //}
                /*else*/ if (condtype == "管径")
                {
                    conds[0] = "管径≤300mm"; conds[1] = "300mm<管径<600mm"; conds[2] = "管径≥600mm";
                    sqlstr += "sum(case when D_S<= '300' or D_S = '' or D_S is null then LENGTH else 0 end) as SUM1" +
                        ",sum(case when D_S > '300' and D_S < '600' then LENGTH else 0 end) as SUM2" +
                        ",sum(case when D_S >= '600' then LENGTH else 0 end) as SUM3 from " + tablename + " group by " + sumtype + " ORDER BY " + sumtype + " DESC";
                    DataSet tmpds = QuarySde(sqlstr);
                    if (tmpds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow tmprow in tmpds.Tables[0].Rows)
                        {
                            bool allspace = true;//判断名称是否全是空格
                            foreach (char tmpc in tmprow[sumtype].ToString())
                            {
                                if (tmpc != ' ')//不全都是空格
                                {
                                    allspace = false;
                                    break;
                                }
                            }
                            sum_data1 += Convert.ToDouble(tmprow["SUM1"]);
                            sum_data2 += Convert.ToDouble(tmprow["SUM2"]);
                            sum_data3 += Convert.ToDouble(tmprow["SUM3"]);
                            if (tmprow[sumtype] == null || tmprow[sumtype].ToString().Length == 0 || allspace == true)
                            {
                                //统计行政区或权属单位为空的数据
                                unknown_data1 += Convert.ToDouble(tmprow["SUM1"]);
                                unknown_data2 += Convert.ToDouble(tmprow["SUM2"]);
                                unknown_data3 += Convert.ToDouble(tmprow["SUM3"]);
                            }
                            else
                            {
                                if (allspace == false)
                                {
                                    jsonstr += "{\"SubTypeVal\": \"" + tmprow[sumtype].ToString() + "\",\"SubType2Val\": \"" + conds[0] + "\",\"DataVal\": " + Convert.ToDouble(tmprow["SUM1"]).ToString("f2") + "},";
                                    jsonstr += "{\"SubTypeVal\": \"" + tmprow[sumtype].ToString() + "\",\"SubType2Val\": \"" + conds[1] + "\",\"DataVal\": " + Convert.ToDouble(tmprow["SUM2"]).ToString("f2") + "},";
                                    jsonstr += "{\"SubTypeVal\": \"" + tmprow[sumtype].ToString() + "\",\"SubType2Val\": \"" + conds[2] + "\",\"DataVal\": " + Convert.ToDouble(tmprow["SUM3"]).ToString("f2") + "},";
                                }
                            }
                        }

                    }
                }
            }
            else if (tablename == "PS_CANAL_ZY")
            {
                if (condtype == "渠宽")
                {
                    conds[0] = "渠宽<1m"; conds[1] = "1m≤渠宽<2m"; conds[2] = "渠宽≥2m";
                    sqlstr += "sum(case when WIDTH< '1' or WIDTH = '' or WIDTH is null then LENGTH else 0 end) as SUM1" +
                        ",sum(case when WIDTH >= '1' and WIDTH < '2' then LENGTH else 0 end) as SUM2" +
                        ",sum(case when WIDTH >= '2' then LENGTH else 0 end) as SUM3 from " + tablename + " group by " + sumtype + " ORDER BY " + sumtype + " DESC";
                    DataSet tmpds = QuarySde(sqlstr);
                    if (tmpds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow tmprow in tmpds.Tables[0].Rows)
                        {
                            bool allspace = true;//判断名称是否全是空格
                            foreach (char tmpc in tmprow[sumtype].ToString())
                            {
                                if (tmpc != ' ')//不全都是空格
                                {
                                    allspace = false;
                                    break;
                                }
                            }
                            sum_data1 += Convert.ToDouble(tmprow["SUM1"]);
                            sum_data2 += Convert.ToDouble(tmprow["SUM2"]);
                            sum_data3 += Convert.ToDouble(tmprow["SUM3"]);
                            if (tmprow[sumtype] == null || tmprow[sumtype].ToString().Length == 0 || allspace == true)
                            {
                                //统计行政区或权属单位为空的数据
                                unknown_data1 += Convert.ToDouble(tmprow["SUM1"]);
                                unknown_data2 += Convert.ToDouble(tmprow["SUM2"]);
                                unknown_data3 += Convert.ToDouble(tmprow["SUM3"]);
                            }
                            else
                            {
                                if (allspace == false)
                                {
                                    jsonstr += "{\"SubTypeVal\": \"" + tmprow[sumtype].ToString() + "\",\"SubType2Val\": \"" + conds[0] + "\",\"DataVal\": " + Convert.ToDouble(tmprow["SUM1"]).ToString("f2") + "},";
                                    jsonstr += "{\"SubTypeVal\": \"" + tmprow[sumtype].ToString() + "\",\"SubType2Val\": \"" + conds[1] + "\",\"DataVal\": " + Convert.ToDouble(tmprow["SUM2"]).ToString("f2") + "},";
                                    jsonstr += "{\"SubTypeVal\": \"" + tmprow[sumtype].ToString() + "\",\"SubType2Val\": \"" + conds[2] + "\",\"DataVal\": " + Convert.ToDouble(tmprow["SUM3"]).ToString("f2") + "},";
                                }
                            }
                        }

                    }
                }
            }
            jsonstr += "{\"SubTypeVal\": \"未划分归属\",\"SubType2Val\": \"" + conds[0] + "\",\"DataVal\": " + unknown_data1.ToString("f2") + "},";
            jsonstr += "{\"SubTypeVal\": \"未划分归属\",\"SubType2Val\": \"" + conds[1] + "\",\"DataVal\": " + unknown_data2.ToString("f2") + "},";
            jsonstr += "{\"SubTypeVal\": \"未划分归属\",\"SubType2Val\": \"" + conds[2] + "\",\"DataVal\": " + unknown_data3.ToString("f2") + "},";
            jsonstr += "{\"SubTypeVal\": \"未划分归属\",\"SubType2Val\": \"小计\",\"DataVal\": " + (unknown_data1+ unknown_data2+ unknown_data3).ToString("f2") + "},";
            jsonstr += "{\"SubTypeVal\": \"总计\",\"SubType2Val\": \"" + conds[0] + "\",\"DataVal\": " + sum_data1.ToString("f2") + "},";
            jsonstr += "{\"SubTypeVal\": \"总计\",\"SubType2Val\": \"" + conds[1] + "\",\"DataVal\": " + sum_data2.ToString("f2") + "},";
            jsonstr += "{\"SubTypeVal\": \"总计\",\"SubType2Val\": \"" + conds[2] + "\",\"DataVal\": " + sum_data3.ToString("f2") + "},";
            jsonstr += "{\"SubTypeVal\": \"总计\",\"SubType2Val\": \"小计\",\"DataVal\": " + (sum_data1+ sum_data2+ sum_data3).ToString("f2") + "}]";
            return jsonstr;
        }
    }
}