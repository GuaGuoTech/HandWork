﻿using HandWork.Com.Model.Weixins;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace HandWork.Com.Service.Weixins
{
    public class WeixinService
    {
        /// <summary>
        /// sha1加密
        /// </summary>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public static string GetPwd(string Pwd)
        {
            byte[] data = System.Text.Encoding.Default.GetBytes(Pwd);//以字节方式存储
            System.Security.Cryptography.SHA1 sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] result = sha1.ComputeHash(data);//得到哈希值
            return System.BitConverter.ToString(result).Replace("-", ""); //转换成为字符串的显示
        }



        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        private static readonly string _url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx7271e951428d81cf&secret=c71f0472145cdf05351e09059a63582f";

        public static Dictionary<string, object> _access_token;
        public static void GetBaseToken(int? timeout)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string respText = "";
            if (string.IsNullOrEmpty(_url))
            {
                throw new ArgumentNullException("url");
            }
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;

            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }



            using (Stream resStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(resStream, Encoding.Default);
                respText = reader.ReadToEnd();
                resStream.Close();
            }
            JavaScriptSerializer Jss = new JavaScriptSerializer();
            Dictionary<string, object> respDic = (Dictionary<string, object>)Jss.DeserializeObject(respText);


            _access_token = respDic;
        }
        /// <summary>
        /// /微信自定义菜单创建 目前没有传入要传进的菜单
        /// </summary>
        /// <returns></returns>
        public static string CreateWenxinMenu()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=";

            if (_access_token == null)
            {
                GetBaseToken(200);
            }
            url += _access_token["access_token"];

            HttpWebRequest request = null;
            HttpWebResponse _response = null;
            //HTTPSQ请求  
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = DefaultUserAgent;

            List<Menu> menus = new List<Menu>();
            menus.Add(new Menu()
            {
                name = "菜单",
                sub_button = new SubButton[] 
                {
                         new SubButton()
                           {
                              name = "求职",
                              key = "menu_qiuzhi",
                              type = "click"
                            },
                         new SubButton()
                           {
                             name = "招聘",
                             key = "menu_zhaopin",
                             type = "click"
                            }
                }
            });
            menus.Add(new Menu()
            {
                name = "测试",
                sub_button = new SubButton[] 
                {
                         new SubButton()
                           {
                             name = "网页测试",
                             url = "http://120.27.104.135/",
                             type = "view"
                            },                      
                 }
            });
            WeixinMenu weixinMenu = new WeixinMenu() { button = menus };
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string menusString = jss.Serialize(weixinMenu);
            //如果需要POST数据     
            string buffer = menusString;


            byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            _response = request.GetResponse() as HttpWebResponse;
            string aa = GetStream(_response, Encoding.UTF8);
            return aa;
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
                /*
                using (MemoryStream msTemp = new MemoryStream())
                {
                    //解压时直接使用Read方法读取内容，不能调用GZipStream实例的Length等属性，否则会出错：System.NotSupportedException: 不支持此操作；
                    while ((length = gz.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        msTemp.Write(buffer, 0, length);
                    }

                    return encoding.GetString(msTemp.ToArray());
                }
                 * */
            }
        }


        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }

    }
}