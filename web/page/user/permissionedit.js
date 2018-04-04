layui.config({
	base : "js/"
}).use(['form','layer','jquery','element'],function(){
	var form = layui.form(),
		layer = parent.layer === undefined ? layui.layer : parent.layer,
		laypage = layui.laypage,
        element = layui.element();
		$ = layui.jquery;

 	//var addUserArray = [],addUser;
        form.on("submit(editUserPer)", function (data) {
            if ($("#perstyle").val() != 5)//自定义权限
            {
                layer.confirm('将按照指定的用户等级改变权限，自定义的修改无效，是否确定？', { icon: 3, title: '提示' }, function (index) {
                    var subdiv = document.getElementById("isSubmit");
                    subdiv.value = "1";
                    layer.close(index);
                    document.getElementById("form1").submit();
                });
            }
            else {
                var subdiv = document.getElementById("isSubmit");
                subdiv.value = "1";
                document.getElementById("form1").submit();
            }
 		    
 	})

      form.on("select(InputPerStyle)", function (data) {
          var tmpdiv;
          if (data.value == "5") {//自定义权限
              $("#collapseDiv input").each(function () {
                  tmpdiv = $(this);
                  $(this).removeAttr("disabled");
              });
              $("#collapseDiv").find("div").removeClass("layui-radio-disbaled layui-checkbox-disbaled layui-disabled");
          }
          else {
              $("#collapseDiv input").each(function () {
                  tmpdiv = $(this);
                  $(this).attr("disabled", true);
                  //$(this).addClass("layui-radio-disbaled layui-checkbox-disbaled layui-disabled");
              });
              $("#collapseDiv").find("div.layui-unselect.layui-form-radio").addClass("layui-radio-disbaled layui-disabled");
              $("#collapseDiv").find("div.layui-unselect.layui-form-switch").addClass("layui-checkbox-disbaled layui-disabled");
          }
    })
})

function btnCancel() {
    window.location.href = "userManager.aspx";
}