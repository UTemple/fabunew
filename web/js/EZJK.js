
//自动刷新日期-时间
function autoDateTime(elemId,ms) {
    document.getElementById(elemId).innerHTML = "服务器时间：" + serDateTime();
   // var str = "autoDateTime(\"" + elemId + "\")";
    setTimeout("autoDateTime(\"" + elemId + "\")", 1000);
}
//获取系统日期-时间
var serverDate;
$.ajax({ type: "OPTIONS", url: "/", complete: function (x) { serverDate = x.getResponseHeader("Date") } })
function serDateTime() {
    var date;
    $.ajax({type: "OPTIONS", url: "/", complete: function (x) {serverDate = x.getResponseHeader("Date")}});
    var now = new Date(serverDate);
    var year = now.getFullYear();
    var month = now.getMonth() + 1;
    var day = now.getDate();
    var hour = now.getHours();
    var min = now.getMinutes();
    var sec = now.getSeconds();
    return year + '年' + OO(month) + '月' + OO(day) + '日 ' + OO(hour) + ':' + OO(min) + ':' + OO(sec);
}
//获取系统日期-时间
function sysDateTime() {
    var now = new Date();
    var year = now.getFullYear();
    var month = now.getMonth() + 1;
    var day = now.getDate();
    var hour = now.getHours();
    var min = now.getMinutes();
    var sec = now.getSeconds();
    return year + '年' + OO(month) + '月' + OO(day) + '日 ' + OO(hour) + ':' + OO(min) + ':' + OO(sec);
}
//两位补0
function OO(num) {
    return (Array(2).join(0) + num).slice(-2)
}

