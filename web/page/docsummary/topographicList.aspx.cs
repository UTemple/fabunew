using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;

namespace web.page.docsummary
{
    public partial class topographicList : System.Web.UI.Page
    {
        //[ThreadStatic]
        //static int index = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Request.Cookies["userId"].Value;
            if (userId == null || userId.Length == 0)
            {
                Response.Write("<script>window.location.href = \"../notLogin.html\";</script>");//not login
            }

            if (!IsPostBack)
            {
                if (GetTopoDownLoadPer() == false)
                    Button2.Visible = false;
                //生成GridView
                CompleteGV();
                //设置初始排序
                ViewState["SortOrder"] = "FileName";
                ViewState["OrderDire"] = "ASC";
                //调用绑定数据信息函数，直接下面读取文件夹中的文件进行绑定
                refresh();
            }
        }

        protected bool GetTopoDownLoadPer()
        {
            string permissinsql = "SELECT TOPOGRAPHIC FROM PERMISSION WHERE USERID = " + Request.Cookies["userId"].Value;
            DataSet userPerinfo = QuaryUser(permissinsql);
            bool canDl = false;
            if (userPerinfo.Tables[0].Rows.Count > 0)
            {
                int permission = Convert.ToInt32(userPerinfo.Tables[0].Rows[0]["TOPOGRAPHIC"].ToString());
                if (permission == 1)
                    canDl = true;
            }
            return canDl;
        }
        protected void CompleteGV()
        {
            //设置主键
            GridView1.DataKeyNames = new string[] { "FileName" };
            //设置数据列
            BoundField bf = new BoundField();
            bf.DataField = "FileName";
            bf.SortExpression = "FileName";
            bf.HeaderText = "文件名";
            bf.HeaderStyle.Width = new Unit("33%");
            bf.HeaderStyle.Font.Size = FontUnit.Large;
            bf.ReadOnly = true;
            GridView1.Columns.Add(bf);

            BoundField bf1 = new BoundField();
            bf1.DataField = "FileSize";
            bf1.SortExpression = "FileSize";
            bf1.HeaderText = "文件大小";
            bf1.HeaderStyle.Width = new Unit("33%");
            bf1.HeaderStyle.Font.Size = FontUnit.Large;
            bf1.ReadOnly = true;
            GridView1.Columns.Add(bf1);

            if (GetTopoDownLoadPer() == true)
            {
                //设置下载按钮
                ButtonField btnf1 = new ButtonField();
                btnf1.CommandName = "download"; btnf1.Text = "下载"; btnf1.ButtonType = ButtonType.Button;
                btnf1.ControlStyle.CssClass = "layui-btn";
                btnf1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                btnf1.ItemStyle.VerticalAlign = VerticalAlign.Middle;
                btnf1.ItemStyle.Width = new Unit("30%");
                GridView1.Columns.Add(btnf1);
            }
            else
            {
                //设置“无下载权限”文本列
                BoundField bf2 = new BoundField();
                bf2.DataField = "NoPermission";
                bf2.SortExpression = "NoPermission";
                //bf2.HeaderText = "文件大小";
                bf2.HeaderStyle.Width = new Unit("30%");
                bf2.HeaderStyle.Font.Size = FontUnit.Large;
                bf2.ReadOnly = true;
                GridView1.Columns.Add(bf2);
            }
        }

        protected void refresh()//绑定到GridView
        {
            topolsDiv.InnerHtml = "";
            DataTable bindTb = new DataTable();
            DataColumn column;
            DataRow tmpRow;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "FileName";
            bindTb.Columns.Add(column);
            
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "FileSize";
            bindTb.Columns.Add(column);

            bool dlper = GetTopoDownLoadPer();
            if (dlper == false)//无下载权限时table中加入“无下载权限”文本列数据
            {
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = "NoPermission";
                bindTb.Columns.Add(column);
            }

            DirectoryInfo topoDir = new DirectoryInfo(@"E:\Ourgis_ProjectFiles\TopographicFiles");
            //搜索条件
            string tofind = TextBox1.Text;
            foreach (FileInfo filetmp in topoDir.GetFiles())
            {
                if (tofind.Length == 0 || filetmp.Name.Contains(tofind))
                {
                    tmpRow = bindTb.NewRow();
                    tmpRow["FileName"] = filetmp.Name;
                    tmpRow["FileSize"] = ((float)filetmp.Length / 1024).ToString("F2") + "K";
                    if(dlper == false)
                        tmpRow["NoPermission"] = "无下载权限";
                    bindTb.Rows.Add(tmpRow);
                }
            }

            GridView1.Columns[3].ControlStyle.CssClass = "layui-btn";//下载按钮的css样式
            if (bindTb.Rows.Count > 0)
            {
                //绑定到ds的可排序视图
                DataView view = new DataView(bindTb);
                string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
                view.Sort = sort;
                GridView1.DataSource = view;
                GridView1.DataBind();
                //绑定数据的条数到分页菜单栏
                Label dataCount = (Label)GridView1.BottomPagerRow.Cells[0].FindControl("dataCount");
                dataCount.Text = view.Count.ToString();
            }
            else if(bindTb.Rows.Count == 0)
            {
                topolsDiv.InnerHtml = "<script>layui.use('layer', function(){var layer = layui.layer;layer.msg('没有查询到相关文件', {icon: 7,time: 5000,area: '300',btnAlign: 'c',btn: ['确认']});});</script>";
            }
            //对排序列进行色彩渲染
            //sortColor(onSort, index);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)//加载鼠标指针效果到行事件
        {
            //GridView1.Columns[3].ControlStyle.CssClass = "layui-btn";//下载按钮的css样式
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentColor=this.style.backgroundColor;this.style.backgroundColor='#31b7ab';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentColor;");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)//分页事件
        {
            //取消选中行
            GridView1.SelectedIndex = -1;
            // 得到该控件
            GridView theGrid = sender as GridView;
            int newPageIndex = 0;
            if (e.NewPageIndex == -4)
            {
                //点击了Set按钮
                TextBox txtPageSize = null;
                GridViewRow pagerRow = theGrid.BottomPagerRow;
                txtPageSize = pagerRow.FindControl("txtNewPageSize") as TextBox;
                theGrid.PageSize = int.Parse(txtPageSize.Text);
            }
            else
            {
                if (e.NewPageIndex == -3)
                {
                    //点击了Go按钮
                    TextBox txtNewPageIndex = null;

                    //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow
                    GridViewRow pagerRow = theGrid.BottomPagerRow;

                    if (pagerRow != null)
                    {
                        //得到text控件
                        txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
                    }
                    if (txtNewPageIndex != null)
                    {
                        //得到索引
                        newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
                    }
                }
                else
                {
                    //点击了其他的按钮
                    newPageIndex = e.NewPageIndex;
                }
                //防止新索引溢出
                newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
                newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

                //得到新的值
                theGrid.PageIndex = newPageIndex;
            }
            //重新绑定
            refresh();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)//行命令事件：详情、定位
        {
            if (e.CommandName == "download")//**下载按钮
            {
                //获取当前行的index、主键
                int index = int.Parse(e.CommandArgument.ToString());
                GridView1.SelectedIndex = index;
                string mainkey = GridView1.DataKeys[index].Value.ToString();
                //**下载
                Response.Write("<script>window.open('topographicDownload.aspx?fname=" + mainkey + "', '_blank')</script>");
            }
            GridView1.Columns[3].ControlStyle.CssClass = "layui-btn";//下载按钮的css样式
        }
        protected void Button1_Click(object sender, EventArgs e)//搜索键的点击事件
        {
            //重置页码
            GridView1.PageIndex = 0;
            //取消选中行
            GridView1.SelectedIndex = -1;
            refresh();
        }

        protected void Button2_Click(object sender, EventArgs e)//批量下载按键的点击事件
        {
            string filenames = string.Empty;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ChkItem");
                if (cb.Checked == true)
                {
                    filenames += GridView1.DataKeys[i].Value.ToString() + ",";
                }
            }
            GridView1.Columns[3].ControlStyle.CssClass = "layui-btn";//下载按钮的css样式
            if (filenames.Length == 0)
            {
                topolsDiv.InnerHtml = "<script>layui.use('layer', function(){var layer = layui.layer;layer.msg('请选择要下载的文件！', {icon: 7,time: 5000,area: '300',btnAlign: 'c',btn: ['确认']});});</script>";
            }
            else Response.Write("<script>window.open('topographicDownload.aspx?fname=" + filenames.Substring(0, filenames.Length - 1) + "', '_blank')</script>");
                //Response.Write("<script>window.open('MutiDownLoadWithTip.aspx?fnames=" + filenames.Substring(0, filenames.Length - 1) + "', '_blank')</script>");
                //Response.Write("<script>window.open('topographicMultiDownload.aspx?fnames=" + filenames.Substring(0, filenames.Length-1) + "', '_blank')</script>");
        }
    }
}