﻿$(function () {


    $("#askForThisJob").click(function () {


        var _data = {

            WeixinUserId: "",
            RecuitId: $(this).attr("value"),

        }
        $.ajax({
            url: url + "/Relations/Relation/AddRelation",
            type: "POST",
            data: _data,
            dataType: "JSON",
            cache: false,
            success: function (data) {
                if (data==false) {

                    window.location.href = url+"Users/User/WeiXinMSG";
                }
                else {
                    location.reload();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

                $(_info).text(XMLHttpRequest.status + "错误信息" + XMLHttpRequest.readyState + ".," + textStatus + "," + errorThrown);

            }
        });






    });



})