using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.Relations
{   /// <summary>
    /// 雇主员工信息表
    /// </summary>
    [Table("relation_info")]
    public class Relation
    {
        /// <summary>
        /// 设置主键ID
        /// </summary>
        [Key]
        [Column("id", TypeName = "BIGINT")]
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// weixinUserId
        /// </summary>
        [Column("weixin_user_id", TypeName = "BIGINT")]
        public long WeixinUserId { get; set; }


        [Column("ask_weixin_user_id", TypeName = "BIGINT")]
        public long AskWeixinUserId { get; set; }


        /// <summary>
        /// recruitId
        /// </summary>
      [Column("recruitId", TypeName = "BIGINT")]
        public long RecuitId { get; set; }

        /// <summary>
        /// 设置生成时间
        /// </summary>
        [Column("first_time", TypeName = "DATETIME")]
        public DateTime FirstTime { get; set; }

        /// <summary>
        /// 设置完成时间
        /// </summary>
        [Column("second_time", TypeName = "DATETIME")]
        public DateTime SecondTime { get; set; }

  
        
        /// <summary>
        /// 当前是否接受 0否  1接受 2拒绝
        /// </summary>
        [Column("finish", TypeName = "INT")]
        public int  Finish { get; set; }

        /// <summary>
        /// 是否已经读过了 0为否
        /// </summary>
        [Column("for_read", TypeName = "INT")]
        public int ForRead { get; set; }

        /// <summary>
        /// 管理员有没有处理 0为没处理
        /// </summary>
        [Column("manager_for_read", TypeName = "INT")]
        public int ManagerForRead { get; set; }
                
    }
}