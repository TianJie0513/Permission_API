using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainDTO.EFTables
{
    /// <summary>
    /// 角色里面包含的用户关系表
    /// </summary>
    public class SysOURoleMembersEFTables
    {
        [Key]
        public int OURoleId { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int OUID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserAccount { get; set; }
    }
}
