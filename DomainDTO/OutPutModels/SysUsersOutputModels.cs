using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDTO.OutPutModels
{
   public class SysUsersOutputModels
    {
        public int UId { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string Account { get; set; }
     
        /// <summary>
        /// 是否管理员
        /// </summary>
        public int SysUser { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
      
        /// <summary>
        /// 性别 M 男F代表的是女
        /// </summary>
        public string Sex { get; set; }
       
        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }
     
    }
}
