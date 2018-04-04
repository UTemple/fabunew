<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="topographicList.aspx.cs" Inherits="web.page.docsummary.topographicList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>地形图文件</title>
    <link rel="stylesheet" href="../../plugins/layui/css/layui.css" media="all" />
    <link rel="stylesheet" href="../../fonts/iconfont.css" media="all" />
    <script type="text/javascript" src="../../plugins/layui/layui.js"></script>
    <link rel="stylesheet" href="../../css/user.css" media="all" />
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <blockquote class="layui-elem-quote news_search">
            <%--<asp:TextBox ID="TextBox1" runat="server" Height="26px" Width="146px" Style="margin-bottom: 10px;" Font-Names="微软雅黑" Font-Size="Small" MaxLength="100"></asp:TextBox>--%>
            <div class="layui-input-inline">
                <asp:TextBox ID="TextBox1" runat="server" class="layui-input" MaxLength="100"></asp:TextBox>
            </div>
            <%--<asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" Height="24px" Width="50px" Style="margin-bottom: 8px;" Font-Names="微软雅黑" Font-Size="Small" BackColor="#CCCCCC"/>--%>
            <asp:Button ID="Button1" runat="server" class="layui-btn" Text="查询" OnClick="Button1_Click" Font-Names="微软雅黑" />
            <asp:Button ID="Button2" runat="server" class="layui-btn" Text="批量下载" OnClick="Button2_Click" Font-Names="微软雅黑" />
        </blockquote>
        <asp:GridView ID="GridView1" runat="server" class="layui-table" AutoGenerateColumns="False" AllowSorting="False" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="10" Width="100%"
            OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkItem" runat="server" Width="60px"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
                共计
                <%--得到数据的总数--%>
                <asp:Label ID="dataCount" runat="server" Text=""></asp:Label>
                个文件&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                当前第:
                <%--((GridView)Container.NamingContainer)就是为了得到当前的控件--%>
                <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                页/共:
                <%--得到分页页面的总数--%>
                <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <%--如果该分页是首分页，那么该连接就不会显示了.同时对应了自带识别的命令参数CommandArgument--%>
                <asp:Button ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                    Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>' Text="首页"></asp:Button>
                <asp:Button ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                    CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' Text="上一页"></asp:Button>
                <%--如果该分页是尾页，那么该连接就不会显示了--%>
                <asp:Button ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                    Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>' Text="下一页"></asp:Button>
                <asp:Button ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                    Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>' Text="尾页"></asp:Button>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;每页
                <asp:TextBox ID="txtNewPageSize" runat="server" Width="30px" Text='<%# ((GridView)Container.Parent.Parent).PageSize %>' />条
                <%--这里将CommandArgument即使点击该按钮e.newIndex 值为-4--%>
                <asp:Button ID="btnSet" runat="server" CausesValidation="False" CommandArgument="-3" CommandName="Page" Text="SET"></asp:Button>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;转到第
                <asp:TextBox ID="txtNewPageIndex" runat="server" Width="30px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                <%--这里将CommandArgument即使点击该按钮e.newIndex 值为-3--%>
                <asp:Button ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" CommandName="Page" Text="GO"></asp:Button>
            </PagerTemplate>
            <FooterStyle BackColor="#454B5A" />
            <HeaderStyle BackColor="#454B5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Bottom" />
            <RowStyle BackColor="#F7F7DE" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
            <SelectedRowStyle BackColor="#1AA094" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <div id="topolsDiv" runat="server"></div>
    </form>
</body>
    <script>
        function renderpage() {
            var inputs = document.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                var tmpinput = inputs.item(i);
                if (tmpinput.getAttribute("type").toLowerCase() == "checkbox") {
                    tmpinput.setAttribute("lay-skin", "primary");
                }
            }
        }
        renderpage();

        layui.config({
            base: "js/"
        }).use(['form', 'layer', 'jquery', 'element'], function () {
            var form = layui.form(),
                layer = parent.layer === undefined ? layui.layer : parent.layer,
                laypage = layui.laypage,
                element = layui.element();
            $ = layui.jquery;

            form.render('checkbox');
        })
    </script>
</html>
