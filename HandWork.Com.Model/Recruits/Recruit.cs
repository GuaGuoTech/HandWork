using HandWork.Com.Model.Users;
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
        /// 当前报名人数列表
        /// 最佳答案: varchar??
        /// </summary>
        [Column("apply_num", TypeName = "VARCHAR")]
        public List<User> ApplyNum { get; set; }

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
        [Required]
        public string WeixinNum { get; set; }

        /// <summary>
        /// 当前对象身份证号码
        /// </summary>
        [Column("sfz_account", TypeName = "VARCHAR")]
        public string SfzAccount { get; set; }  

        /// <summary>
        /// 当前招工的简介
        /// </summary>
        [Column("note", TypeName = "NVARCHAR")]
        public string Note { get; set; }
        
        /// <summary>
        /// 当前对象性别 0女1男2不限
        /// </summary>
        [Column("sex", TypeName = "INT")]
        public int Sex { get; set; }

        /// <summary>
        /// 设置当前薪金
        /// </summary>
        [Column("money", TypeName = "DOUBLE")]
        [Required]
        public double  Money { get; set; }

        /// <summary>
        /// 设置当前薪金
        /// </summary>
        [Column("final_money", TypeName = "DOUBLE")]
        [Required]
        public double FinalMoney { get; set; }

        /// <summary>
        /// 设置生成时间
        /// </summary>
        [Column("first_time", TypeName = "DATETIME")]
        public DateTime FirstTime { get; set; }

        /// <summary>
        /// 当前是否人工确认
        /// </summary>
        [Column("confirm", TypeName = "INT")]
        [Required]
        public int Confirm { get; set; }
    }
}