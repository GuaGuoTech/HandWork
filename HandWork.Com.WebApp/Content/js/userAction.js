//这个是消息页面相关的一些js
var _ids = function(){
    var ids = "";
    $(".checkThisAction").each(function () {
        console.log($(this).is(":checked"));
        if ($(this).is(":checked")==true) {
                ids += $(this).attr("value") + ",";
            }
        
       

    });

    return ids;

};

$(function () {

    var _actionButton = $(".postIds");
    _actionButton.click(function () {
        var ids = _ids();
        if (checkIdsNotNull(ids) == 0) {
            console.log(ids);
            alert("勾选任何一条请求");
        }
        else {
            dealWithThis(ids, $(this));
        }
    });

    changeRead();



})


function changeRead() {

    var _panel = $(".askIdPanel");
    var ids = "";
    for (var i = 0; i < _panel.length; i++) {
        ids += $(_panel[i]).attr("key")+",";
    }
    console.info(ids);
    if (ids.length > 0) {


        $.ajax({
            url: url + "Relations/Relation/ChangeRead",
            type: "POST",
            data: { "ids": ids },
            cache: false,
            success: function (data) {

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest.status + "错误信息" + XMLHttpRequest.readyState + ".," + textStatus + "," + errorThrown);
            }
        });
    }
}


function dealWithThis(ids, obj) {
    var _thisId = $(obj).attr("id");
    var _url = "";
    console.info(_thisId);
    if (_thisId == "acceptCheck") {
        _url = "Relations/Relation/AcceptThisChecked";
    }
    else {
        _url = "Relations/Relation/RefuseThisChecked";
    }

    $.ajax({
        url: url + _url,
        type: "POST",
        data: { "ids": ids },
        cache: false,
        success: function (data) {
     
                localtion.href.reload();
            
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

           alert(XMLHttpRequest.status + "错误信息" + XMLHttpRequest.readyState + ".," + textStatus + "," + errorThrown);

        }

    });






}



function checkIdsNotNull(ids) {
    if (ids=="") {
        return 0;
    }
    else {
        return 1;
    }


}


