using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainDTO.EFTables
{
    /// <summary>
    /// 部门对用户关系表
    /// </summary>
    public class SysOUMembersEFTables
    {
        [Key]
        public int OUMemberId{get;set;}
        /// <summary>
        /// 部门ID
        /// </summary>
        public int OUID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UId { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string UserAccount { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string LeaderTitle { get; set; }
        

    }
}
