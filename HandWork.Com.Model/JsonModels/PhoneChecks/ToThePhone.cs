using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.JsonModels.PhoneChecks
{
    public class ToThePhone
    {
        public string to { get; set; }

        public string appId { get; set; }
        public string templateId { get; set; }
        public string[] datas { get; set; }


    }
}