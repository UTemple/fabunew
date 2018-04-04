var $;

function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}
var tablename = GetQueryString("table");    //要统计的数据类型（排水管道或排水沟渠或窨井或雨水口）
var sumtype = GetQueryString("sumtype");    //统计类别：行政区或权属单位
var chartname = ''; //图表名称
var chartdata = []; //图表使用的数据数组

layui.config({
	base : "js/"
}).use(['form','layer','jquery'],function(){
	var form = layui.form(),
		layer = parent.layer === undefined ? layui.layer : parent.layer,
		laypage = layui.laypage;
		$ = layui.jquery;

    if (sumtype === '2')
        $("#name1").text("权属单位");
    else
        $("#name1").text("行政区");//默认行政区划分

    if (tablename === 'PS_PIPE_ZY') //排水管道
    {
        $("#name2").text("管道总长(m)");
        chartname = '广州市排水管道统计';
    }
    else if (tablename === 'PS_CANAL_ZY') //排水沟渠
    {
        $("#name2").text("沟渠总长(m)");
        chartname = '广州市排水沟渠统计';
    }
    else if (tablename === 'PS_WELL_ZY') //窨井
    {
        $("#name2").text("窨井总数(个)");
        chartname = '广州市窨井统计';
    }
    else if (tablename === 'PS_COMB_ZY') //雨水口
    {
        $("#name2").text("雨水口总数(个)");
        chartname = '广州市雨水口统计';
    } 
    //加载统计页面
    var sumData = '';
    //echarts图表显示
    var myChart = echarts.init(document.getElementById('PieChart'));
    myChart.showLoading();
    $.get("./drainageInfoSumget1.aspx?table=" + tablename + "&sumtype=" + sumtype, function (data) {
        sumData = JSON.parse(data);
        //加载数据
        drainageInfoLoad();
    })

    form.on('select(sumtypefilter)', function (data) {
        window.location.href = "drainageInfoSummary1.aspx?table=" + tablename + "&sumtype=" + data.value;
        //layer.msg(data.value);
    });

    function drainageInfoLoad() {
        var dataHtml = '';
        if (sumData.length != 0) {
            for (var i = 0; i < sumData.length; i++) {
                dataHtml += '<tr>'
                    + '<td>' + sumData[i].SubTypeVal + '</td>'
                    + '<td>' + sumData[i].DataVal + '</td>'
                    + '</tr>';
                if (sumData[i].SubTypeVal !== '总计')
                    chartdata.push({name: sumData[i].SubTypeVal, value: sumData[i].DataVal});
            }
        } else {
            dataHtml = '<tr><td colspan="2">暂无数据</td></tr>';
        }
        $(".drainageinfosum").html(dataHtml);
        form.render();

        // 指定图表的配置项和数据
        var option = {
            title: {
                text: chartname
            },
            tooltip: {},
            //legend: {
            //    data: ['归属']
            //},
            series: [{
                name: '归属',
                type: 'pie',
                radius: '75%',
                center: ['50%', '60%'],
                data: chartdata
            }]
        };

        // 使用刚指定的配置项和数据显示图表。
        myChart.hideLoading();
        myChart.setOption(option);
    }
})
