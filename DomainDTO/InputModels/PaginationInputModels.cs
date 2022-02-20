using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDTO.InputModels
{
   public class PaginationInputModels
    {/*
      	@tableName nvarchar(200),
	@field nvarchar(200),
	@where nvarchar(500),
	@orderByField nvarchar(20),
	@pageIndex int,
	@pageSize int,
      */
        public string TableName { get; set; }
        public string Field { get; set; }
        public string Where { get; set; }
        public string OrderByField { get; set; }
        public int PageIndex { get; set; }
        public int pageSize { get; set; }
        
    }
}
