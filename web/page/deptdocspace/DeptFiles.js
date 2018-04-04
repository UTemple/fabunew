layui.config({
    base: "js/"
}).use(['form', 'layer', 'jquery', 'laypage'], function () {
    var form = layui.form(),
        layer = parent.layer === undefined ? layui.layer : parent.layer,
        laypage = layui.laypage,
        $ = layui.jquery;

    function GetQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null)
            return unescape(r[2]);
        return null;
    }
    var dept_id = GetQueryString("deptid");


    $("body").on("click", ".downloadfile", function () {  //下载
        var _this = $(this);
        window.open("./DeptFilesDownload.aspx?fileid=" + _this.attr("data-id"));
    })

    //删除
    $("body").on("click", ".deletefile", function () {
        var _this = $(this);
        //window.open("./ShuiGongErSuoDocSpace.aspx?deptid=" + dept_id + "&deleteid=" + _this.attr("data-id"));
        parent.location.href = "./ShuiGongErSuoDocSpace.aspx?deptid=" + dept_id + "&deleteid=" + _this.attr("data-id");
    })
})