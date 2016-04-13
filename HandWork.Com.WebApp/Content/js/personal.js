//按钮
var _checkPhoneBtn = $(".checkPhoneBtn");
//提示信息控件
var _info = $("#phone_info");

//电话号码
var _phoneNum = $(".phoneNum");
$(function () {

    $(_checkPhoneBtn).click(function () {

        var  phone =$(_phoneNum).val();
        if (phone == "") {
            $(_info).text("请输入电话号码");
        }
        else {
            sendMssg(phone);
        }
    });
})

///清空消息提示以及重置按钮
function clear() {

    $(_info).text("");
}


function sendMssg(phone) {


    $.ajax({
        url: "../User/SendMssg",
        type:"POST",
        data: { "number": phone },
        success: function (data) {
            alert(data);
        }
    });


}