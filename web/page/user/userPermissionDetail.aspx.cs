using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page.user
{
    public partial class userPermissionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO 操作者权限判断

            DataSet userperDs = QuaryUser("SELECT * FROM PERMISSION WHERE USERID = " + Request.QueryString["pa"].ToString());
            DataSet userinfoDs = QuaryUser("SELECT * FROM USERLIST WHERE ID = " + Request.QueryString["pa"].ToString());
            string issub = Request.QueryString["isSubmit"];
            string sqlstr = string.Empty;
            if (issub == "1")
            {
                string perstyle = Request.QueryString["perstyle"];
                if (perstyle == "1")//管理员
                {
                    sqlstr = "UPDATE PERMISSION SET USERCHANGE = 1,RIVER = 2,RECLOGIN = 1,HABIT = 1,BACKGROUND = 1,LAKE = 2,RESERVOIR = 2,DIKE = 2,PUMP = 2,SLUICE = 2,PROJECT = 2"
                            + ",SEWAGEFARM = 1,DRAINPUMP = 1,DRAINGATE = 1,RECDOWNLOAD = 1,TOPOGRAPHIC = 0,DRAINPAGE = 1,WATERPAGE = 1,RIVEROWNER = 1,RESERVOIROWNER = 1,LAKEOWNER = 1"
                            + ",INTERESTPOINT = 1,INTERESTMULTIPOINT = 1,INTERESTPOLYGON = 1,INTERESTPOLYLINE = 1,DRAINPIPE = 1,DRAINCANAL = 1,DRAINCOMB = 1,DRAINWELL = 1,SGESDOC = 2"
                            + " WHERE USERID = " + Request.QueryString["pa"].ToString();
                    OperateUser("UPDATE USERLIST SET PERMISSION = '管理员' WHERE ID = " + Request.QueryString["pa"].ToString());
                }
                else if (perstyle == "2")//高级用户
                {
                    sqlstr = "UPDATE PERMISSION SET USERCHANGE = 0,RIVER = 2,RECLOGIN = 0,HABIT = 0,BACKGROUND = 0,LAKE = 2,RESERVOIR = 2,DIKE = 2,PUMP = 2,SLUICE = 2,PROJECT = 2"
                            + ",SEWAGEFARM = 1,DRAINPUMP = 1,DRAINGATE = 1,RECDOWNLOAD = 0,TOPOGRAPHIC = 0,DRAINPAGE = 1,WATERPAGE = 1,RIVEROWNER = 1,RESERVOIROWNER = 1,LAKEOWNER = 1"
                            + ",INTERESTPOINT = 1,INTERESTMULTIPOINT = 1,INTERESTPOLYGON = 1,INTERESTPOLYLINE = 1,DRAINPIPE = 1,DRAINCANAL = 1,DRAINCOMB = 1,DRAINWELL = 1";
                    if (userinfoDs.Tables[0].Rows[0]["DEPARTMENT"].ToString() == "水工建筑二所")
                        sqlstr += ",SGESDOC = 2";
                    else sqlstr += ",SGESDOC = 0";
                    sqlstr += " WHERE USERID = " + Request.QueryString["pa"].ToString();
                    OperateUser("UPDATE USERLIST SET PERMISSION = '高级用户' WHERE ID = " + Request.QueryString["pa"].ToString());
                }
                else if (perstyle == "3")//普通用户
                {
                    sqlstr = "UPDATE PERMISSION SET USERCHANGE = 0,RIVER = 1,RECLOGIN = 0,HABIT = 0,BACKGROUND = 0,LAKE = 1,RESERVOIR = 1,DIKE = 1,PUMP = 1,SLUICE = 1,PROJECT = 1"
                            + ",SEWAGEFARM = 1,DRAINPUMP = 1,DRAINGATE = 1,RECDOWNLOAD = 0,TOPOGRAPHIC = 0,DRAINPAGE = 1,WATERPAGE = 1,RIVEROWNER = 1,RESERVOIROWNER = 1,LAKEOWNER = 1"
                            + ",INTERESTPOINT = 1,INTERESTMULTIPOINT = 1,INTERESTPOLYGON = 1,INTERESTPOLYLINE = 1,DRAINPIPE = 1,DRAINCANAL = 1,DRAINCOMB = 1,DRAINWELL = 1";
                    if (userinfoDs.Tables[0].Rows[0]["DEPARTMENT"].ToString() == "水工建筑二所")
                        sqlstr += ",SGESDOC = 1";
                    else sqlstr += ",SGESDOC = 0";
                    sqlstr += " WHERE USERID = " + Request.QueryString["pa"].ToString();
                    OperateUser("UPDATE USERLIST SET PERMISSION = '普通用户' WHERE ID = " + Request.QueryString["pa"].ToString());
                }
                else if (perstyle == "4")//外部用户
                {
                    sqlstr = "UPDATE PERMISSION SET USERCHANGE = 0,RIVER = 1,RECLOGIN = 0,HABIT = 0,BACKGROUND = 0,LAKE = 1,RESERVOIR = 1,DIKE = 1,PUMP = 1,SLUICE = 1,PROJECT = 0"
                            + ",SEWAGEFARM = 0,DRAINPUMP = 0,DRAINGATE = 0,RECDOWNLOAD = 0,TOPOGRAPHIC = 0,DRAINPAGE = 0,WATERPAGE = 1,RIVEROWNER = 0,RESERVOIROWNER = 0,LAKEOWNER = 0"
                            + ",INTERESTPOINT = 1,INTERESTMULTIPOINT = 1,INTERESTPOLYGON = 1,INTERESTPOLYLINE = 1,DRAINPIPE = 0,DRAINCANAL = 0,DRAINCOMB = 0,DRAINWELL = 0,SGESDOC = 0"
                            + " WHERE USERID = " + Request.QueryString["pa"].ToString();
                    OperateUser("UPDATE USERLIST SET PERMISSION = '外部用户' WHERE ID = " + Request.QueryString["pa"].ToString());
                }
                else if (perstyle == "5")//自定义
                {
                    string userswitch = Request.QueryString["userswitch"];
                    string recloginswitch = Request.QueryString["recloginswitch"];
                    string habitswitch = Request.QueryString["habitswitch"];
                    string recdlswitch = Request.QueryString["recdlswitch"];
                    string riverradio = Request.QueryString["riverradio"];
                    string riverownerradio = Request.QueryString["riverownerradio"];
                    string reservoirradio = Request.QueryString["reservoirradio"];
                    string reservoirownerradio = Request.QueryString["reservoirownerradio"];
                    string lakeradio = Request.QueryString["lakeradio"];
                    string pumpradio = Request.QueryString["pumpradio"];
                    string sluiceradio = Request.QueryString["sluiceradio"];
                    string lakeownerradio = Request.QueryString["lakeownerradio"];
                    string sewagefarmradio = Request.QueryString["sewagefarmradio"];
                    string drainpumpradio = Request.QueryString["drainpumpradio"];
                    string draingateradio = Request.QueryString["draingateradio"];
                    string drainpiperadio = Request.QueryString["drainpiperadio"];
                    //string draincanalradio = Request.QueryString["draincanalradio"];
                    string draincombradio = Request.QueryString["draincombradio"];
                    string drainwellradio = Request.QueryString["drainwellradio"];
                    string projectresultradio = Request.QueryString["projectresultradio"];
                    string topographicswitch = Request.QueryString["topographicswitch"];
                    string sgesdocradio = Request.QueryString["sgesdocradio"];
                    //后台管理
                    if (userswitch == "on")
                    {
                        userperDs.Tables[0].Rows[0]["USERCHANGE"] = "1";
                    }
                    else
                    {
                        userperDs.Tables[0].Rows[0]["USERCHANGE"] = "0";
                    }
                    if (recloginswitch == "on")
                    {
                        userperDs.Tables[0].Rows[0]["RECLOGIN"] = "1";
                    }
                    else
                    {
                        userperDs.Tables[0].Rows[0]["RECLOGIN"] = "0";
                    }
                    if (habitswitch == "on")
                    {
                        userperDs.Tables[0].Rows[0]["HABIT"] = "1";
                    }
                    else
                    {
                        userperDs.Tables[0].Rows[0]["HABIT"] = "0";
                    }
                    if (recdlswitch == "on")
                    {
                        userperDs.Tables[0].Rows[0]["RECDOWNLOAD"] = "1";
                    }
                    else
                    {
                        userperDs.Tables[0].Rows[0]["RECDOWNLOAD"] = "0";
                    }
                    if (userperDs.Tables[0].Rows[0]["USERCHANGE"].ToString() == "1" || userperDs.Tables[0].Rows[0]["RECLOGIN"].ToString() == "1"
                        || userperDs.Tables[0].Rows[0]["HABIT"].ToString() == "1" || userperDs.Tables[0].Rows[0]["RECDOWNLOAD"].ToString() == "1")
                    {
                        userperDs.Tables[0].Rows[0]["BACKGROUND"] = "1";//后台管理页面显示
                    }
                    else
                    {
                        userperDs.Tables[0].Rows[0]["BACKGROUND"] = "0";//取消后台管理页面显示
                    }
                    //水利
                    userperDs.Tables[0].Rows[0]["RIVER"] = riverradio;
                    userperDs.Tables[0].Rows[0]["RIVEROWNER"] = riverownerradio;
                    userperDs.Tables[0].Rows[0]["RESERVOIR"] = reservoirradio;
                    userperDs.Tables[0].Rows[0]["RESERVOIROWNER"] = reservoirownerradio;
                    userperDs.Tables[0].Rows[0]["LAKE"] = lakeradio;
                    userperDs.Tables[0].Rows[0]["PUMP"] = pumpradio;
                    userperDs.Tables[0].Rows[0]["SLUICE"] = sluiceradio;
                    userperDs.Tables[0].Rows[0]["LAKEOWNER"] = lakeownerradio;
                    if (riverradio != "0" || reservoirradio != "0" || pumpradio != "0" || sluiceradio != "0" || riverownerradio != "0" 
                        || reservoirownerradio != "0" || lakeradio != "0" || lakeownerradio != "0")
                    {
                        userperDs.Tables[0].Rows[0]["WATERPAGE"] = "1";//水利页面显示
                    }
                    else
                    {
                        userperDs.Tables[0].Rows[0]["WATERPAGE"] = "0";//取消水利页面显示
                    }
                    //排水
                    userperDs.Tables[0].Rows[0]["SEWAGEFARM"] = sewagefarmradio;
                    userperDs.Tables[0].Rows[0]["DRAINPUMP"] = drainpumpradio;
                    userperDs.Tables[0].Rows[0]["DRAINGATE"] = draingateradio;
                    userperDs.Tables[0].Rows[0]["DRAINPIPE"] = drainpiperadio;
                    //userperDs.Tables[0].Rows[0]["DRAINCANAL"] = draincanalradio;
                    userperDs.Tables[0].Rows[0]["DRAINCOMB"] = draincombradio;
                    userperDs.Tables[0].Rows[0]["DRAINWELL"] = drainwellradio;
                    if (sewagefarmradio == "1" || drainpumpradio == "1" || draingateradio == "1" || drainpiperadio == "1" /*|| draincanalradio == "1"*/ || draincombradio == "1" || drainwellradio == "1")
                    {
                        userperDs.Tables[0].Rows[0]["DRAINPAGE"] = "1";//排水页面显示
                    }
                    else
                    {
                        userperDs.Tables[0].Rows[0]["DRAINPAGE"] = "0";//取消排水页面显示
                    }
                    //项目资料管理
                    userperDs.Tables[0].Rows[0]["PROJECT"] = projectresultradio;
                    //地形图下载
                    if (topographicswitch == "on")
                    {
                        userperDs.Tables[0].Rows[0]["TOPOGRAPHIC"] = "1";
                    }
                    else
                    {
                        userperDs.Tables[0].Rows[0]["TOPOGRAPHIC"] = "0";
                    }
                    //部门文件
                    userperDs.Tables[0].Rows[0]["SGESDOC"] = sgesdocradio;

                    sqlstr = "UPDATE PERMISSION SET USERCHANGE = " + userperDs.Tables[0].Rows[0]["USERCHANGE"]
                                    + ",RIVER = " + userperDs.Tables[0].Rows[0]["RIVER"] + ",RECLOGIN = " + userperDs.Tables[0].Rows[0]["RECLOGIN"]
                                    + ",HABIT = " + userperDs.Tables[0].Rows[0]["HABIT"] + ",BACKGROUND = " + userperDs.Tables[0].Rows[0]["BACKGROUND"]
                                    + ",LAKE = " + userperDs.Tables[0].Rows[0]["LAKE"] + ",RESERVOIR = " + userperDs.Tables[0].Rows[0]["RESERVOIR"] 
                                    + ",PUMP = " + userperDs.Tables[0].Rows[0]["PUMP"] + ",SLUICE = " + userperDs.Tables[0].Rows[0]["SLUICE"] 
                                    + ",PROJECT = " + userperDs.Tables[0].Rows[0]["PROJECT"] + ",SEWAGEFARM = " + userperDs.Tables[0].Rows[0]["SEWAGEFARM"] 
                                    + ",DRAINPUMP = " + userperDs.Tables[0].Rows[0]["DRAINPUMP"] + ",DRAINGATE = " + userperDs.Tables[0].Rows[0]["DRAINGATE"] 
                                    + ",RECDOWNLOAD = " + userperDs.Tables[0].Rows[0]["RECDOWNLOAD"] + ",TOPOGRAPHIC = " + userperDs.Tables[0].Rows[0]["TOPOGRAPHIC"] 
                                    + ",DRAINPAGE = " + userperDs.Tables[0].Rows[0]["DRAINPAGE"] + ",WATERPAGE = " + userperDs.Tables[0].Rows[0]["WATERPAGE"] 
                                    + ",RIVEROWNER = " + userperDs.Tables[0].Rows[0]["RIVEROWNER"] + ",RESERVOIROWNER = " + userperDs.Tables[0].Rows[0]["RESERVOIROWNER"] 
                                    + ",LAKEOWNER = " + userperDs.Tables[0].Rows[0]["LAKEOWNER"] + ",DRAINPIPE = " + userperDs.Tables[0].Rows[0]["DRAINPIPE"]
                                    /*+ ",DRAINCANAL = " + userperDs.Tables[0].Rows[0]["DRAINCANAL"]*/ + ",DRAINCOMB = " + userperDs.Tables[0].Rows[0]["DRAINCOMB"]
                                    + ",DRAINWELL = " + userperDs.Tables[0].Rows[0]["DRAINWELL"] + ",SGESDOC = " + userperDs.Tables[0].Rows[0]["SGESDOC"]
                                    + " WHERE USERID = " + Request.QueryString["pa"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('权限设定选择错误！');</script>");
                }
                OperateUser(sqlstr);
                Response.Write("<script>window.location.href = \"userManager.aspx\";</script>");
            }
            else //显示原本的权限
            {
                paDiv.InnerHtml = "<input type=\"text\" name=\"pa\" value=\"" + Request.QueryString["pa"].ToString() + "\" style=\"display:none\" />";
                DataSet usernameDs = QuaryUser("SELECT BYNAME FROM USERLIST WHERE ID = " + Request.QueryString["pa"].ToString());
                if (usernameDs.Tables[0].Rows.Count > 0) //显示账号名字
                {
                    userNameDiv.InnerHtml = "<input type=\"text\" value=\"" + usernameDs.Tables[0].Rows[0]["BYNAME"].ToString() + "\" disabled class=\"layui-input layui-disabled\" />";
                }
                if (userperDs.Tables[0].Rows.Count > 0)
                {
                    //用户管理权限
                    if (userperDs.Tables[0].Rows[0]["USERCHANGE"].ToString() == "1")
                    {
                        userDiv.InnerHtml = "<input type=\"checkbox\" name=\"userswitch\" disabled lay-skin=\"switch\" lay-text=\"开启|关闭\" checked />";
                    }
                    else {
                        userDiv.InnerHtml = "<input type=\"checkbox\" name=\"userswitch\" disabled lay-skin=\"switch\" lay-text=\"开启|关闭\" />";
                    }
                    //登陆记录权限
                    if (userperDs.Tables[0].Rows[0]["RECLOGIN"].ToString() == "1")
                    {
                        recloginDiv.InnerHtml = "<input type=\"checkbox\" name=\"recloginswitch\" disabled lay-skin=\"switch\" lay-text=\"开启|关闭\" checked />";
                    }
                    else
                    {
                        recloginDiv.InnerHtml = "<input type=\"checkbox\" name=\"recloginswitch\" disabled lay-skin=\"switch\" lay-text=\"开启|关闭\" />";
                    }
                    //操作习惯记录权限
                    if (userperDs.Tables[0].Rows[0]["HABIT"].ToString() == "1")
                    {
                        rechabitDiv.InnerHtml = "<input type=\"checkbox\" name=\"habitswitch\" disabled lay-skin=\"switch\" lay-text=\"开启|关闭\" checked />";
                    }
                    else
                    {
                        rechabitDiv.InnerHtml = "<input type=\"checkbox\" name=\"habitswitch\" disabled lay-skin=\"switch\" lay-text=\"开启|关闭\" />";
                    }
                    //下载记录权限
                    if (userperDs.Tables[0].Rows[0]["RECDOWNLOAD"].ToString() == "1")
                    {
                        recdownloadDiv.InnerHtml = "<input type=\"checkbox\" name=\"recdlswitch\" disabled lay-skin=\"switch\" lay-text=\"开启|关闭\" checked />";
                    }
                    else
                    {
                        recdownloadDiv.InnerHtml = "<input type=\"checkbox\" name=\"recdlswitch\" disabled lay-skin=\"switch\" lay-text=\"开启|关闭\" />";
                    }
                    //河流查看和编辑权限
                    if (userperDs.Tables[0].Rows[0]["RIVER"].ToString() == "0")
                    {
                        riverDiv.InnerHtml = "<input type=\"radio\" name=\"riverradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"riverradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"riverradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["RIVER"].ToString() == "1")
                    {
                        riverDiv.InnerHtml = "<input type=\"radio\" name=\"riverradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"riverradio\" disabled value=\"1\" title=\"读取\" checked />" +
                                             "<input type=\"radio\" name=\"riverradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["RIVER"].ToString() == "2")
                    {
                        riverDiv.InnerHtml = "<input type=\"radio\" name=\"riverradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"riverradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"riverradio\" disabled value=\"2\" title=\"编辑\" checked />";
                    }
                    //河流河长查看权限
                    if (userperDs.Tables[0].Rows[0]["RIVEROWNER"].ToString() == "0")
                    {
                        riverownerDiv.InnerHtml = "<input type=\"radio\" name=\"riverownerradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"riverownerradio\" disabled value=\"1\" title=\"读取\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["RIVEROWNER"].ToString() == "1")
                    {
                        riverownerDiv.InnerHtml = "<input type=\"radio\" name=\"riverownerradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"riverownerradio\" disabled value=\"1\" title=\"读取\" checked />";
                    }
                    //水库查看和编辑权限
                    if (userperDs.Tables[0].Rows[0]["RESERVOIR"].ToString() == "0")
                    {
                        reservoirDiv.InnerHtml = "<input type=\"radio\" name=\"reservoirradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"reservoirradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"reservoirradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["RESERVOIR"].ToString() == "1")
                    {
                        reservoirDiv.InnerHtml = "<input type=\"radio\" name=\"reservoirradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"reservoirradio\" disabled value=\"1\" title=\"读取\" checked />" +
                                             "<input type=\"radio\" name=\"reservoirradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["RESERVOIR"].ToString() == "2")
                    {
                        reservoirDiv.InnerHtml = "<input type=\"radio\" name=\"reservoirradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"reservoirradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"reservoirradio\" disabled value=\"2\" title=\"编辑\" checked />";
                    }
                    //水库河长查看权限
                    if (userperDs.Tables[0].Rows[0]["RESERVOIROWNER"].ToString() == "0")
                    {
                        reservoirownerDiv.InnerHtml = "<input type=\"radio\" name=\"reservoirownerradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"reservoirownerradio\" disabled value=\"1\" title=\"读取\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["RESERVOIROWNER"].ToString() == "1")
                    {
                        reservoirownerDiv.InnerHtml = "<input type=\"radio\" name=\"reservoirownerradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"reservoirownerradio\" disabled value=\"1\" title=\"读取\" checked />";
                    }
                    //湖泊查看和编辑权限
                    if (userperDs.Tables[0].Rows[0]["LAKE"].ToString() == "0")
                    {
                        lakeDiv.InnerHtml = "<input type=\"radio\" name=\"lakeradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"lakeradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"lakeradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["LAKE"].ToString() == "1")
                    {
                        lakeDiv.InnerHtml = "<input type=\"radio\" name=\"lakeradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"lakeradio\" disabled value=\"1\" title=\"读取\" checked />" +
                                             "<input type=\"radio\" name=\"lakeradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["LAKE"].ToString() == "2")
                    {
                        lakeDiv.InnerHtml = "<input type=\"radio\" name=\"lakeradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"lakeradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"lakeradio\" disabled value=\"2\" title=\"编辑\" checked />";
                    }
                    //泵站查看和编辑权限
                    if (userperDs.Tables[0].Rows[0]["PUMP"].ToString() == "0")
                    {
                        pumpDiv.InnerHtml = "<input type=\"radio\" name=\"pumpradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"pumpradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"pumpradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["PUMP"].ToString() == "1")
                    {
                        pumpDiv.InnerHtml = "<input type=\"radio\" name=\"pumpradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"pumpradio\" disabled value=\"1\" title=\"读取\" checked />" +
                                             "<input type=\"radio\" name=\"pumpradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["PUMP"].ToString() == "2")
                    {
                        pumpDiv.InnerHtml = "<input type=\"radio\" name=\"pumpradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"pumpradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"pumpradio\" disabled value=\"2\" title=\"编辑\" checked />";
                    }
                    //水闸查看和编辑权限
                    if (userperDs.Tables[0].Rows[0]["SLUICE"].ToString() == "0")
                    {
                        sluiceDiv.InnerHtml = "<input type=\"radio\" name=\"sluiceradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"sluiceradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"sluiceradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["SLUICE"].ToString() == "1")
                    {
                        sluiceDiv.InnerHtml = "<input type=\"radio\" name=\"sluiceradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"sluiceradio\" disabled value=\"1\" title=\"读取\" checked />" +
                                             "<input type=\"radio\" name=\"sluiceradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["SLUICE"].ToString() == "2")
                    {
                        sluiceDiv.InnerHtml = "<input type=\"radio\" name=\"sluiceradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"sluiceradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"sluiceradio\" disabled value=\"2\" title=\"编辑\" checked />";
                    }
                    //湖泊河长查看权限
                    if (userperDs.Tables[0].Rows[0]["LAKEOWNER"].ToString() == "0")
                    {
                        lakeownerDiv.InnerHtml = "<input type=\"radio\" name=\"lakeownerradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"lakeownerradio\" disabled value=\"1\" title=\"读取\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["LAKEOWNER"].ToString() == "1")
                    {
                        lakeownerDiv.InnerHtml = "<input type=\"radio\" name=\"lakeownerradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"lakeownerradio\" disabled value=\"1\" title=\"读取\" checked />";
                    }
                    //污水处理厂查看权限，编辑权限TODO
                    if (userperDs.Tables[0].Rows[0]["SEWAGEFARM"].ToString() == "0")
                    {
                        sewagefarmDiv.InnerHtml = "<input type=\"radio\" name=\"sewagefarmradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"sewagefarmradio\" disabled value=\"1\" title=\"读取\" />";
                                             //+ "<input type=\"radio\" name=\"sewagefarmradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["SEWAGEFARM"].ToString() == "1")
                    {
                        sewagefarmDiv.InnerHtml = "<input type=\"radio\" name=\"sewagefarmradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"sewagefarmradio\" disabled value=\"1\" title=\"读取\" checked />";
                                             //+ "<input type=\"radio\" name=\"sewagefarmradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    /*else if (userperDs.Tables[0].Rows[0]["SEWAGEFARM"].ToString() == "2")
                    {
                        sewagefarmDiv.InnerHtml = "<input type=\"radio\" name=\"sewagefarmradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"sewagefarmradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"sewagefarmradio\" disabled value=\"2\" title=\"编辑\" checked />";
                    }*/
                    //排水泵站查看权限，编辑权限TODO
                    if (userperDs.Tables[0].Rows[0]["DRAINPUMP"].ToString() == "0")
                    {
                        drainpumpDiv.InnerHtml = "<input type=\"radio\" name=\"drainpumpradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"drainpumpradio\" disabled value=\"1\" title=\"读取\" />";
                                             //+ "<input type=\"radio\" name=\"drainpumpradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["DRAINPUMP"].ToString() == "1")
                    {
                        drainpumpDiv.InnerHtml = "<input type=\"radio\" name=\"drainpumpradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"drainpumpradio\" disabled value=\"1\" title=\"读取\" checked />";
                                             //+ "<input type=\"radio\" name=\"drainpumpradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    /*else if (userperDs.Tables[0].Rows[0]["DRAINPUMP"].ToString() == "2")
                    {
                        drainpumpDiv.InnerHtml = "<input type=\"radio\" name=\"drainpumpradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"drainpumpradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"drainpumpradio\" disabled value=\"2\" title=\"编辑\" checked />";
                    }*/
                    //排水水闸查看权限，编辑权限TODO
                    if (userperDs.Tables[0].Rows[0]["DRAINGATE"].ToString() == "0")
                    {
                        draingateDiv.InnerHtml = "<input type=\"radio\" name=\"draingateradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"draingateradio\" disabled value=\"1\" title=\"读取\" />";
                        //+ "<input type=\"radio\" name=\"draingateradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["DRAINGATE"].ToString() == "1")
                    {
                        draingateDiv.InnerHtml = "<input type=\"radio\" name=\"draingateradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"draingateradio\" disabled value=\"1\" title=\"读取\" checked />";
                        //+ "<input type=\"radio\" name=\"draingateradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    /*else if (userperDs.Tables[0].Rows[0]["DRAINGATE"].ToString() == "2")
                    {
                        draingateDiv.InnerHtml = "<input type=\"radio\" name=\"draingateradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"draingateradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"draingateradio\" disabled value=\"2\" title=\"编辑\" checked />";
                    }*/
                    //排水管道查看权限
                    if (userperDs.Tables[0].Rows[0]["DRAINPIPE"].ToString() == "0")
                    {
                        drainpipeDiv.InnerHtml = "<input type=\"radio\" name=\"drainpiperadio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"drainpiperadio\" disabled value=\"1\" title=\"读取\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["DRAINPIPE"].ToString() == "1")
                    {
                        drainpipeDiv.InnerHtml = "<input type=\"radio\" name=\"drainpiperadio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"drainpiperadio\" disabled value=\"1\" title=\"读取\" checked />";
                    }
                    //排水沟渠查看权限(和排水管道合为一个)
                    //if (userperDs.Tables[0].Rows[0]["DRAINCANAL"].ToString() == "0")
                    //{
                    //    draincanalDiv.InnerHtml = "<input type=\"radio\" name=\"draincanalradio\" disabled value=\"0\" title=\"无\" checked />" +
                    //                         "<input type=\"radio\" name=\"draincanalradio\" disabled value=\"1\" title=\"读取\" />";
                    //}
                    //else if (userperDs.Tables[0].Rows[0]["DRAINCANAL"].ToString() == "1")
                    //{
                    //    draincanalDiv.InnerHtml = "<input type=\"radio\" name=\"draincanalradio\" disabled value=\"0\" title=\"无\" />" +
                    //                         "<input type=\"radio\" name=\"draincanalradio\" disabled value=\"1\" title=\"读取\" checked />";
                    //}
                    //雨水口查看权限
                    if (userperDs.Tables[0].Rows[0]["DRAINCOMB"].ToString() == "0")
                    {
                        draincombDiv.InnerHtml = "<input type=\"radio\" name=\"draincombradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"draincombradio\" disabled value=\"1\" title=\"读取\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["DRAINCOMB"].ToString() == "1")
                    {
                        draincombDiv.InnerHtml = "<input type=\"radio\" name=\"draincombradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"draincombradio\" disabled value=\"1\" title=\"读取\" checked />";
                    }
                    //窨井查看权限
                    if (userperDs.Tables[0].Rows[0]["DRAINWELL"].ToString() == "0")
                    {
                        drainwellDiv.InnerHtml = "<input type=\"radio\" name=\"drainwellradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"drainwellradio\" disabled value=\"1\" title=\"读取\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["DRAINWELL"].ToString() == "1")
                    {
                        drainwellDiv.InnerHtml = "<input type=\"radio\" name=\"drainwellradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"drainwellradio\" disabled value=\"1\" title=\"读取\" checked />";
                    }
                    //项目资料查看和编辑权限
                    if (userperDs.Tables[0].Rows[0]["PROJECT"].ToString() == "0")
                    {
                        projectresultDiv.InnerHtml = "<input type=\"radio\" name=\"projectresultradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"projectresultradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"projectresultradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["PROJECT"].ToString() == "1")
                    {
                        projectresultDiv.InnerHtml = "<input type=\"radio\" name=\"projectresultradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"projectresultradio\" disabled value=\"1\" title=\"读取\" checked />" +
                                             "<input type=\"radio\" name=\"projectresultradio\" disabled value=\"2\" title=\"编辑\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["PROJECT"].ToString() == "2")
                    {
                        projectresultDiv.InnerHtml = "<input type=\"radio\" name=\"projectresultradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"projectresultradio\" disabled value=\"1\" title=\"读取\" />" +
                                             "<input type=\"radio\" name=\"projectresultradio\" disabled value=\"2\" title=\"编辑\" checked />";
                    }
                    //地形图下载权限
                    if (userperDs.Tables[0].Rows[0]["TOPOGRAPHIC"].ToString() == "1")
                    {
                        topographicDiv.InnerHtml = "<input type=\"checkbox\" name=\"topographicswitch\" disabled lay-skin=\"switch\" lay-text=\"开启|关闭\" checked />";
                    }
                    else
                    {
                        topographicDiv.InnerHtml = "<input type=\"checkbox\" name=\"topographicswitch\" disabled lay-skin=\"switch\" lay-text=\"开启|关闭\" />";
                    }
                    //部门文件查看和上传下载，删除权限
                    if (userperDs.Tables[0].Rows[0]["SGESDOC"].ToString() == "0")
                    {
                        SGESDocDiv.InnerHtml = "<input type=\"radio\" name=\"sgesdocradio\" disabled value=\"0\" title=\"无\" checked />" +
                                             "<input type=\"radio\" name=\"sgesdocradio\" disabled value=\"1\" title=\"上传、下载\" />" +
                                             "<input type=\"radio\" name=\"sgesdocradio\" disabled value=\"2\" title=\"上传、下载、删除\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["SGESDOC"].ToString() == "1")
                    {
                        SGESDocDiv.InnerHtml = "<input type=\"radio\" name=\"sgesdocradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"sgesdocradio\" disabled value=\"1\" title=\"上传、下载\" checked />" +
                                             "<input type=\"radio\" name=\"sgesdocradio\" disabled value=\"2\" title=\"上传、下载、删除\" />";
                    }
                    else if (userperDs.Tables[0].Rows[0]["SGESDOC"].ToString() == "2")
                    {
                        SGESDocDiv.InnerHtml = "<input type=\"radio\" name=\"sgesdocradio\" disabled value=\"0\" title=\"无\" />" +
                                             "<input type=\"radio\" name=\"sgesdocradio\" disabled value=\"1\" title=\"上传、下载\" />" +
                                             "<input type=\"radio\" name=\"sgesdocradio\" disabled value=\"2\" title=\"上传、下载、删除\" checked />";
                    }
                }
            }
        }
    }
}