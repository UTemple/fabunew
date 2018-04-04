﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recinfoLoginDetail.aspx.cs" Inherits="web.page.recinfo.recinfoLoginDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>登陆历史详细信息</title>
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
	<%--<blockquote class="layui-elem-quote news_search">
		<div class="layui-inline">
		    <div class="layui-input-inline">
		    	<input type="text" value="" placeholder="请输入关键字" class="layui-input search_input" />
		    </div>
		    <a class="layui-btn search_btn">查询</a>
		</div>
		<div class="layui-inline">
			<div class="layui-form-mid layui-word-aux">  </div>
		</div>
	</blockquote>--%>
	<div class="layui-form news_list">
	  	<table class="layui-table">
		    <colgroup>
				<col width="10%" />
				<col width="10%" />
                <col width="10%" />
				<col width="10%" />
				<col width="10%" />
		    </colgroup>
		    <thead>
				<tr>
					<th>帐号</th>
                    <th>姓名</th>
                    <th>部门</th>
                    <th>IP地址</th>
                    <th>登录时间</th>
				</tr> 
		    </thead>
		    <tbody class="logindetail_rec"></tbody>
		</table>
	</div>
	<div id="page"></div>
    <button type="button" class="layui-btn layui-btn-warm" style="margin-left:48%" onclick="btnReturn()">返回</button>
	<script type="text/javascript" src="../../plugins/layui/layui.js"></script>
	<script type="text/javascript" src="recinfoLoginDetail.js"></script>
</body>
</html>
