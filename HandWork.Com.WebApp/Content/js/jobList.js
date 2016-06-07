
///控制分页  表明第几页
var _num = 1;

//容器
var _jobList = $(".jobList");

//类型
var _type = 4;


$(function () {

    guaGuofinalUrl = "/Homs/Home/GetJobList";
    getAllEntity(4, guaGuofinalUrl);

    setMassageCount();

    $(".classify li").click(function () {
        bindClickMoreEvent();
        $(_jobList).empty();
        _num = 1;
         _type = $(this).attr("value");
         getAllEntity(_type, guaGuofinalUrl);

    });
     
    bindClickMoreEvent();

  
    

});





