<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="realtimeUserList.aspx.cs" Inherits="web.page.sitemail.realtimeUserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>用户在线列表</title>
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
<body style="background-color:antiquewhite">
    <%--<label><%=aaaa %></label>--%>
    <form class="layui-form" runat="server" id="form2">
        <div style="margin:10px auto;text-align:center;width:120px">
            <asp:GridView ID="RealTimeUsers" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="120px" OnRowDataBound="GridView_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="用户id" DataField="UserID"></asp:BoundField>
                    <asp:BoundField HeaderText="在线用户" DataField="UserName"></asp:BoundField>
                    <asp:BoundField HeaderText="最初时间" DataField="FirstRequestTime"></asp:BoundField>
                    <asp:BoundField HeaderText="最后时间" DataField="LastRequestTime"></asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#454B5A" />
                <HeaderStyle BackColor="#454B5A" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Bottom" />
                <RowStyle BackColor="#F7F7DE" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                <SelectedRowStyle BackColor="#1AA094" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
        <%--<div id="RealTimeNoUser"></div>--%>
    </form>
        
    <script type="text/javascript" src="../../plugins/layui/layui.js"></script>
</body>
</html>
