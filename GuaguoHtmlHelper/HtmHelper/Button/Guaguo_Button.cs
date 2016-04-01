using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace System.Web.Mvc
{
    public static class Guaguo_Button
    {
        public static HtmlString GuaGuo_Button(this HtmlHelper helper, string id, string text)
        {
            //创建某一个Tag的TagBuilder
            var builder = new TagBuilder("input");

            //创建Id,注意要先设置IdAttributeDotReplacement属性后再执行GenerateId方法.
            builder.IdAttributeDotReplacement = "-";
            builder.GenerateId(id);

            builder.MergeAttribute("name", id);
            //添加样式
            builder.MergeAttribute("class", "btn btn-primary");
            builder.MergeAttribute("type", "button");
            builder.MergeAttribute("value", text);


            //添加内容,以下两种方式均可
            //builder.InnerHtml = text;
            //builder.SetInnerText(text);
            //输出控件
            return new HtmlString(builder.ToString());

        }

      
    }
}