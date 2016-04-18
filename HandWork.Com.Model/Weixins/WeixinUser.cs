using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.Weixins
{
    public class WeixinUser
    {
        public string openid { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string province { get; set; }

        public string city { get; set; }
        public string country { get; set; }

        public string headimgurl { get; set; }
        public string[] privilege { get; set; }

    }
}