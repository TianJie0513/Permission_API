using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainDTO.EFTables
{
    /// <summary>
    /// 角色表
    /// </summary>
   public class SysOURolesEFTables
    {
        [Key]
        public int OUROleID { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int OUID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        
    }
}
