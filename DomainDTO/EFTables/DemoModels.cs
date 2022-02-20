using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainDTO.EFTables
{
  public  class DemoModels
    {
        [Required(ErrorMessage = "商品ID不得为空")]
        public string Name { get; set; }
    }
}
