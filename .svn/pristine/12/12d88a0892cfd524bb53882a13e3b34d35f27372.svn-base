using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.WGStoGZ;

namespace web.page.coordinateconvert
{
    public partial class WGStoGZJSService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //为前台map页面经纬度定位功能坐标转换提供服务
        [WebMethod]
        public static string GWStoGZServer(string lat,string lon)//纬度，经度
        {
            if (lat.Length == 0 || lon.Length == 0)
                return "ERROR";

            string result = string.Empty;
            double latdou = Convert.ToDouble(lat);
            double londou = Convert.ToDouble(lon);
            result = projectConvertY(113.295067222222, latdou, londou).ToString();
            result += ("," + projectConvertX(113.295067222222, latdou, londou).ToString());
            return result;
        }
    }
}