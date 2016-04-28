

var jobIndex = function (obj) {
    var _sex = "男生";
    var _payType = "日结";


    var _link = $("<a></a>");
    _link.prop("href",url+"Details/Detail/Index/"+obj.recuit.Id);

    var _kindsborderDiv = $("<div></div>");
    _kindsborderDiv.addClass("kindsborderDiv  bordertop");
    _kindsborderDiv.appendTo(_link);




    var _Centerimage = $("<div></div>");
    _Centerimage.addClass("col-xs-2 floatCenter Centerimage");
    _Centerimage.appendTo(_kindsborderDiv);

    var _image2 = $("<img/>");
    _image2.addClass("image2");
    //
    _image2.prop("src", obj.weixinUser.headimgurl);
    _image2.appendTo(_Centerimage);

    var _floatCenter = $("<div></div>");
    _floatCenter.addClass("col-xs-10  floatCenter");
    _floatCenter.appendTo(_kindsborderDiv);


    var _h5 = $("<h5></h5>");
    //
    _h5.text(obj.recuit.Title);
    _h5.appendTo(_floatCenter);


    var _labela = $("<span></span>");
    _labela.addClass("label label-info labela");
    //

    if (obj.recuit.PayType==1) {
        _payType = "周结";
    }
    else if (obj.recuit.PayType == 0) {
        _payType = "日结";
    }
    else if (obj.recuit.PayType == 2) {
        _payType = "月结";
    }
    else {
        _payType = "其他";
    }
    _labela.text(_payType);
    _labela.appendTo(_floatCenter);

    var _labelB = $("<span></span>");
    _labelB.addClass("label label-info labela");
    //
    _labelB.text(obj.recuit.Words);
    _labelB.appendTo(_floatCenter);

    var _labelC = $("<span></span>");
    _labelC.addClass("label label-info labela");
    //
    if (obj.recuit.Sex==0) {
        _sex = "女生"
    }
    else if (obj.recuit.Sex == 1) {
        _sex = "男生"

    }
    else {
       _sex="不限"
    }
    _labelC.text(_sex);
    _labelC.appendTo(_floatCenter);


    var _div = $("<div></div>");
    _div.appendTo(_floatCenter);

    var _oclockfont = $("<span></span>");
    _oclockfont.addClass("oclockfont labela");
    ///时间
    _oclockfont.text("三天前");
    _oclockfont.appendTo(_div);

    var _span = $("<span></span>");
    _span.appendTo(_div);
    
    var _timeImg = $("<img/>");
    _timeImg.addClass("oclockimage labelb");
    _timeImg.prop("src", "/Content/image/o'clock.png");
    _timeImg.appendTo(_span);


    return _link;

};
///控制分页  表明第几页
var _num = 1;

//容器
var _jobList = $(".jobList");

//类型
var _type = 4;

var  _baseUrl="http://localhost:23440/";
function getAllEntity(type) {
    var _data = {
        type: type,
        pageNum: _num,
    };

    $('.clickMore').unbind("click"); //移除click


    $(".clickMore").text("正在加载");


    $.ajax({
        url: _baseUrl + "/Homs/Home/GetJobList",
        type: "POST",
        data: _data,
        dataType:"JSON",
        cache: false,
        success: function (data) {
            if (data.length>0) {

                for (var i = 0; i < data.length; i++) {
                    jobIndex(data[i]).appendTo(_jobList);

                }
                $(".clickMore").text("点击加载更多");

                bindClickMoreEvent();

            }
            else {
                $(".clickMore").text("没有更多了");
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            $(_info).text(XMLHttpRequest.status + "错误信息" + XMLHttpRequest.readyState + ".," + textStatus + "," + errorThrown);

        }

    });


}

$(function () {

 
    getAllEntity(4);

    $(".classify li").click(function () {
        bindClickMoreEvent();
        $(_jobList).empty();
        _num = 1;
         _type = $(this).attr("value");
         getAllEntity(_type);

    });

    ///点击加载更多的事件


    bindClickMoreEvent();

});

//绑定事件
function bindClickMoreEvent()
{
    $(".clickMore").on('click', function () {
        $(this).text("点击加载更多");
        _num++;
        getAllEntity(_type);
    });

}
