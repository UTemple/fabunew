<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userPermissionDetail.aspx.cs" Inherits="web.page.user.userPermissionDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户权限编辑</title>
    <meta name="renderer" content="webkit" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="format-detection" content="telephone=no" />
    <link rel="stylesheet" href="../../plugins/layui/css/layui.css" media="all" />
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

        .layui-form-label {
            width:100px;
        }
    </style>
</head>
<body>
    <div style="position:absolute;float:left;width:30%"></div>
    <div style="position:absolute;float:left;left:30%;width:40%">
    <form id="form1" class="layui-form">
        <div class="layui-form-item" style="width:80%;margin:0 auto 20px;">
			<label class="layui-form-label">账号</label>
			<div class="layui-input-block" style="width:50%;margin-left:150px;margin-top:20px">
			    <%--<input type="text" value="请叫我马哥" disabled class="layui-input layui-disabled" />--%>
                <div id="userNameDiv" runat="server"></div>
			</div>
		</div>
        <div class="layui-form-item" style="width:80%;margin:0 auto 20px;">
			<label class="layui-form-label">权限设定</label>
			<div class="layui-input-block" style="width:50%;margin-left:150px;margin-top:20px">
			    <select id="perstyle" name="perstyle" lay-filter="InputPerStyle">
                  <option value="1">管理员</option>
                  <option value="2">高级用户</option>
                  <option value="3">普通用户</option>
                  <option value="4">外部用户</option>
                  <option value="5">自定义</option>
                </select>
			</div>
		</div>
        <div class="layui-collapse" id="collapseDiv">
            <div class="layui-colla-item">
                <h2 class="layui-colla-title">后台管理权限</h2>
                <div class="layui-colla-content">
                    <div class="layui-form-item">
                        <label class="layui-form-label">用户管理</label>
                        <div class="layui-input-block">
                            <%--<input type="checkbox" name="userswitch" lay-skin="switch" lay-text="开启|关闭" checked />--%>
                            <div id="userDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">登陆历史查看</label>
                        <div class="layui-input-block">
                            <%--<input type="checkbox" name="recloginswitch" lay-skin="switch" lay-text="开启|关闭">--%>
                            <div id="recloginDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">使用习惯查看</label>
                        <div class="layui-input-block">
                            <div id="rechabitDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">资料操作记录</label>
                        <div class="layui-input-block">
                            <div id="recdownloadDiv" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="layui-colla-item">
                <h2 class="layui-colla-title">水利权限</h2>
                <div class="layui-colla-content">
                    <div class="layui-form-item">
                        <label class="layui-form-label">河流</label>
                        <div class="layui-input-block">
                            <%--<input type="radio" name="riverradio" value="0" title="无">
                            <input type="radio" name="riverradio" value="1" title="读取" checked>
                            <input type="radio" name="riverradio" value="2" title="编辑">--%>
                            <div id="riverDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">河流河长</label>
                        <div class="layui-input-block">
                            <div id="riverownerDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">水库</label>
                        <div class="layui-input-block">
                            <div id="reservoirDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">水库河长</label>
                        <div class="layui-input-block">
                            <div id="reservoirownerDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">湖泊</label>
                        <div class="layui-input-block">
                            <div id="lakeDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">湖泊河长</label>
                        <div class="layui-input-block">
                            <div id="lakeownerDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">泵站</label>
                        <div class="layui-input-block">
                            <div id="pumpDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">水闸</label>
                        <div class="layui-input-block">
                            <div id="sluiceDiv" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="layui-colla-item">
                <h2 class="layui-colla-title">排水权限</h2>
                <div class="layui-colla-content">
                    <div class="layui-form-item">
                        <label class="layui-form-label">污水处理厂</label>
                        <div class="layui-input-block">
                            <%--<input type="radio" name="sewagefarmradio" value="0" title="无">
                            <input type="radio" name="sewagefarmradio" value="1" title="读取" checked>
                            <input type="radio" name="sewagefarmradio" value="2" title="编辑">--%>
                            <div id="sewagefarmDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">排水泵站</label>
                        <div class="layui-input-block">
                            <div id="drainpumpDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">排水水闸</label>
                        <div class="layui-input-block">
                            <div id="draingateDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">排水管道</label>
                        <div class="layui-input-block">
                            <div id="drainpipeDiv" runat="server"></div>
                        </div>
                    </div>
                    <%--<div class="layui-form-item">
                        <label class="layui-form-label">排水沟渠</label>
                        <div class="layui-input-block">
                            <div id="draincanalDiv" runat="server"></div>
                        </div>
                    </div>--%>
                    <div class="layui-form-item">
                        <label class="layui-form-label">雨水口</label>
                        <div class="layui-input-block">
                            <div id="draincombDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">窨井</label>
                        <div class="layui-input-block">
                            <div id="drainwellDiv" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="layui-colla-item">
                <h2 class="layui-colla-title">项目管理权限</h2>
                <div class="layui-colla-content">
                    <div class="layui-form-item">
                        <label class="layui-form-label">项目资料</label>
                        <div class="layui-input-block">
                            <%--<input type="radio" name="projectresultradio" value="0" title="无">
                            <input type="radio" name="projectresultradio" value="1" title="读取" checked>
                            <input type="radio" name="projectresultradio" value="2" title="编辑">--%>
                            <div id="projectresultDiv" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="layui-colla-item">
                <h2 class="layui-colla-title">地形图权限</h2>
                <div class="layui-colla-content">
                    <div class="layui-form-item">
                        <label class="layui-form-label">地形图下载</label>
                        <div class="layui-input-block">
                            <%--<input type="checkbox" name="topographicswitch" lay-skin="switch" lay-text="开启|关闭" />--%>
                            <div id="topographicDiv" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="layui-colla-item">
                <h2 class="layui-colla-title">部门文件权限</h2>
                <div class="layui-colla-content">
                    <div class="layui-form-item">
                        <label class="layui-form-label">水工建筑二所</label>
                        <div class="layui-input-block">
                            <%--<input type="checkbox" name="topographicswitch" lay-skin="switch" lay-text="开启|关闭" />--%>
                            <div id="SGESDocDiv" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="layui-form-item">
            <input type="text" id="isSubmit" name="isSubmit" class="layui-input isSubmit" style="display:none"/>
        </div>
        <div id="paDiv" class="layui-form-item" runat="server" style="display:none"></div>
        <div class="layui-form-item" style="width:60%;margin:0 auto">
            <div class="layui-input-block">
                <button type="button" class="layui-btn" lay-submit="" lay-filter="editUserPer">立即提交</button>
                <%--<button type="reset" class="layui-btn layui-btn-primary">重置</button>--%>
                <button type="button" class="layui-btn layui-btn-warm" onclick="btnCancel()">取消</button>
            </div>
        </div>
    </form>
    </div>
    <div style="position:absolute;float:right;width:30%"></div>
</body>
    
    <script type="text/javascript" src="../../plugins/layui/layui.js"></script>
    <script type="text/javascript" src="./permissionedit.js"></script>
</html>
