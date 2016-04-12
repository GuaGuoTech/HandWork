using HandWork.Com.Model.JsonModels.PhoneChecks;
using HandWork.Com.Model.Weixins;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace HandWork.Com.Service.PhoneChecks
{
    public static class PhoneCheckService
    {
        public static string SendCheckCode(string phoneNumber)
        {

            string  code = CreateCode();
            string url = "https://sandboxapp.cloopen.com:8883/2013-12-26/Accounts/8a48b55153cb69470153cfdf164a06de/SMS/TemplateSMS?sig={SigParameter}";

            ///时间戳
            string dateStr = DateTime.Now.ToString("yyyyMMddHHmmss");

            string id = "8a48b55153cb69470153cfdf164a06de";
            string appId = "8a48b55153cb69470153cfe1efaa06fc";
            string token = "101dd569ac58480c981a830ad291f6cf";
            ///构造字符串
            string sigParameter = id + token + dateStr;
            sigParameter = MD5String(sigParameter);
            ///构造url
            url = url.Replace("{SigParameter}",sigParameter);

            HttpWebRequest request = null;
            HttpWebResponse _response = null;
            //HTTPSQ请求  
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Accept = "application/json";
            request.ContentType = "application/json;charset=utf-8";

            //构造需要的Authorization参数 需要进行base64编码

            string aut = id + ":"+dateStr;
            byte[] b = Encoding.UTF8.GetBytes(aut);
            aut = Convert.ToBase64String(b);
            request.Headers.Add("Authorization", aut);

            ToThePhone phone = new ToThePhone();
            phone.appId = appId;
            phone.datas = new string[] { "："+code, "2" };
            phone.templateId = "1";
            phone.to = phoneNumber;
           
            JavaScriptSerializer jss = new JavaScriptSerializer();
            //如果需要POST数据     
            string menusString = jss.Serialize(phone);
            string buffer = System.Text.RegularExpressions.Regex.Unescape(menusString);

            byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            _response = request.GetResponse() as HttpWebResponse;
            string aa = GetStream(_response, Encoding.UTF8);


            return aa;
        }


        private static string CreateCode ()
        {

     
      
                
            char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',};
            string result = "";
            int n = Pattern.Length;
            System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < 6; i++)
            {
                int rnd = random.Next(0,n);
                result += Pattern[rnd];
               
            }
            return result;
        

        }

        /// <summary>
        /// md5 32位加密
        /// </summary>
        /// <param name="textStr"></param>
        /// <returns></returns>
        private static string MD5String(string textStr)
        {
            string pwd = "";
            MD5 md5 = MD5.Create();

            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(textStr));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("X");
            }

            return pwd;
        }



        /// <summary>
        /// 将response转换成文本
        /// </summary>
        /// <param name="response"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static string GetStream(HttpWebResponse response, Encoding encoding)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    switch (response.ContentEncoding.ToLower())
                    {
                        case "gzip":
                            {
                                string result = Decompress(response.GetResponseStream(), encoding);
                                response.Close();
                                return result;
                            }
                        default:
                            {
                                using (StreamReader sr = new StreamReader(response.GetResponseStream(), encoding))
                                {
                                    string result = sr.ReadToEnd();
                                    sr.Close();
                                    sr.Dispose();
                                    response.Close();
                                    return result;
                                }
                            }
                    }
                }
                else
                {
                    response.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return "";
        }

        private static string Decompress(Stream stream, Encoding encoding)
        {
            byte[] buffer = new byte[100];
            //int length = 0;

            using (GZipStream gz = new GZipStream(stream, CompressionMode.Decompress))
            {
                //GZipStream gzip = new GZipStream(res.GetResponseStream(), CompressionMode.Decompress);
                using (StreamReader reader = new StreamReader(gz, encoding))
                {
                    return reader.ReadToEnd();
                }

            }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }
    }
}