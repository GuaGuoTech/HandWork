using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace System.Web.Mvc
{
    public static class Guaguo_Input
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
        public static HtmlString GuaGuo_LableWithTitle(this HtmlHelper helper, string id, string text)
        {
            var builder = new TagBuilder();


        }

        /// <summary>
        /// 带标题的input标签
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">id</param>
        /// <param name="title">标题</param>
        /// <param name="placeholder">文本提示</param>
        /// <returns></returns>
        public static HtmlString GuaGuo_InptTextWithTitle(this HtmlHelper helper, string id, string title, string placeholder = "",string type="text")
        {
            var _div = new TagBuilder("div");
            _div.MergeAttribute("class", "form-group");

            var _lable = new TagBuilder("label");
            _lable.MergeAttribute("for",id);
            _lable.SetInnerText(title);
            var _input = new TagBuilder("input");

            _input.MergeAttribute("class","form-control");
            _input.MergeAttribute("type",type);
            _input.MergeAttribute("placeholder",placeholder);
            _input.MergeAttribute("name", id);
            _input.IdAttributeDotReplacement = "-";
            _input.GenerateId(id);

            _div.InnerHtml = _lable.ToString() + _input.ToString();

            return new HtmlString(_div.ToString());
        }
      
    }
}