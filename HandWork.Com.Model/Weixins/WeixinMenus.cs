using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.Weixins
{
    [Serializable]
    public class Button
    {
        public string name { get; set; }
    }
    [Serializable]
    public class SubButton : Button
    {
        public string type { get; set; }
        public string key { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class Menu : Button
    {
        public Button[] sub_button { get; set; }

    }
    [Serializable]
    public class WeixinMenu
    {
        public List<Menu> button { get; set; }
    }
}