using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainDTO.EFTables
{
   
  public  class SysOUsEFTables
    {
        [Key]
      public int OUID { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentOUID { get; set; }
        /// <summary>
        /// OU名称
        /// </summary>
        public string OUName { get; set; }
        /// <summary>
        /// OU职级
        /// </summary>
        public string OULevel { get; set;}
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
