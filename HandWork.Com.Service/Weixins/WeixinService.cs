using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandWork.Com.Service.Weixins
{
    public class WeixinService
    {
        /// <summary>
        /// sha1加密
        /// </summary>
        /// <param name="Pwd"></param>
        /// <returns></returns>
     public   static string GetPwd(string Pwd)
        {
            byte[] data = System.Text.Encoding.Default.GetBytes(Pwd);//以字节方式存储
            System.Security.Cryptography.SHA1 sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] result = sha1.ComputeHash(data);//得到哈希值
            return System.BitConverter.ToString(result).Replace("-", ""); //转换成为字符串的显示
        }


    }
}