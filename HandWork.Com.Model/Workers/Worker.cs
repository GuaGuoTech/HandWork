﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.Workers
{
    [Table("worker_info")]
    public class Worker
    {
        /// <summary>
        /// 设置主键ID
        /// </summary>
        [Key]
        [Column("id", TypeName = "INT")]
        public long Id { get; set; }
        /// <summary>
        /// 设置Id的级别
        /// </summary>
        [Column("id_class", TypeName = "INT")]
        public int IdClass { get; set; }
        /// <summary>
        /// 设置登录密码
        /// </summary>
        [Column("password", TypeName = "NVARCHAR")]
        public string Password { get; set; }
        /// <summary>
        /// 当前对象联系电话
        /// </summary>
        [Column("phone_num", TypeName = "NVARCHAR")]
        public string PhoneNum { get; set; }
        /// <summary>
        /// 当前对象联系微信
        /// </summary>
        [Column("weixin_num", TypeName = "NVARCHAR")]
        public string WeixinNum { get; set; }
        /// <summary>
        /// 当前对象身份证号码
        /// </summary>
        [Column("sfz_account", TypeName = "NVARCHAR")]
        public int SfzAccount { get; set; }
        /// <summary>
        /// 当前对象的简介
        /// </summary>
        [Column("note", TypeName = "NVARCHAR")]
        public string Note { get; set; }
        /// <summary>
        /// 当前对象的简介
        /// </summary>
        [Column("comment", TypeName = "NVARCHAR")]
        public string Comment { get; set; }
        /// <summary>
        /// 当前对象性别 0女1男
        /// </summary>
        [Column("sex", TypeName = "INT")]
        public Boolean Sex { get; set; }
        /// <summary>
        /// 当前对象星级
        /// </summary>
        [Column("star", TypeName = "INT")]
        public int Star { get; set; }
        /// <summary>
        /// 当前对象星级
        /// </summary>
        [Column("confirm", TypeName = "INT")]
        public int Confirm { get; set; }


        

    }
}