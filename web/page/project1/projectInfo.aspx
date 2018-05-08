<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectInfo.aspx.cs" Inherits="web.page.project.projectInfo" validateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>项目详细信息</title>
	<meta name="renderer" content="webkit" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
	<meta name="apple-mobile-web-app-status-bar-style" content="black" />
	<meta name="apple-mobile-web-app-capable" content="yes" />
	<meta name="format-detection" content="telephone=no" />
	<link rel="stylesheet" href="../../plugins/layui/css/layui.css" media="all" />
	<link rel="stylesheet" href="//at.alicdn.com/t/font_eolqem241z66flxr.css" media="all" />
	<link rel="stylesheet" href="../../css/user.css" media="all" />
    <style type="text/css">
        .layui-table td {
            background:#d2d2d2;
        }
    </style>
</head>
<body>
    <div>
        <div id="proTitleDiv" runat="server"></div>
        <div style="position:absolute;float:left;width:20%"></div>
        <form id="form1" runat="server">
            <div style="position:absolute;float:left;left:20%;width:60%">
                <table class="layui-table">
                    <%--<colgroup>
                        <col width="30%" />
                        <col />
                    </colgroup>--%>
                    <tbody id="proinfo_body" runat="server"></tbody>
                </table>
                <input type="hidden" name="xmbh" id="xmbh" />
                <input type="hidden" name="xzq" id="xzq" />
                <input type="hidden" name="sshl" id="sshl" />
                <input type="hidden" name="xmwz" id="xmwz" />
                <input type="hidden" name="yzdw" id="yzdw" />
                <div id="dydiv" class="layui-form-item" style="text-align:center;display:none">
		            <div class="layui-input-block" style="margin-left:0px">
		    	        <button class="layui-btn" lay-submit="" lay-filter="changeProjectInfo">保存修改</button>
		            </div>
		        </div>
            </div>
        </form>
        <div style="position:absolute;float:right;width:20%"></div>
    </div>
    <script type="text/javascript" src="../../plugins/layui/layui.js"></script>
	<script type="text/javascript" src="projectManage.js"></script>
    <div id="chproendDiv" runat="server"></div>
</body>
</html>
