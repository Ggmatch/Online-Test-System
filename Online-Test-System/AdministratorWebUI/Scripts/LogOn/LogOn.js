﻿/**
 * 主处理
 */
$(function () {
    // 登录按钮处理
    $("#login").click(login);
});

/**
 * 登录处理
 */
function login() {
    // 清除提示信息
    $("#count_span").html("");
    $("#password_span").html("");
    // 1.获取请求参数
    // var 属性名,要与controlller层一致
    var userName = $("#username").val().trim(); // .trim()去空
    var password = $("#password").val().trim();

    // 2.检查参数格式
    // true通过检测;false未通过检测
    var check = true;
    if (userName == "") {
        $("#count_span").html("用户名为空");
        check = false;
    }
    if (password == "") {
        $("#password_span").html("密码为空");
        check = false;
    }
    var url = "http://localhost/api/administrator/test";
    // 3.发送Ajax请求
    //if (check) {  
    //    $.ajax({
    //        url: "http://localhost:2838/api/administrator/canlogon",
    //        type: "post",
    //        data: {
    //            // ""引号内要与controller参数保持一致
    //            // : 后的要与上面的var 属性名 保持一致
    //            "userName": userName,
    //            "password": password
    //        },
    //        dataType: "json",
    //        // ajax的回调函数:发送请求经过后台处理将结果返回到此函数中,并利用js将页面更新
    //        // result 是后台controller返回的一个json格式的数据result
    //        success: function (result) {
    //            if (result == '0') { // 0 表示登录成功
    //                // 跳转到指定页面
    //                //window.location.href = "administrator.html";
    //                alert("pass!");

    //            }
    //            else {
    //                // 弹出“错误提示信息”
    //                alert("用户名或密码有错，请重新输入！");
    //            }
    //        },
    //        error: function () {
    //            alert("登录异常");
    //        }
    //    });

    // 4.测试
    $.getJSON(url)
        .done(function (data) {
            alert(data);
        })
        .fail(alert("fail"));
};