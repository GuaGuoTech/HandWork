using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.Users
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("user_info")]
    public class User
    {
        /// <summary>
        /// 设置主键ID
        /// </summary>
        [Key]
        [Column("id", TypeName = "BIGINT")]
        public long Id { get; set; }

        ///// <summary>
        ///// 设置Id的级别
        ///// </summary>
        //[Column("id_class", TypeName = "INT")]
        //public int IdClass { get; set; }

        /// <summary>
        /// 设置登录密码
        /// </summary>
        [Column("password", TypeName = "VARCHAR")]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 当前对象联系电话
        /// </summary>
        [Column("phone_num", TypeName = "VARCHAR")]
        public string PhoneNum { get; set; }

        /// <summary>
        /// 当前对象联系微信
        /// </summary>
        [Column("weixin_num", TypeName = "VARCHAR")]
        [Required]
        public string WeixinNum { get; set; }

        /// <summary>
        /// 当前对象身份证号码
        /// </summary>
        [Column("sfz_account", TypeName = "VARCHAR")]

        public string SfzAccount { get; set; }

        /// <summary>
        /// 当前对象的简介
        /// </summary>
        [Column("note", TypeName = "NVARCHAR")]
        public string Note { get; set; }

        /// <summary>
        /// 当前对象的评价
        /// </summary>
        [Column("comment1", TypeName = "NVARCHAR")]
        public string Comment1 { get; set; }

        /// <summary>
        /// 当前对象的评价2
        /// </summary>
        [Column("comment1", TypeName = "NVARCHAR")]
        public string Comment2 { get; set; }


    



        /// <summary>
        /// 当前对象性别 0女1男
        /// </summary>
        [Column("sex", TypeName = "INT")]
        public int Sex { get; set; }

        /// <summary>
        /// 当前对象星级
        /// </summary>
        [Column("star", TypeName = "INT")]
        public int Star { get; set; }

        /// <summary>
        /// 当前对象是否通过审核
        /// </summary>
        [Column("confirm", TypeName = "INT")]
        [Required]
        public int Confirm { get; set; }


    }
}