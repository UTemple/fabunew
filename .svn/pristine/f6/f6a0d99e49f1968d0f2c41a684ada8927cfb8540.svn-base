layui.config({
    base: "js/"
}).use(['form', 'layer', 'jquery', 'laypage'], function () {
    var form = layui.form(),
        layer = parent.layer === undefined ? layui.layer : parent.layer,
        laypage = layui.laypage;
        $ = layui.jquery;

    $("body").on("click", ".downloadfile", function () {  //下载
        var _this = $(this);
        //window.open("./cloudDiskFileOper.ashx?type=0&fileid=" + _this.attr("data-id"));
        window.location.href = "./cloudDiskFileOper.ashx?type=0&fileid=" + _this.attr("data-id");
    })

    $("body").on("click", ".deletefile", function () {  //删除
        var _this = $(this);
        //window.open("./cloudDiskFileOper.aspx?type=1&fileid=" + _this.attr("data-id"));
        layer.confirm('确定删除此文件？', { icon: 3, title: '提示信息' }, function (index) {
            window.location.href = "./cloudDiskFileOper.ashx?type=1&fileid=" + _this.attr("data-id");
            layer.close(index);
        });
    })
})

//function deletefile(obj) {  //删除
//    var _this = jQuery(obj);


//    jQuery.ajax({
//        type: "POST",    //页面请求的类型，通常使用POST,那么处理页需要使用Request.Form["参数名称"]来获取页面传递的参数
//        url: "cloudDiskFileOper.ashx",   //处理页的相对地址
//        data: { 'type': '1', 'fileid': _this.attr("data-id")}
//    });
//}