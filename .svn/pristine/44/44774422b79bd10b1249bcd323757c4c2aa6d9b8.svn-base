<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WGSConvert2GZ.aspx.cs" Inherits="web.page.coordinateconvert.WGSConvert2GZ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>经纬度转广州城建坐标</title>
	<meta name="renderer" content="webkit" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
	<meta name="apple-mobile-web-app-status-bar-style" content="black" />
	<meta name="apple-mobile-web-app-capable" content="yes" />
	<meta name="format-detection" content="telephone=no" />
	<link rel="stylesheet" href="../../plugins/layui/css/layui.css" media="all" />
	<link rel="stylesheet" href="//at.alicdn.com/t/font_eolqem241z66flxr.css" media="all" />
	<link rel="stylesheet" href="../../css/user.css" media="all" />
</head>
<body>
    <br /><br />
    <fieldset class="layui-elem-field" style="text-align:center">
        <legend>使用说明</legend>
        <div class="layui-field-box">
            本页面可以完成经纬度到广州城建坐标的转换。需要以指定格式的Excel文件作为输入，具体模板文件可以在下方下载。
        </div>
    </fieldset>
	<hr class="layui-bg-green" style="height:5px" />
    <br />
    <div style="float:left;width:49%">
        <fieldset class="layui-elem-field" style="text-align:center">
            <legend>模板下载</legend>
            <div class="layui-field-box">
                <a href="#" onclick="DownloadTemplet()" style="display:block;color:darkred;font-style:italic;height:44px">坐标转换文件模板.xlsx</a>
            </div>
        </fieldset>
    </div>
    <div style="float:left;margin-left:3px;width:49%">
        <fieldset class="layui-elem-field" style="text-align:center">
            <legend>坐标转换</legend>
            <div class="layui-field-box">
                <form runat="server" style="text-align:center">
                    <div>
                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="Text1.value=this.value" Style="visibility:hidden;width:0px;height:38px" />
                        <input id="Text1" type="text"  readonly="readonly" style="display:inline-block;height:38px;border:none;border-radius:2px;background-color:darkseagreen;width:200px"/>
                    <%--</div>
                    <div>--%>
                        <input type="button" class="layui-btn" style="margin-left:10px" value="选择文件" onclick="FileUpload1.click()" />
                        <asp:Button class="layui-btn" ID="Button1" runat="server" Text="转换" OnClick="btnConvert_Click" style="margin-left:1px" />
                    </div>
                </form>
            </div>
        </fieldset>
    </div>
    <script type="text/javascript" src="../../plugins/layui/layui.js"></script>
    <script type="text/javascript" src="./wgsconvert2gz.js"></script>
</body>
</html>
