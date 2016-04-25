using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.Relation
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
        /// 当前工作是否完成 0否1是
        /// </summary>
        [Column("finish", TypeName = "INT")]
        public int  Finish { get; set; }
                
    }
}