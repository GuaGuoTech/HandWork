using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class GuaGuoTable
    {

        /// <summary>
        /// 没有实现  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <param name="list"></param>
        /// <param name="funcValue"></param>
        /// <returns></returns>
        //public static MvcHtmlString GuaGuo_MvcTable<T>(this HtmlHelper helper, List<T> list, Action<GuaGuoMVCGrid<T>> funcValue)
        //{
        //    return null;
        //}
        /// <summary>
        /// 生成表格
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <param name="list"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static MvcHtmlString GuaGuo_MvcTable<T>(this HtmlHelper helper, List<T> list, Func<dynamic, object> checkBox = null, object columListAndName = null)
        {
            ///遍历集合
            List<dynamic> valueList = new List<dynamic>();
            foreach (T item in list)
            {
                valueList.Add(item);
            }

            ///反射 类 添加所有的属性
            //Type type = typeof(T);
            //System.Reflection.PropertyInfo[] properties = type.GetProperties();
            List<string> strColunms = new List<string>();
            //定义列
            List<WebGridColumn> webList = new List<WebGridColumn>();
           
            WebGridColumn webCheckBox = new WebGridColumn();
            
            webCheckBox.Format = c=>{
                string aa = string.Format("<input id={0} type='checkbox' />",c.Id);
                return new HtmlString(aa);

            
            };
            webList.Add(webCheckBox);
            WebGridColumn[] webArr = new WebGridColumn[] { };

            foreach (var attr in HtmlHelper.AnonymousObjectToHtmlAttributes(columListAndName))
            {
                WebGridColumn webColumn = new WebGridColumn();
                webColumn.ColumnName = attr.Key;
                webColumn.Header = attr.Value.ToString();
                webList.Add(webColumn);
                
                strColunms.Add(attr.Key);

            }
            
            webArr =    webList.ToArray();
            //foreach (System.Reflection.PropertyInfo property in properties)
            //{
            //    strColunms.Add(property.Name);
            //}
            WebGrid webGrid = new WebGrid(valueList, strColunms,canSort:false);

            webGrid.Columns(webArr);
            string str = webGrid.GetHtml("table table-hover", columns: webArr).ToHtmlString();
            return new MvcHtmlString(str);
        }


    }
}