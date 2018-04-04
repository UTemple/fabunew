using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using static tools.quaryData;

namespace web.page.sitemail
{
    /// <summary>
    /// SiteMailNameAutoComplete 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class SiteMailNameAutoComplete : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] GetSuggestionNames(string prefixText, int count)
        {
            //string[] NameArray = new string[];
            List<string> NameArray = new List<string>();

            string strsql = "SELECT BYNAME FROM USERLIST WHERE BYNAME LIKE '%" + prefixText +"%'";
            DataSet userNameInfo = QuaryUser(strsql);

            int insertnum = 0;
            for (int i = 0; i < userNameInfo.Tables[0].Rows.Count; i++)
            {
                if (insertnum < count)
                {
                    NameArray.Add(userNameInfo.Tables[0].Rows[i]["BYNAME"].ToString());
                    insertnum++;
                }
                else break;
            }
            return NameArray.ToArray();
        }
    }
}
