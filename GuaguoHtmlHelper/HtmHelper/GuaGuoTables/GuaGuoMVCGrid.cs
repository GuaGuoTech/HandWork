using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.WebPages.Html;

namespace System.Web.Mvc
{
    public class GuaGuoMVCGrid<T>
    {

        // Summary:
        //     样式使用的行类（仅限偶数行）
        protected string AlternatingRowCssClass { get; set; }
        //
        // Summary:
        //     显示为表标题的字符串
        protected string Caption { get; set; }
        /// <summary>
        /// grid对象
        /// </summary>
      protected   WebGrid webGrid { get; set; }

        //
        // Summary:
        //     显示表头
        protected bool DisplayHeader { get; set; }
        //
        // Summary:
        //     空数据显示文本
        protected string EmptyText { get; set; }
        //
        // Summary:
        //     实体集合
        protected List<T> ModelList { get; set; }
        //
        // Summary:
        //     样式使用的页脚行类
        protected string FooterCssClass { get; set; }
        //
        // Summary:
        //     样式使用的标题行类
        protected string HeaderCssCalss { get; set; }
        //
        // Summary:
        //     样式使用的行类（仅限奇数行）
        protected string RowCssClass { get; set; }
        //
        // Summary:
        //     样式使用的表类
        protected string TableCssClass { get; set; }

        public GuaGuoMVCGrid(HtmlHelper html, List<T> list, string emptyValue = "-", IDictionary<string, object> htmlAttributes = null) 
        {
            List<dynamic> girdSource = new List<dynamic>();
            foreach (var item in list)
            {
                girdSource.Add(item);
            }
            webGrid = new WebGrid(girdSource);
            EmptyText = emptyValue;
            ModelList = list;
        
        }


        public void RowColumn(Func<T, object> valueFucn=null, string headerText = "", int width = 0, string style = "") 
        {
            webGrid.Column(header:headerText);
            
        }

    }
}