using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.Weixins
{
    public class WeixinUser
    {
        public long id { get; set; }
        public string openid { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string province { get; set; }

        public string city { get; set; }
        public string country { get; set; }

        public string headimgurl { get; set; }
        /// <summary>
        /// 用户特殊情况 我们这里没有必要需要这个
        /// </summary>
      //  public string[] privilege { get; set; }

    }
}