﻿using HandWork.Com.Model.Weixins;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Linq.Expressions;


namespace HandWork.Com.Service.Weixins
{
    public class WeixinService
    {

      public static  readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

   
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

        public static Dictionary<string, object> _access_token;

        /// <summary>
        /// 拿到基础token
        /// </summary>
        /// <param name="url"></param>
        public static void GetBaseToken()
        {
            ///请求token的地址
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wxd21f90079ecb0969&secret=338345d734124088ce5579a6a4514318";
            string  respText =    HttpsGet(url);
            JavaScriptSerializer Jss = new JavaScriptSerializer();
            Dictionary<string, object> respDic = (Dictionary<string, object>)Jss.DeserializeObject(respText);

            ///将token给全局静态变量
            _access_token = respDic;
        }

        /// <summary>
        /// https的get请求
        /// </summary>
        /// <param name="url">地址</param>
        public static string HttpsGet(string  url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string respText = "";
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;

            using (Stream resStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(resStream, Encoding.UTF8);
                respText = reader.ReadToEnd();
                resStream.Close();
            }
            return respText;

        }


        /// <summary>
        /// 得到codeToken
        /// </summary>
        /// <param name="responseText"></param>
        public static WeixinUser GetWeixinUser(string responseText)
        {
            try
            {
                WeixinCodeToken scopeToken = JsonConvert.DeserializeObject<WeixinCodeToken>(responseText);

                string url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", scopeToken.access_token, scopeToken.openid);

                string _responseText = HttpsGet(url);
                logger.Info(_responseText);
                WeixinUser weixinUser = JsonConvert.DeserializeObject<WeixinUser>(_responseText);
                return   InsertWeixinUser(weixinUser);
            }
            catch (Exception e)
            {
                logger.Error("出错信息:",  e);
                 
                throw;
            }
          

        }
        /// <summary>
        /// 添加user
        /// </summary>
        /// <param name="obj"></param>
        private static WeixinUser InsertWeixinUser(object obj)
        {
            Repository<WeixinUser> reponsitory = new Repository<WeixinUser>(new EntityContext());
            logger.Info("开始添加数据开始工作");
            try
            {
                
                WeixinUser weixinUser = (WeixinUser)obj;
                Expression<Func<WeixinUser, bool>> express = i => i.openid == weixinUser.openid;
            
              List < WeixinUser> weixinUserFromDataList = reponsitory.SearchFor(express).ToList();
              WeixinUser weixinUserFromData = new WeixinUser();
              if (weixinUserFromDataList.Count>0)
              {
                  weixinUserFromData = weixinUserFromDataList[0];
              }
                //如果为空 则直接添加到数据库
                if (weixinUserFromData.id < 1)
                {
                 weixinUser =   reponsitory.Insert(weixinUser);

                }
                else
                {
                    ///把查出来的id赋值个前台传过来的
                    ///
                    weixinUser.id = weixinUserFromData.id;

                    string weixinUserStr = JsonConvert.SerializeObject(weixinUser);
                    string weixinUserFromDataStr = JsonConvert.SerializeObject(weixinUserFromData);
                    logger.Info(weixinUserStr != weixinUserFromDataStr);
                    logger.Info("weixinUserStr:" + weixinUserStr);
                    logger.Info("weixinUserFromDataStr:" + weixinUserFromDataStr);
                    ///如果两者不相等 则更新
                    if (weixinUserStr != weixinUserFromDataStr)
                    {
                        reponsitory.Update(weixinUser);
                    }


                }
                return weixinUser;

            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }

        }



        /// <summary>
        /// /微信自定义菜单创建 目前没有传入要传进的菜单
        /// </summary>
        /// <returns></returns>
        public static string CreateWenxinMenu()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=";

            ///在没有token的时候 重新获取下
            if (_access_token == null)
            {
                GetBaseToken();
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
                             url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxd21f90079ecb0969&redirect_uri=http%3a%2f%2f120.27.104.135%2fHomes%2fHome%2fIndex&response_type=code&scope=snsapi_userinfo&state=guaguokeji#wechat_redirect",
                             type = "view"
                           },
                         new SubButton()
                           {
                             name = "授权test5",
                             url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxd21f90079ecb0969&redirect_uri=http%3a%2f%2f120.27.104.135%2fWeixins%2fweixin%2fIndex&response_type=code&scope=snsapi_userinfo&state=guaguokeji#wechat_redirect",
                             type = "view"
                           },
                 }
            });
            WeixinMenu weixinMenu = new WeixinMenu() { button = menus };
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string menusString = jss.Serialize(weixinMenu);
            //如果需要POST数据     
            string buffer = System.Text.RegularExpressions.Regex.Unescape(menusString); 

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

            }
        }


        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }


        /// <summary>
        /// 管理端用的得到
        /// </summary>
        /// <returns></returns>
        public static List<Model.JsonModels.Relations.RelationAndUser> GetRelationShipWithUser()
        {
           
            RelationReponsitory



        }
    }
}