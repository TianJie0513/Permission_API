using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DomainDTO.InputModels
{
    /// <summary>
    /// 输入用户models
    /// </summary>
   public class SysUsersInputModels
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UId { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        [Required(ErrorMessage ="用户名不能为空")]
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
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

        public int OUID { get; set; }
        public string LeaderTitle { get; set;}
        /// <summary>
        /// 执行的类型
        /// </summary>
        public int Type { get; set; }
        public int OuMemberId { get; set; }
    }
}
