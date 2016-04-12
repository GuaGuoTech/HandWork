using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class GuaGuoTool
    {
        public static HtmlString GuaGuo_PhoneNumberCheck(this HtmlHelper htmlHelper)
        {
            string phoneCheck = "<div class=\"form-group\"><label>电话号码：</label><input type=\"Text\" class=\"form-control phoneNum\" placeholder=\"电话号码\" /><div class=\"input-group checkPhonePanel\"><input type=\"text\" class=\"form-control\" id=\"_phoneChek\" placeholder=\"验证码\"><div class=\"input-group-addon checkPhoneBtn btn btn-primary\">发送验证码</div></div><div id=\"phone_info\"></div></div>";
            return new HtmlString(phoneCheck);
        }
    }
}