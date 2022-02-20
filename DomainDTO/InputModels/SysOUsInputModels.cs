using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DomainDTO.InputModels
{
   public class SysOUsInputModels
    {
        public int OUID { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
       [Range(1,20,ErrorMessage ="不能超过20不能小于1")]
        public int ParentOUID { get; set; }
        /// <summary>
        /// OU名称
        /// </summary>
        public string OUName { get; set; }
        /// <summary>
        /// OU职级
        /// </summary>
        public string OULevel { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderIndex { get; set; }
    }
}
