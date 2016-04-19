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
        /// 姓名
        /// </summary>
        [Column("name", TypeName = "VARCHAR")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 当前对象联系电话
        /// </summary>
        [Column("phone_num", TypeName = "VARCHAR")]
        public string PhoneNum { get; set; }

        /// <summary>
        /// 当前对象联系微信
        /// </summary>
        [Column("weixin_num", TypeName = "TEXT")]
        [MaxLength]
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
        [Column("comment", TypeName = "NVARCHAR")]
        public string Comment { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Column("adress", TypeName = "VARCHAR")]
        public string Adress { get; set; }


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
        /// 当前对象是否通过审核 0未审核 1已审核 
        /// </summary>
        [Column("confirm", TypeName = "INT")]
        [Required]
        public int Confirm { get; set; }


    }
}