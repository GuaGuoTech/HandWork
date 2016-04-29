$(function () {
    $("#submit").click(function () {
        var   _doom =  $(this);
        $(this).val("正在发布");
        var phone = $(_phoneNum).val();
        if (phone == "") {
            $(_info).text("请输入电话号码");
        }


        var _postData = {
            Title: $("#Title").val(),
            Words: $("#Words").val(),
            WorkTime: $("#WorkTime").val(),
            WorkDate: $("#WorkDate").val() + "至" + $("#WorkEndDate").val(),
            Money: $("#Money").val(),
            Location: $("#Location").val(),
            MaxNum: $("#MaxNum").val(),
            Man: $("#Man").val(),
            PhoneNum: $("#PhoneNum").val(),
            Requirement: $("#Requirement").val(),
            PayType: $("#PayType option:selected").attr("value"),
            Sex: $("#Sex option:selected").attr("value"),
            Note:$("#Note").val(),
        }


        $.ajax({
            url: url+"/Details/Recruit/AddRecruit",
            type: "POST",
            data: _postData,
            dataType:"JSON",
            cache: false,
            success: function (data) {
                
                _doom.val("发布成功");

                location.href = url + "/Details/Detail"/+data.Id;
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

                $(_info).text(XMLHttpRequest.status + "错误信息" + XMLHttpRequest.readyState + ".," + textStatus + "," + errorThrown);

            }


        });



        //时间


    })
});


///日期选择 
$("#WorkDate").datetimepicker({
    format: 'yyyy-mm-dd',
    language: 'zh-CN',
    minView: 'month',
    autoclose:true,
});
$("#WorkEndDate").datetimepicker({
    format: 'yyyy-mm-dd',
    language: 'zh-CN',
    minView: 'month',
    autoclose: true,

});
