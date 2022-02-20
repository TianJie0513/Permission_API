using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainDTO.EFTables
{
    /// <summary>
    /// 用户表
    /// </summary>
   public class SysUsersEFTables
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Key]
        public int UId { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public int SysUser { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 性别 M 男F代表的是女
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Img { get; set; }



    }
}
