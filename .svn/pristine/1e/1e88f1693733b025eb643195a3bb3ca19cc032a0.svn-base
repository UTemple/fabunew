<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="drainageInfoSummary1.aspx.cs" Inherits="web.page.formpages.drainageInfoSummary1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户添加--layui后台管理模板</title>
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
        .layui-form-item .layui-inline {
            width: 33.333%;
            float: left;
            margin-right: 0;
        }

        @media(max-width:1240px) {
            .layui-form-item .layui-inline {
                width: 100%;
                float: none;
            }
        }
    </style>
</head>
<body class="childrenBody">
    <form class="layui-form" style="width:48%;float:left">
        <blockquote class="layui-elem-quote news_search">
            <div class="layui-form-item">
                <div class="layui-inline">
                    <label class="layui-form-label">统计类别</label>
                    <div class="layui-input-block">
                        <select runat="server" id="sumtype" name="sumtype" class="sumtype" lay-filter="sumtypefilter">
                            <option value="1">行政区</option>
                            <option value="2">权属单位</option>
                        </select>
                    </div>
                </div>
                <%--<div class="layui-inline" style="margin-left:10px"><a class="layui-btn search_btn">查询</a></div>--%>
            </div>
        </blockquote>
        <div class="layui-form news_list">
	  	    <table class="layui-table">
		        <colgroup>
				    <col width="50%" />
				    <col width="50%" />
		        </colgroup>
		        <thead>
				    <tr>
					    <th id="name1"></th>
                        <th id="name2"></th>
				    </tr> 
		        </thead>
		        <tbody class="drainageinfosum"></tbody>
		    </table>
	    </div>
	<%--<div id="page"></div>--%>
    </form>
    <form class="layui-form" style="width:50%;float:left;padding-left:10px">
        <%--<iframe id="mapforproject" class="fullHeight" width="100%" height="1000px" frameborder="0" src="../map/map.html?app=1" onload="FullHeight(this)">抱歉！该页面不支持您的浏览器！</iframe>--%>
        <div id="PieChart" style="width: 900px;height:600px;padding-top:100px"></div>
    </form>
    <script type="text/javascript" src="../../plugins/layui/layui.js"></script>
    <script src="../../js/echarts.min.js"></script>
    <script type="text/javascript" src="drainageInfoSum1.js"></script>
    <div id="endsumdiv" runat="server"></div>
</body>
</html>
