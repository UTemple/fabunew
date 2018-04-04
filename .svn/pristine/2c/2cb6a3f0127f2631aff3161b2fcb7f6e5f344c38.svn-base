using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page.sitemail
{
    public partial class realtimeUserList : System.Web.UI.Page
    {
        protected int aaaa = 123;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable userListtb = null;
            try
            {
                userListtb = (DataTable)Application["UserOnLine"];
            }
            catch
            {
                Response.Write("获得内存在线用户数据失败");
            }

            if (userListtb != null)
            {
                string sqlstr = "SELECT ID FROM USERLIST";
                DataSet userDs = QuaryUser(sqlstr);
                if (userListtb.Rows.Count > 0)
                {
                    DataView view = new DataView(userListtb);
                    string sort = "UserName ASC";
                    view.Sort = sort;
                    RealTimeUsers.DataSource = view;
                    //显示在线人数
                    RealTimeUsers.Columns[1].HeaderText = "在线用户(" + userListtb.Rows.Count.ToString() + "/" + userDs.Tables[0].Rows.Count + ")";
                    RealTimeUsers.DataBind();
                }
                else //没有在线用户的情况应该不存在
                {
                    return;
                }
            }
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)//加载鼠标指针效果到行事件
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i != 1)//Cells[1]是用户名列
                {
                    e.Row.Cells[i].Visible = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentColor=this.style.backgroundColor;this.style.backgroundColor='#31b7ab';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentColor;");
            }
        }
    }
}