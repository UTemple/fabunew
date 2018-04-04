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
    public partial class drainageInfoSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userIdstr = Request.Cookies["userId"].Value;
            if (userIdstr == null)
            {
                Response.Write("<script>window.location.href = \"../notLogin.html\";</script>");
                return;
            }

            string tablestr = Request.QueryString["Select2"];
            string pagetypestr = string.Empty;
            if (tablestr == "PS_PIPE_ZY")
                pagetypestr = "DRAINPIPE";  //数据库表中的权限名称及操作习惯记录表中的记录名称都叫这个
            else if (tablestr == "PS_CANAL_ZY")
                //pagetypestr = "DRAINCANAL";
                pagetypestr = "DRAINPIPE";//和排水管道合为一个
            else if (tablestr == "PS_COMB_ZY")
                pagetypestr = "DRAINCOMB";
            else if (tablestr == "PS_WELL_ZY")
                pagetypestr = "DRAINWELL";
            string permissinsql = "SELECT " + pagetypestr + " FROM PERMISSION WHERE USERID = " + userIdstr;
            DataSet userPerinfo = QuaryUser(permissinsql);
            bool canLoad = false;
            if (userPerinfo.Tables[0].Rows.Count > 0)
            {
                int projectpermission = Convert.ToInt32(userPerinfo.Tables[0].Rows[0][pagetypestr].ToString());
                if (projectpermission == 1)
                    canLoad = true;
            }
            if (canLoad == false)
            {
                Response.Write("<script>window.location.href = \"../noPermission.html\";</script>");
                return;
            }

            string Select2str = Request.QueryString["Select2"];
            Select2.Value = Select2str;
            string sumtypestr = Request.QueryString["sumtype"];
            sumtype.Value = sumtypestr;
            string Select1str = Request.QueryString["Select1"];
            Select1.Value = Select1str;

            string sqlstr = "UPDATE REC_HABIT SET " + pagetypestr + " = " + pagetypestr + " + 1";
            OperateUser(sqlstr);
        }
    }
}