using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.Employment
{
        [Table("employment_info")]
    public class Employment
    {
        /// <summary>
        /// 设置主键ID
        /// </summary>
        [Key]
        [Column("id", TypeName = "INT")]
        public long Id { get; set; }

        /// <summary>
        /// 设置对象的地址
        /// </summary>
        [Column("location", TypeName = "NVARCHAR")]
        public int Location { get; set; }

        /// <summary>
        /// 设置登录密码
        /// </summary>
        [Column("name", TypeName = "DOUBLE")]
        public string Name { get; set; }

        /// <summary>
        /// 当前对象联系电话
        /// </summary>
        [Column("phone_num", TypeName = "NVARCHAR")]
        public string PhoneNum { get; set; }

        /// <summary>
        /// 当前招工分类
        /// </summary>
        [Column("classify", TypeName = "NVARCHAR")]
        public string Classify { get; set; }

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
        /// 当前招工的简介
        /// </summary>
        [Column("note", TypeName = "NVARCHAR")]
        public string Note { get; set; }

        /// <summary>
        /// 当前对象性别 0女1男
        /// </summary>
        [Column("sex", TypeName = "INT")]
        public Boolean Sex { get; set; }

        /// <summary>
        /// 设置当前薪金
        /// </summary>
        [Column("money", TypeName = "NVARCHAR")]
        public string money { get; set; }

        /// <summary>
        /// 当前是否人工确认
        /// </summary>
        [Column("confirm", TypeName = "INT")]
        public int Confirm { get; set; }
    }
}