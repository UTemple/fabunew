layui.config({
    base: "js/"
}).use(['form', 'layer', 'jquery', 'laypage'], function () {
    var form = layui.form(),
        layer = parent.layer === undefined ? layui.layer : parent.layer,
        laypage = layui.laypage,
        $ = layui.jquery;

    //加载下载历史页面
    var recData = '';
    $.get("./recinfoFileOperationget.aspx", function (data) {
        recData = data;
        //加载数据
        recinfoLoad();
    })

    $(".search_btn").click(function () {
        var infoArray = [];

        if ($(".search_input").val() != '') {
            var index = layer.msg('查询中，请稍候', { icon: 16, time: false, shade: 0.8 });
            setTimeout(function () {
                $.ajax({
                    url: "./recinfoFileOperationget.aspx",
                    type: "get",
                    dataType: "json",
                    success: function (data) {
                        recData = data;
                        for (var i = 0; i < recData.length; i++) {
                            var infoStr = recData[i];
                            var selectStr = $(".search_input").val();
                            function changeStr(data) {
                                var dataStr = '';
                                var showNum = data.split(eval("/" + selectStr + "/ig")).length - 1;
                                if (showNum > 1) {
                                    for (var j = 0; j < showNum; j++) {
                                        dataStr += data.split(eval("/" + selectStr + "/ig"))[j] + "<i style='color:#03c339;font-weight:bold;'>" + selectStr + "</i>";
                                    }
                                    dataStr += data.split(eval("/" + selectStr + "/ig"))[showNum];
                                    return dataStr;
                                } else {
                                    dataStr = data.split(eval("/" + selectStr + "/ig"))[0] + "<i style='color:#03c339;font-weight:bold;'>" + selectStr + "</i>" + data.split(eval("/" + selectStr + "/ig"))[1];
                                    return dataStr;
                                }
                            }
                            //
                            if (infoStr.FILETYPE.indexOf(selectStr) > -1) {
                                infoStr["FILETYPE"] = changeStr(infoStr.FILETYPE);
                            }
                            //
                            if (infoStr.FILEDETAIL.indexOf(selectStr) > -1) {
                                infoStr["FILEDETAIL"] = changeStr(infoStr.FILEDETAIL);
                            }
                            if (infoStr.FILENAME.indexOf(selectStr) > -1) {
                                infoStr["FILENAME"] = changeStr(infoStr.FILENAME);
                            }
                            if (infoStr.PROJECTNAME.indexOf(selectStr) > -1) {
                                infoStr["PROJECTNAME"] = changeStr(infoStr.PROJECTNAME);
                            }
                            if (infoStr.DOWNLOADUSER.indexOf(selectStr) > -1) {
                                infoStr["DOWNLOADUSER"] = changeStr(infoStr.DOWNLOADUSER);
                            }
                            if (infoStr.DOWNLOADDEPT.indexOf(selectStr) > -1) {
                                infoStr["DOWNLOADDEPT"] = changeStr(infoStr.DOWNLOADDEPT);
                            }
                            //
                            if (infoStr.DOWNLOADDATE.indexOf(selectStr) > -1) {
                                infoStr["DOWNLOADDATE"] = changeStr(infoStr.DOWNLOADDATE);
                            }
                            if (infoStr.FILEBELONG.indexOf(selectStr) > -1) {
                                infoStr["FILEBELONG"] = changeStr(infoStr.FILEBELONG);
                            }
                            if (infoStr.OPTTYPE.indexOf(selectStr) > -1) {
                                infoStr["OPTTYPE"] = changeStr(infoStr.OPTTYPE);
                            }

                            if (infoStr.FILETYPE.indexOf(selectStr) > -1 || infoStr.FILEDETAIL.indexOf(selectStr) > -1 || infoStr.FILENAME.indexOf(selectStr) > -1
                                || infoStr.PROJECTNAME.indexOf(selectStr) > -1 || infoStr.DOWNLOADUSER.indexOf(selectStr) > -1 || infoStr.DOWNLOADDEPT.indexOf(selectStr) > -1
                                || infoStr.DOWNLOADDATE.indexOf(selectStr) > -1 || infoStr.FILEBELONG.indexOf(selectStr) > -1 || infoStr.OPTTYPE.indexOf(selectStr) > -1) {
                                infoArray.push(infoStr);
                            }
                        }
                        recData = infoArray;
                        recinfoLoad();
                    }
                })

                layer.close(index);
            }, 2000);
        } else {
            layer.msg("请输入需要查询的内容");
        }
    })

    function recinfoLoad() {
        //渲染数据
        function renderDate(data, curr) {
            var dataHtml = '';
            var filebelongstr = '';
            currData = recData.concat().splice(curr * nums - nums, nums);
            if (currData.length != 0) {
                for (var i = 0; i < currData.length; i++) {
                    if (currData[i].PROJECTNAME.length > 0)
                        filebelongstr = currData[i].PROJECTNAME;
                    else if (currData[i].FILEBELONG.length > 0)
                        filebelongstr = currData[i].FILEBELONG;
                    else filebelongstr = '';
                    dataHtml += '<tr>'
                        + '<td>' + currData[i].FILETYPE + '</td>'
                        + '<td>' + currData[i].FILEDETAIL + '</td>'
                        + '<td>' + currData[i].FILENAME + '</td>'
                        + '<td>' + filebelongstr + '</td>'
                        + '<td>' + currData[i].OPTTYPE + '</td>'
                        + '<td>' + currData[i].DOWNLOADUSER + '</td>'
                        + '<td>' + currData[i].DOWNLOADDEPT + '</td>'
                        + '<td>' + currData[i].DOWNLOADDATE + '</td>'
                        + '</tr>';
                }
            } else {
                dataHtml = '<tr><td colspan="8">暂无数据</td></tr>';
            }
            return dataHtml;
        }

        //分页
        var nums = 15; //每页出现的数据量
        laypage({
            cont: "page",
            pages: Math.ceil(recData.length / nums),
            jump: function (obj) {
                $(".fileoperation_rec").html(renderDate(recData, obj.curr));
                //$('.users_list thead input[type="checkbox"]').prop("checked", false);
                form.render();
            }
        })
    }

})