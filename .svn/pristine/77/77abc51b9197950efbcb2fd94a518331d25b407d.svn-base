var $;

function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}
var tablename = GetQueryString("Select2");    //要统计的数据类型（排水管道或排水沟渠或窨井或雨水口）
var sumtype = GetQueryString("sumtype");    //统计类别：行政区或权属单位
var attr = GetQueryString("Select1");    //属性：雨污类别或管径
var chartname = ''; //图表名称
var chartdata = []; //图表使用的数据数组

layui.config({
	base : "js/"
}).use(['form','layer','jquery'],function(){
	var form = layui.form(),
		layer = parent.layer === undefined ? layui.layer : parent.layer,
		laypage = layui.laypage;
		$ = layui.jquery;

    var str1 = '';
    if (attr === '2')
    {
        if (tablename === 'PS_PIPE_ZY')
            str1 = "管径";
        else str1 = "渠宽";
    }
    else
        str1 = "雨污类别";
    if (sumtype === '2')
        $("#name1").text("权属单位 \\ "+str1);
    else
        $("#name1").text("行政区 \\ " + str1);//默认行政区划分

    if (attr === '2')//按管径或渠宽
    {
        if (tablename === 'PS_PIPE_ZY') //排水管道
        {
            $("#name2").text("管径≤300mm(m)");
            $("#name3").text("300mm<管径<600mm(m)");
            $("#name4").text("管径≥600mm(m)");
            $("#name5").text("小计(m)");
            chartname = '广州市排水管道统计';
        }
        else if (tablename === 'PS_CANAL_ZY') //排水沟渠
        {
            $("#name2").text("渠宽<1m(m)");
            $("#name3").text("1m≤渠宽<2m(m)");
            $("#name4").text("渠宽≥2m(m)");
            $("#name5").text("小计(m)");
            chartname = '广州市排水沟渠统计';
        }
    }
    else //默认按雨污类别
    {
        if (tablename === 'PS_PIPE_ZY') //排水管道
        {
            $("#name2").text("污水(m)");
            $("#name3").text("雨水(m)");
            $("#name4").text("雨污合流(m)");
            $("#name5").text("小计(m)");
            chartname = '广州市排水管道统计';
        }
        else if (tablename === 'PS_CANAL_ZY') //排水沟渠
        {
            $("#name2").text("污水(m)");
            $("#name3").text("雨水(m)");
            $("#name4").text("雨污合流(m)");
            $("#name5").text("小计(m)");
            chartname = '广州市排水沟渠统计';
        }
    }
        if (tablename === 'PS_WELL_ZY') //窨井
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
    $.get("./drainageInfoSumget.aspx?Select2=" + tablename + "&sumtype=" + sumtype + "&Select1=" + attr, function (data) {
        sumData = JSON.parse(data);
        //加载数据
        drainageInfoLoad();
    })

    form.on('select(Select2filter)', function (data) {
        window.location.href = "drainageInfoSummary.aspx?Select2=" + data.value + "&sumtype=" + sumtype + "&Select1=" + attr;
        //layer.msg(data.value);
    });
    form.on('select(sumtypefilter)', function (data) {
        window.location.href = "drainageInfoSummary.aspx?Select2=" + tablename + "&sumtype=" + data.value + "&Select1=" + attr;
        //layer.msg(data.value);
    });
    form.on('select(Select1filter)', function (data) {
        window.location.href = "drainageInfoSummary.aspx?Select2=" + tablename + "&sumtype=" + sumtype + "&Select1=" + data.value;
        //layer.msg(data.value);
    });

    function drainageInfoLoad() {
        var dataHtml = '';
        //var attrcount = 0;//一个行政区或权属单位的数据根据雨污类别或者管径（渠宽）分为3类
        var alreadydoneowner = [];//已经处理过的行政区或单位
        var tmpdataval = [0,0,0];
        var tmpowenstr = 'Init';//当前数据所属的行政区或权属单位
        if (sumData.length != 0) {
            for (var i = 0; i < sumData.length; i++) {
                var alreadydonesstatus = 0;
                for (var j = 0; j < alreadydoneowner.length; j++)
                {
                    if (alreadydoneowner[j] == sumData[i].SubTypeVal)
                    {
                        alreadydonesstatus = 1;
                        break;
                    }
                }
                if (alreadydonesstatus == 1)
                    continue;
                for (var k = 0; k < sumData.length; k++)
                {
                    if (sumData[i].SubTypeVal == sumData[k].SubTypeVal)
                    {
                        if (sumData[k].SubType2Val == '污水' || sumData[k].SubType2Val == '管径≤300mm' || sumData[k].SubType2Val == '渠宽<1m') {
                            tmpdataval[0] = sumData[k].DataVal;
                        }
                        else if (sumData[k].SubType2Val == '雨水' || sumData[k].SubType2Val == '300mm<管径<600mm' || sumData[k].SubType2Val == '1m≤渠宽<2m')
                        {
                            tmpdataval[1] = sumData[k].DataVal;
                        }
                        else if (sumData[k].SubType2Val == '雨污合流' || sumData[k].SubType2Val == '管径≥600mm' || sumData[k].SubType2Val == '渠宽≥2m') {
                            tmpdataval[2] = sumData[k].DataVal;
                        }
                    }
                }
                dataHtml += '<tr>'
                    + '<td>' + sumData[i].SubTypeVal + '</td>'//行政区或权属单位
                    + '<td>' + tmpdataval[0] + '</td>'
                    + '<td>' + tmpdataval[1] + '</td>'
                    + '<td>' + tmpdataval[2] + '</td>'
                    + '<td>' + (tmpdataval[0] + tmpdataval[1] + tmpdataval[2]).toFixed(2) + '</td>'
                    + '</tr>';
                alreadydoneowner.push(sumData[i].SubTypeVal);
                
                if (sumData[i].SubTypeVal !== '总计')
                    chartdata.push({ name: sumData[i].SubTypeVal, value: (tmpdataval[0] + tmpdataval[1] + tmpdataval[2]).toFixed(2) });
                tmpdataval = [0, 0, 0];
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
