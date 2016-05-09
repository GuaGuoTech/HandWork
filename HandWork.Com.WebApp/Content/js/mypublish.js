
///控制分页  表明第几页
var _num = 1;

//容器
var _jobList = $(".jobList");

//类型
var _type = 4;


$(function () {

    guaGuofinalUrl = "/Users/User/MyPublishRecruit";
    getAllEntity(4, guaGuofinalUrl);

    setMassageCount();



    ///点击加载更多的事件
    bindClickMoreEvent();




});





