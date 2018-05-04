using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static tools.quaryData;
using static tools.WGStoGZ;

namespace web.page.coordinateconvert
{
    public partial class WGSConvert2GZ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnConvert_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filename = FileUpload1.FileName;
                string[] arrystr = FileUpload1.FileName.Split('.');
                if(arrystr[arrystr.Length -1] != "xlsx" && arrystr[arrystr.Length - 1] != "xls")
                {
                    Response.Write("<script languge='javascript'>alert('输入坐标文件类型错误，必须是Excel文件！');</script>");
                    return;
                }
                //获取坐标转换文件夹路径
                string filePath = "";//路径
                DataTable filepathtb = QuaryExcel("SELECT FILEPATH FROM [GLOBALCONFIG$]").Tables[0];                

                if (filepathtb.Rows.Count > 0)
                {
                    filePath = filepathtb.Rows[0]["FILEPATH"].ToString() + @"CoordinateConvert\\";
                    string savepath = filePath + Guid.NewGuid().ToString() + @"\\";
                    Directory.CreateDirectory(savepath);//创建临时文件夹

                    //savepath += filename;
                    FileUpload1.SaveAs(savepath + filename);

                    //打开该坐标文件进行转换
                    OleDbConnection excelcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + savepath + filename + ";Extended Properties='Excel 12.0;IMEX=0';");
                    OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", excelcon);
                    DataSet coordset = new DataSet();
                    ad.Fill(coordset);
                    
                    if (coordset.Tables[0].Rows.Count > 0)
                    {
                        foreach(DataRow tmprow in coordset.Tables[0].Rows)
                        {
                            if (tmprow["纬度"] == null || tmprow["纬度"].ToString() == string.Empty)
                                break;
                            tmprow["GZX"] = projectConvertY(113.295067222222, Convert.ToDouble(tmprow["纬度"]), Convert.ToDouble(tmprow["经度"])).ToString();//x用名字为y的函数算
                            tmprow["GZY"] = projectConvertX(113.295067222222, Convert.ToDouble(tmprow["纬度"]), Convert.ToDouble(tmprow["经度"])).ToString();//y用名字为x的函数算
                        }

                        OleDbCommandBuilder sqlBulider = new OleDbCommandBuilder(ad);
                        OleDbCommand updateCmd = new OleDbCommand("update [Sheet1$] set GZX=@GZX,GZY=@GZY where id=@id", excelcon);
                        updateCmd.Parameters.Add("@GZX", OleDbType.VarWChar, 20, "GZX");
                        updateCmd.Parameters.Add("@GZY", OleDbType.VarWChar, 20, "GZY");
                        updateCmd.Parameters.Add("@id", OleDbType.Integer, 4, "id");
                        ad.UpdateCommand = updateCmd;
                        ad.Update(coordset.Tables[0]);
                        excelcon.Close();
                        //将填写了转换数据的文件发送给用户
                        Response.Write("<script languge='javascript'>window.open('./WGSConvert2GZTempletDl.aspx?filefullpath=" + savepath + filename + "&filename="+ filename + "');</script>");
                    }
                    else Response.Write("<script languge='javascript'>alert('坐标文件内容有误！');</script>");
                }
                else
                    Response.Write("<script languge='javascript'>alert('找不到指定项目序号！');</script>");
            }
        }
    }
}