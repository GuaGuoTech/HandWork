using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.Recruits
{
    /// <summary>
    /// 招聘信息表
    /// </summary>
    [Table("recruit_info")]
    public class Recruit
    {
        /// <summary>
        /// 设置主键ID
        /// </summary>
        [Key]
        [Column("id", TypeName = "BIGINT")]
        public long Id { get; set; }


        /// <summary>
        /// 微信用户的id
        /// /// </summary>
        public long WeixinUserId { get; set; }

        /// <summary>
        /// 当前招工的发布者
        /// </summary>
        [Column("man", TypeName = "NVARCHAR")]
        public string Man { get; set; }


        /// <summary>
        /// 设置对象的地址
        /// </summary>
        [Column("location", TypeName = "NVARCHAR")]
        public string Location { get; set; }


        /// <summary>
        /// 设置佣金比例  
        /// </summary>
        [Column("percent", TypeName = "DOUBLE")]
        public double Percent { get; set; }

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
        /// 当前招工的简介关键词 
        /// </summary>
        [Column("words", TypeName = "VARCHAR")]
        public string Words { get; set; }
        /// <summary>
        /// 当前招工的详情介绍
        /// </summary>
        [Column("note", TypeName = "NVARCHAR")]
        public string Note { get; set; }


        /// <summary>
        /// 当前招工的详情介绍
        /// </summary>
        [Column("title", TypeName = "NVARCHAR")]
        public string Title { get; set; }

        /// <summary>
        /// 当前招工的详情介绍
        /// </summary>
        [Column("requirement", TypeName = "NVARCHAR")]
        public string Requirement { get; set; }

        /// <summary>
        /// 当前对象性别 0女1男2不限
        /// </summary>
        [Column("sex", TypeName = "INT")]
        public int Sex { get; set; }

        /// <summary>
        /// 设置结算方式 0日结 1周结 2月结 3其他 
        /// </summary>
        [Column("pay_type", TypeName = "INT")]
        public int PayType { get; set; }

        /// <summary>
        /// 设置当前薪金
        /// </summary>
        [Column("money", TypeName = "DOUBLE")]
        public double Money { get; set; }


        /// <summary>
        /// 人数
        /// </summary>
        [Column("max_num", TypeName = "INT")]
        public int MaxNum { get; set; }

        /// <summary>
        /// 设置当前薪金
        /// </summary>
        [Column("final_money", TypeName = "DOUBLE")]
        public double FinalMoney { get; set; }

        /// <summary>
        /// 设置生成时间
        /// </summary>
        [Column("first_time", TypeName = "DATETIME")]
        public DateTime FirstTime { get; set; }

        /// <summary>
        /// 设置工作日期
        /// </summary>
        [Column("work_date", TypeName = "DATETIME")]
        public DateTime WorkDate { get; set; }

        /// <summary>
        /// 设置工作时间
        /// </summary>
        [Column("work_time", TypeName = "DATETIME")]
        public DateTime WorkTime { get; set; }




        /// <summary>
        /// 当前是否人工确认
        /// </summary>
        [Column("confirm", TypeName = "INT")]
        [Required]
        public int Confirm { get; set; }
    }
}