layui.config({
    base : "js/"
}).use(['form', 'layer', 'jquery', 'laypage', 'laydate'], function () {
    var form = layui.form(),
        layer = parent.layer === undefined ? layui.layer : parent.layer,
        laypage = layui.laypage,
        $ = layui.jquery;
        laydate = layui.laydate;
    //部门列表
    //var deptlist = new Array();
    //deptlist = ['院领导', '技术质量办', '经营部', '办公室', '财务科', '建筑景观所', '造价中心', '信息中心', '水工建筑一所', '水工建筑二所', '市政所', '机电给排水室', '规划所', '建设项目部', '岩土室', '测量室', '资源环境所', '智慧所', '第三方部门'];

    //加载登陆历史页面
        var recData = '';
        $.get("./recinfoLoginget.aspx?st=" + $("#stinput").val() + "&et=" + $("#etinput").val(), function (data) {
            recData = JSON.parse(data); 
            //加载数据
            recinfoLoginLoad($("#stinput").val(), $("#etinput").val());
        })

    $(".search_btn").click(function () {
        var starttime = $(".starttime").val();
        var endtime = $(".endtime").val();
        var urlstr = '';
        if (starttime != '' && endtime != '')
            urlstr = "./recinfoLoginget.aspx?st=" + starttime + "&et=" + endtime;
        else
            urlstr = "./recinfoLoginget.aspx";
        var index = layer.msg('查询中，请稍候', { icon: 16, time: false, shade: 0.8 });
        setTimeout(function () {
            $.ajax({
                url: urlstr,
                type: "get",
                dataType: "json",
                success: function (data) {
                    recData = data;
                    recinfoLoginLoad(starttime, endtime);
                }
            })

            layer.close(index);
        }, 2000);
    })

    //获取指定用户的详细登陆历史信息
    $("body").on("click", ".getLoginRecDetail", function () {  
        var _this = $(this);
        
        window.location.href = "./recinfoLoginDetail.aspx?id=" + _this.attr("data-id") + "&st=" + _this.attr("data-st") + "&et=" + _this.attr("data-et");
    })

    //显示所有用户的简略登陆历史信息
    function recinfoLoginLoad(stime, etime) {
        
        var dataHtml = '';
        if (recData.length != 0) {
            for (var i = 0; i < recData.length; i++) {
                dataHtml += '<tr>'
                    + '<td rowspan="' + recData[i].UserCount.toString() + '">' + recData[i].DeptName + '</td>'
                    + '<td>' + recData[i].DetailInfo[0].Name + '</td>'
                    + '<td>' + recData[i].DetailInfo[0].ByName + '</td>'
                    + '<td>' + recData[i].DetailInfo[0].LastIP + '</td>'
                    + '<td>' + recData[i].DetailInfo[0].LoginCnt + '</td>'
                    + '<td>' + recData[i].DetailInfo[0].LastLoginTime + '</td>'
                    + '<td><a class="layui-btn layui-btn-normal layui-btn-small getLoginRecDetail" data-id="' + recData[i].DetailInfo[0].Name + '" data-st="' + stime + '" data-et="' + etime + '">详细</a></td>'
                    + '</tr>';
                for (var j = 1; j < recData[i].UserCount; j++)
                {
                    dataHtml += '<tr>'
                        + '<td>' + recData[i].DetailInfo[j].Name + '</td>'
                        + '<td>' + recData[i].DetailInfo[j].ByName + '</td>'
                        + '<td>' + recData[i].DetailInfo[j].LastIP + '</td>'
                        + '<td>' + recData[i].DetailInfo[j].LoginCnt + '</td>'
                        + '<td>' + recData[i].DetailInfo[j].LastLoginTime + '</td>'
                        + '<td><a class="layui-btn layui-btn-normal layui-btn-small getLoginRecDetail" data-id="' + recData[i].DetailInfo[j].Name + '" data-st="' + stime + '" data-et="' + etime + '">详细</a></td>'
                        + '</tr>';
                }
            }
        } else {
            dataHtml = '<tr><td colspan="8">暂无数据</td></tr>';
        }
        $(".login_rec").html(dataHtml);
        form.render();
    }

    //显示指定用户的详细登陆历史信息
    //function recinfoLogindetailLoad() {
    //    //渲染数据
    //    function renderData(data, curr) {
    //        var dataHtml = '';
    //        currData = recData.concat().splice(curr * nums - nums, nums);
    //        if (currData.length != 0) {
    //            for (var i = 0; i < currData.length; i++) {
    //                dataHtml += '<tr>'
    //                    + '<td>' + currData[i].NAME + '</td>'
    //                    + '<td>' + currData[i].BYNAME + '</td>'
    //                    + '<td>' + currData[i].DEPARTMENT + '</td>'
    //                    + '<td>' + currData[i].IP + '</td>'
    //                    + '<td>' + currData[i].LOGINTIME + '</td>'
    //                    + '</tr>';
    //            }
    //        } else {
    //            dataHtml = '<tr><td colspan="8">暂无数据</td></tr>';
    //        }
    //        return dataHtml;
    //    }

    //    //分页
    //    var nums = 15; //每页出现的数据量
    //    laypage({
    //        cont: "page",
    //        pages: Math.ceil(recData.length / nums),
    //        jump: function (obj) {
    //            $(".login_rec").html(renderData(recData, obj.curr));
    //            //$('.users_list thead input[type="checkbox"]').prop("checked", false);
    //            form.render();
    //        }
    //    })
    //}
})