using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace web.page.sitemail
{
    public class Global : System.Web.HttpApplication
    {
        private static System.Threading.Timer timer;
        private const int interval = 1000 * 60 * 5;//检查在线用户的间隔时间:5min
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Global()
        {
            InitializeComponent();
        }

        protected void Application_Start(Object sender, EventArgs e)
        {
            if (timer == null)
                timer = new System.Threading.Timer(new System.Threading.TimerCallback(ScheduledWorkCallback),
                    sender, 0, interval);

            DataTable userTable = new DataTable();
            userTable.Columns.Add("UserID");//用户ID
            userTable.Columns.Add("UserName");//用户姓名
            userTable.Columns.Add("FirstRequestTime");//第一次请求的时间
            userTable.Columns.Add("LastRequestTime");//最后一次请求的时间
            //userTable.Columns.Add("ClientIP");//
            //userTable.Columns.Add("ClientName");//
            //userTable.Columns.Add("ClientAgent");//
            //userTable.Columns.Add("LastRequestPath");//最后访问的页面

            userTable.PrimaryKey = new DataColumn[] { userTable.Columns[0] };
            userTable.AcceptChanges();

            Application.Lock();
            Application["UserOnLine"] = userTable;
            Application.UnLock();
        }

        protected void Session_Start(Object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            HttpApplication mApp = (HttpApplication)sender;
            if (mApp.Context.Session == null) return;
            if (mApp.Context.Session["UserID"] == null) return;
            string userID = mApp.Context.Session["UserID"].ToString();

            DataTable userTable = (DataTable)Application["UserOnLine"];
            DataRow curRow = userTable.Rows.Find(new object[] { userID });
            if (curRow != null)
            {
                this.GetDataRowFromHttpApp(mApp, ref curRow);
            }
            else
            {
                DataRow newRow = userTable.NewRow();
                this.GetDataRowFromHttpApp(mApp, ref newRow);
                userTable.Rows.Add(newRow);
            }
            userTable.AcceptChanges();

            Application.Lock();
            Application["UserOnLine"] = userTable;
            Application.UnLock();

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {

        }


        protected void Session_End(Object sender, EventArgs e)
        {

        }

        protected void Application_End(Object sender, EventArgs e)
        {

        }

        #region Web 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

        }
        #endregion

        private void GetDataRowFromHttpApp(HttpApplication mApp, ref DataRow mRow)
        {
            if (mApp.Context.Session == null) return;
            if (mApp.Context.Session["UserID"] == null || mApp.Context.Session["UserName"] == null) return;
            string userID = mApp.Context.Session["UserID"].ToString();
            string userName = mApp.Context.Session["UserName"].ToString();
            //string requestPath = mApp.Request.Path;

            if (mRow["UserID"].ToString().Length < 1)
            {
                mRow["UserID"] = userID;
                mRow["UserName"] = userName;
                mRow["FirstRequestTime"] = System.DateTime.Now;
                //mRow["ClientIP"] = mApp.Context.Request.UserHostAddress;
                //mRow["ClientName"] = mApp.Context.Request.UserHostName;
                //mRow["ClientAgent"] = mApp.Context.Request.UserAgent;
            }

            mRow["LastRequestTime"] = System.DateTime.Now;
            //mRow["LastRequestPath"] = requestPath;

        }

        private void ScheduledWorkCallback(object sender)
        {
            string filter = "Convert(LastRequestTime,'System.DateTime') < Convert('" + System.DateTime.Now.AddSeconds(-interval / 1000).ToString() + "','System.DateTime')";
            DataTable userTable = (DataTable)Application["UserOnLine"];
            if(userTable != null)
            {
                DataRow[] lineOutUsers = userTable.Select(filter);
                for (int i = 0; i < lineOutUsers.Length; i++)
                {
                    DataRow curRow = lineOutUsers[i];

                    curRow.Delete();
                }
                userTable.AcceptChanges();

                Application.Lock();
                Application["UserOnLine"] = userTable;
                Application.UnLock();
            }
        }
    }
}