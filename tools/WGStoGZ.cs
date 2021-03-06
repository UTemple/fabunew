﻿using System;
using System.Collections.Generic;
using System.Text;
//using System.Drawing.Text;
using System.Drawing;
//using GpsInfo;
//using ESRI.ArcGIS.Geometry;
//使用谷歌地球的经纬度进行计算

namespace tools
{
    public class WGStoGZ
    {
        //北京54参数
        static private double afa = 6378245;
        static private double K0 = 0.157046064172 / 1000000;
        static private double K1 = 0.005051773759;
        static private double K2 = 0.000029837302;
        static private double K3 = 0.000000238189;
        static private double C0 = 6367558.49686;
        static private double C1 = 32005.79642;
        static private double C2 = 133.06115;
        static private double C3 = 0.7031;
        static private double P0 = 57.29577951;
        static private double e3 = 0.00673852541468;
        static private double e2 = 0.00669342162297;
        static private double pai = 3.1415926;
        
        public static double projectConvertX(double L0, double pb, double pl)//L0可能是中央子午线，广州城建坐标使用的中央子午线是？
        {
            double n2;
            double t;
            double n;
            double b;
            double xb0;
            double m0;
            double x;
            double y;
            double l1;
            double c0b;
            double PX;

            l1 = (pl - L0) * pai / 180;
            b = pb * pai / 180;
            c0b = C0 * b;
            xb0 = c0b - Math.Cos(b) * (Math.Sin(b) * C1 + Multiplication(Math.Sin(b), 3) * C2 + Multiplication(Math.Sin(b), 5) * C3);
            t = Math.Tan(b);
            n2 = e3 * Math.Cos(b) * Math.Cos(b);
            n = afa / Math.Sqrt(1 - e2 * Math.Sin(b) * Math.Sin(b));
            m0 = Math.Cos(b) * l1;
            PX = xb0 + 0.5 * n * t * m0 * m0 + (1 / 24) * (5 - t * t + 9 * n2 + 4 * n2 * n2) * n * t * Multiplication(m0, 4) + (1 / 720) * (61 - 58 * t * t + t * t * t * t) * n * t * Multiplication(m0, 6);
            return PX - 2529729.997 + 44;//为设计院网站定位，调整系数，+44
        }
        
        public static double projectConvertY(double L0, double pb, double pl)
        {
            double n2;
            double t;
            double n;
            double b;
            double xb0;
            double m0;
            double x;
            double y;
            double l1;
            double c0b;
            double PY;
            l1 = (pl - L0) * pai / 180;
            b = pb * pai / 180;
            c0b = C0 * b;
            xb0 = c0b - Math.Cos(b) * (Math.Sin(b) * C1 + Multiplication(Math.Sin(b), 3) * C2 + Multiplication(Math.Sin(b), 5) * C3);
            t = Math.Tan(b);
            n2 = e3 * Math.Cos(b) * Math.Cos(b);
            n = afa / Math.Sqrt(1 - e2 * Math.Sin(b) * Math.Sin(b));
            m0 = Math.Cos(b) * l1;
            PY = n * m0 + (1 / 6) * (1 - t * t + n2) * n * Multiplication(m0, 3) + (1 / 120) * (5 - 18 * t * t + Multiplication(t, 4) + 14 * n2 - 58 * n2 * t * t) * n * Multiplication(m0, 5);
            return PY + 41250 - 78;//为设计院网站定位，调整系数，-78
        }

        //public static IPoint getPoint(double lon, double lat)
        //{
        //    double pointY = projectConvertX(113.295067222222, lat, lon) - 2529679.997;//广州中央子午线度数，纬度，经度
        //    double pointX = projectConvertY(113.295067222222, lat, lon) + 41240;
        //    IPoint point = new PointClass();
        //    point.X = pointX - 50.0; 
        //    point.Y = pointY + 10.0; 

        //    return point;
        //}
 
        public static double Multiplication(double x, int n)
        {
            double temp = x;
            for (int i = 0; i <= n - 2; i++)
            {
                temp = temp * x;
            }
            return temp;
        }

        public static void main(){
      
        }

    }
}
