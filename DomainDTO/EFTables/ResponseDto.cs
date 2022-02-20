using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDTO.EFTables
{
  public  class ResponseDto
    {// <summary>
        /// 详细错误信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 具体业务参数
        /// </summary>
        public bool data { get; set; }
    }
}
