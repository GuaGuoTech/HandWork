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
            string phoneCheck = "<div class=\"form-group\"><label>电话号码：</label><div class=\"input-group\"><input type=\"text\" class=\"form-control\" id=\"_phoneNumber\" placeholder=\"电话号码\"><div class=\"input-group-addon btn btn-primary\">发送验证码</div></div><div id=\"phone_info\"></div></div>";
            return new HtmlString(phoneCheck);
        }
    }
}