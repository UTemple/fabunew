<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recinfoLogin.aspx.cs" Inherits="web.page.recinfo.recinfoLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>登陆历史信息</title>
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
        .layui-table td{
            border-color:darkcyan;
        }
    </style>
</head>
<body class="childrenBody">
    <form class="layui-form">
	<blockquote class="layui-elem-quote news_search">
		<div class="layui-inline">
		    <div class="layui-input-inline">
		    	<label class="layui-form-label">起始时间</label>
                <input runat="server" id="stinput" type="text" value="" placeholder="" lay-verify="required|date" onclick="layui.laydate({elem: this,max: laydate.now()})" class="layui-input starttime" style="width:120px">
                <label class="layui-form-label">结束时间</label>
                <input runat="server" id="etinput" type="text" value="" placeholder="" lay-verify="required|date" onclick="layui.laydate({ elem: this, max: laydate.now()})" class="layui-input endtime" style="width:120px">
		    </div>
		    <a class="layui-btn search_btn" style="margin-left:20px">查询</a>
		</div>
		<div class="layui-inline">
			<div class="layui-form-mid layui-word-aux">  </div>
		</div>
	</blockquote>
	<div class="layui-form news_list">
	  	<table class="layui-table" style="border-color:darkcyan">
		    <colgroup>
				<col width="10%" />
				<col width="10%" />
                <col width="10%" />
				<col width="10%" />
				<col width="10%" />
                <col width="10%" />
                <col width="10%" />
		    </colgroup>
		    <thead>
				<tr>
					<th>部门</th>
					<th>帐号</th>
                    <th>姓名</th>
                    <th>IP地址</th>
                    <th>登陆次数</th>
                    <th>登录时间</th>
                    <th>详细信息</th>
				</tr> 
		    </thead>
		    <tbody class="login_rec"></tbody>
		</table>
	</div>
	<div id="page"></div>
    </form>
	<script type="text/javascript" src="../../plugins/layui/layui.js"></script>
	<script type="text/javascript" src="recinfoLogin.js"></script>
</body>
</html>
