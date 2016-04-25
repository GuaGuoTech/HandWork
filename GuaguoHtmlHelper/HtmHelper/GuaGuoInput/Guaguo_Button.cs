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

            var builder = new TagBuilder("lable");
            builder.IdAttributeDotReplacement = "";
            builder.GenerateId(id);
            builder.MergeAttribute("name",id);
            builder.MergeAttribute("valuer", text);
            builder.SetInnerText(text);
            //builder.MergeAttribute("class",)
            return new HtmlString(builder.ToString());

        }

        /// <summary>
        /// 带标题的RadioButton标签
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">id</param>
        /// <param name="title">标题</param>
        ///  <param name="subone">第一选项</param>
        /// <param name="subtwo">第二选项</param>
        /// <returns></returns>
        public static HtmlString GuaGuo_RadioButtonWithTitle(this HtmlHelper helper,string id,string title,string subone,string subtwo)
        {
            var _div=new TagBuilder("div");
            _div.MergeAttribute("class","form-group");
            


            var _lable = new TagBuilder("lable");
            _lable.MergeAttribute("for",id);
            _lable.SetInnerText(title);

            var _suboneradiobtn = new TagBuilder("input");
            _suboneradiobtn.MergeAttribute("type", "radio");
            _suboneradiobtn.MergeAttribute("name", "radio");
            //_suboneradiobtn.MergeAttribute("class", "radio");
            _suboneradiobtn.MergeAttribute("id", "suboneradionbtn");
            _suboneradiobtn.MergeAttribute("value",subone);
            _suboneradiobtn.MergeAttribute("text",subone);
            _suboneradiobtn.SetInnerText(subone);

     
            var _subtworadiobtn = new TagBuilder("input");
            _subtworadiobtn.MergeAttribute("type", "radio");
            _subtworadiobtn.MergeAttribute("name", "radio");
            //_subtworadiobtn.MergeAttribute("class", "radio");
            _subtworadiobtn.MergeAttribute("value", subtwo);
            _subtworadiobtn.MergeAttribute("id", "subtworadiobtn");
            _subtworadiobtn.SetInnerText(subtwo);

           

            _div.InnerHtml = _lable.ToString() + _suboneradiobtn.ToString() + _subtworadiobtn.ToString() ;


            return new  HtmlString(_div.ToString());
        }

        public static HtmlString GuaGuo_CheckBoxWithTitle(this HtmlHelper htmlhelper, string id, string title, string subone="", string subtwo="")
        {
            var _div = new TagBuilder("div");
            _div.MergeAttribute("class", "form-group");

           
            var _lable = new TagBuilder("lable");
            _lable.MergeAttribute("for",id);
            _lable.SetInnerText(title);

            var _checkboxone = new TagBuilder("checkbox");
            _checkboxone.MergeAttribute("name", subone);
            _checkboxone.MergeAttribute("text", subone);
            _checkboxone.MergeAttribute("isChecked","true");

            var _subonelable = new TagBuilder("lable");
            _subonelable.MergeAttribute("for", id);
            _subonelable.SetInnerText(subone);

            var _checkboxtwo = new TagBuilder("checkbox");
            _checkboxtwo.MergeAttribute("name", subtwo);
            _checkboxtwo.MergeAttribute("isChecked", "false");

            var _subtwolable = new TagBuilder("lable");
            _subtwolable.MergeAttribute("for", id);
            _subtwolable.SetInnerText(subtwo);
           

           


            _div.InnerHtml = _lable.ToString() + _checkboxone.ToString() + _subonelable.ToString() + _checkboxtwo.ToString() + _subtwolable.ToString();

            return new HtmlString(_div.ToString());

        }
        /// <summary>
        /// 带标题的input标签
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">id</param>
        /// <param name="title">标题</param>
        /// <param name="placeholder">文本提示</param>
        /// <returns></returns>
        public static HtmlString GuaGuo_InptTextWithTitle(this HtmlHelper helper, string id, string title, string text="",string placeholder = "", string type = "text", Object attributes = null)
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
            _input.MergeAttribute("value",text);
            _input.IdAttributeDotReplacement = "-";
            _input.GenerateId(id);
            //_input.
            if (attributes!=null)
            {
                foreach (var attr in HtmlHelper.AnonymousObjectToHtmlAttributes(attributes))
                {
                    _input.MergeAttribute(attr.Value.ToString(), attr.Key.ToString(), true);

                }
            }

            _div.InnerHtml = _lable.ToString() + _input.ToString();

            return new HtmlString(_div.ToString());
        }
      
    }
}