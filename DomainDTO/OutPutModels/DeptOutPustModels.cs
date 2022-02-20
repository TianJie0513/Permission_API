using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDTO.OutPutModels
{
    /// <summary>
    /// 输出用来显示部门tree
    /// </summary>
  public  class DeptOutPustModels
    {
        public int OUID { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentOUID { get; set; }
        /// <summary>
        /// OU名称
        /// </summary>
        public string label { get; set; }
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
       public List<DeptOutPustModels> children { get; set; }
    }
}
