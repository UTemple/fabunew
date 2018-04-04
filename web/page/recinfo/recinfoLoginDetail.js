function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}
var starttime = GetQueryString("st");
var endtime = GetQueryString("et");
var username = GetQueryString("id");

layui.config({
    base: "js/"
}).use(['form', 'layer', 'jquery', 'laypage'], function () {
    var form = layui.form(),
        layer = parent.layer === undefined ? layui.layer : parent.layer,
        laypage = layui.laypage,
        $ = layui.jquery;

    //加载登陆历史页面
    var recData = '';
    
    $.get("./recinfoLoginDetailget.aspx?id=" + username + "&st=" + starttime + "&et=" + endtime, function (data) {
        recData = data;
        //加载数据
        recinfoLogindetailLoad();
    })

    //显示指定用户的详细登陆历史信息
    function recinfoLogindetailLoad() {
        //渲染数据
        function renderData(data, curr) {
            var dataHtml = '';
            currData = recData.concat().splice(curr * nums - nums, nums);
            if (currData.length != 0) {
                for (var i = 0; i < currData.length; i++) {
                    dataHtml += '<tr>'
                        + '<td>' + currData[i].NAME + '</td>'
                        + '<td>' + currData[i].BYNAME + '</td>'
                        + '<td>' + currData[i].DEPARTMENT + '</td>'
                        + '<td>' + currData[i].IP + '</td>'
                        + '<td>' + currData[i].LOGINTIME + '</td>'
                        + '</tr>';
                }
            } else {
                dataHtml = '<tr><td colspan="5">暂无数据</td></tr>';
            }
            return dataHtml;
        }

        //分页
        var nums = 15; //每页出现的数据量
        laypage({
            cont: "page",
            pages: Math.ceil(recData.length / nums),
            jump: function (obj) {
                $(".logindetail_rec").html(renderData(recData, obj.curr));
                form.render();
            }
        })
    }
    })

function btnReturn() {
    window.location.href = "./recinfoLogin.aspx?st=" + starttime + "&et=" + endtime;
}