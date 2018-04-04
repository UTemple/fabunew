<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShuiGongErSuoDocSpace.aspx.cs" Inherits="web.page.ShuiGongErSuoDocSpace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>水工二所公共资料</title>
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
<body class="childrenBody">
        <blockquote class="layui-elem-quote layui-quote-nm" style="font-size:16px;font-weight:bold;background-color:cadetblue">文件上传</blockquote>
            <form class="layui-form" runat="server" id="form2">
                <div class="layui-form news_list">
	  	            <table class="layui-table">
		                <colgroup>
                            <col width="50%" />
				            <col width="50%" />
		                </colgroup>
		                <thead>
				            <tr>
					            <th>文件说明</th>
                                <th>文件上传</th>
				            </tr> 
		                </thead>
		                <tbody id="loadupload" runat="server">
                            <tr>
                              <td><input runat="server" type="text" id="filedetailinput" value="" placeholder="请输入文件说明" class="layui-input" required="required" style="display:inline-block;width:70%;margin-left:20px;border:1px solid black"/></td>
                              <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="Text1.value=this.value" Style="visibility:hidden;width:0px" />
                                    <input id="Text1" type="text"  readonly="readonly" style="display:inline-block;border:none;border-radius:2px;height:38px;width:50%;background-color:darkgray"/>
                                    <input type="button" class="layui-btn" value="选择文件" onclick="FileUpload1.click()" />
                                    <asp:Button class="layui-btn" ID="Button2" runat="server" Text="上传" OnClick="btnSaveDeptFile_Click" style="margin-left:5px" />
                              </td>
                            </tr>
		                </tbody>
		            </table>
	            </div>
            </form>
        <hr />
    <blockquote class="layui-elem-quote layui-quote-nm" style="font-size:16px;font-weight:bold;background-color:cadetblue">文件列表</blockquote>
        <form class="layui-form">
            <div id="listPageDeptDiv" runat="server"></div>
        </form>
	    <script type="text/javascript" src="../../plugins/layui/layui.js"></script>
	    <script type="text/javascript" src="./DeptFiles.js"></script>
        <script>
            function LoadHeight(ele) {
                ele.height = ((document.body.clientHeight * 0.6) || 600);
            }
        </script>
</body>
</html>
