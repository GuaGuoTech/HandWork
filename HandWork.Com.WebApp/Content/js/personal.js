//按钮
var _checkPhoneBtn = $(".checkPhoneBtn");
//提示信息控件
var _info = $("#phone_info");

//电话号码
var _phoneNum = $(".phoneNum");

//表单提交按钮
var _formSubmit = $("#form_submit");

/// baseUrl
var url = "http://120.27.104.135/";

///带提示框的消息框
var $GuaGuoTech_Alert = function (content) {
    var _body = $("body");
    var _divStr = "<div class=\"modal fade GuaGuoAlert\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"mySmallModalLabel\"><div class=\"modal-dialog modal-sm\"><div class=\"modal-content\"><div class=\"modal-header\"><button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button><h4 class=\"modal-title\" id=\"myModalLabel\">提示</h4></div><div class=\"modal-body\">" + content + "</div><div class=\"modal-footer\"><a  class=\"btn btn-default\" data-dismiss=\"modal\">关闭</a></div></div></div></div>";
    $(_divStr).appendTo(_body);
    $(".GuaGuoAlert").modal("show");
};

///带跳转地址的信息框
var $GuaGuoTech_Alert_Url = function (content,_url) {
    var _body = $("body");
    var _divStr = "<div class=\"modal fade GuaGuoAlert\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"mySmallModalLabel\"><div class=\"modal-dialog modal-sm\"><div class=\"modal-content\"><div class=\"modal-header\"><button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button><h4 class=\"modal-title\" id=\"myModalLabel\">提示</h4></div><div class=\"modal-body\">" + content + "</div><div class=\"modal-footer\"><a  class=\"btn btn-default\" data-dismiss=\"modal\">关闭</a><a href=" + _url+url + " class=\"btn btn-primary\">" + "GO" + "</a></div></div></div></div>";
    $(_divStr).appendTo(_body);
    $(".GuaGuoAlert").modal("show");
};

///提交验证码的点击事件
$(function () {
    $(_checkPhoneBtn).click(function () {
        var phone = $(_phoneNum).val();
        if (phone == "") {
            $(_info).text("请输入电话号码");
        }
        else {
            sendMssg(phone);
        }
    });
    $(_formSubmit).click(function () {
        formCheckData();
    });
})
///清空消息提示以及重置按钮
function clear() {
    $(_info).text("");
}
var code = "";
///时间控制
var _time = 0;
//次数
var times = 0;
///发送验证码
function sendMssg(phone) {
    $.ajax({
        url: url+"/Users/User/SendMssg",
        type: "POST",
        data: { "number": phone },
        cache: false,
        success: function (data) {
            data = JSON.parse(data);
            var statusCode = data.statusCode;
            if (statusCode == "111109") {
                if (times>3) {
                    $(_info).text("发送失败 请检查号码或者联系网站管理员");

                }
                else {
                    ///重新发一次
                    sendMssg(phone);
                }                
            }
            else if (statusCode == "000000") {
                textChange();   
            }
            else {
                $(_info).text("发送失败 请检查号码或者联系网站管理员");
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            $(_info).text(XMLHttpRequest.status + "错误信息" + XMLHttpRequest.readyState + ".," + textStatus + "," + errorThrown);

        }

    });
}
//倒计时程序
function textChange() {
    $(_checkPhoneBtn).attr("disabled", true);
    _time = 60;
  var  interval =  setInterval(function () {

        _time--;
        if (_time > 0) {
            $(_checkPhoneBtn).text("重新发送" + "(" + _time + ")");
        }
        else {
            $(_checkPhoneBtn).text("发送验证码");
            $(_checkPhoneBtn).removeAttr("disabled");
            clearInterval(interval);
            return false;
        }
    }, 1000);
  
}
///表单提交的验证
function formCheckData() {
    var _code = $("#_phoneChek").val();
    $(_info).text("");
    $(_formSubmit).val("正在提交");
    $(_formSubmit).attr("disabled","disabled");
    if (_code!="") {
        $.ajax({
            url: url + "/Users/User/CheckCode",
            type: "POST",
            data: { "code": _code },
            cache: false,
            success: function (data) {
                $(_formSubmit).removeAttr("disabled");
                $(_formSubmit).val("确定");
                data = JSON.parse(data);
                if (!data) {
                    $(_info).text("验证码错误");
                    return false;
                }
                else {
                    $(_formSubmit).parents("form").submit();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

                $(_info).text(XMLHttpRequest.status + "错误信息" + XMLHttpRequest.readyState + ".," + textStatus + "," + errorThrown);

            }

        });

    }
    else {
        $(_formSubmit).removeAttr("disabled");
        $(_formSubmit).val("确定");
        $(_info).text("请输入验证码");
        return false;

    }
}