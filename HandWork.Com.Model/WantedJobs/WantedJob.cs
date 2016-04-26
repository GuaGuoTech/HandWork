using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.WantedJobs
{
        [Table("wantedjob_info")]
    /// <summary>
    /// 求职
    /// </summary>
    public class WantedJob
    {
        /// <summary>
        /// 设置主键ID
        /// </summary>
        [Key]
        [Column("id", TypeName = "BIGINT")]
        public long Id { get; set; }

        /// <summary>
        /// 当前对象的联系地址 或者住所
        /// </summary>
        [Column("location", TypeName = "NVARCHAR")]
        public string Location { get; set; }

        /// <summary>
        /// 设置生成时间
        /// </summary>
        [Column("first_time", TypeName = "DATETIME")]
       
        public DateTime FirstTime { get; set; }

        /// <summary>
        /// 设置完成时间
        /// </summary>
        [Column("finish_time", TypeName = "DATETIME")]
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// 设置当前对象的姓名
        /// </summary>
        [Column("name", TypeName = "VARCHAR")]
        public string Name { get; set; }   

        /// <summary>
        /// 当前对象联系电话
        /// </summary>
        [Column("phone_num", TypeName = "VARCHAR")]
        public string PhoneNum { get; set; }

        /// <summary>
        /// 当前招工分类
        /// </summary>
        [Column("classify", TypeName = "VARCHAR")]
        public string Classify { get; set; }

        /// <summary>
        /// 当前对象联系微信
        /// </summary>
        [Column("weixin_num", TypeName = "VARCHAR")]
        public string WeixinNum { get; set; }

        /// <summary>
        /// 当前对象身份证号码
        /// </summary>
        [Column("sfz_account", TypeName = "VARCHAR")]
        public string SfzAccount { get; set; }

        /// <summary>
        /// 当前求职的详细介绍
        /// </summary>
        [Column("note", TypeName = "NVARCHAR")]
        public string Note { get; set; }

        /// <summary>
        /// 当前对象性别 0女1男
        /// </summary>
        [Column("sex", TypeName = "INT")]
        public int Sex { get; set; }

        /// <summary>
        /// 设置预期工资
        /// </summary>
        [Column("money", TypeName = "VARCHAR")]
        public string money { get; set; }

        /// <summary>
        /// 当前是否人工确认
        /// </summary>
        [Column("confirm", TypeName = "INT")]
        public int Confirm { get; set; }
    }
}