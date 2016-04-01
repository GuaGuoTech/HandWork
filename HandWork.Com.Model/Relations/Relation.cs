using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.Relation
{  
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
        /// 设置dealer
        /// </summary>
        [Column("dealer", TypeName = "VARCHAR")]
        [Required]
        public string Dealer { get; set; }

        /// <summary>
        /// 设置生成时间
        /// </summary>
        [Column("first_time", TypeName = "DATETIME")]
        [Required]
        public DateTime FirstTime { get; set; }

        /// <summary>
        /// 设置完成时间
        /// </summary>
        [Column("second_time", TypeName = "DATETIME")]
        [Required]
        public DateTime SecondTime { get; set; }

        /// <summary>
        /// 设置worker
        /// </summary>
        [Column("worker", TypeName = "VARCHAR")]
        [Required]
        public string Worker { get; set; }
        
        /// <summary>
        /// 当前工作是否完成 0否1是
        /// </summary>
        [Column("finish", TypeName = "INT")]
        [Required]
        public int  Finish { get; set; }
                
    }
}