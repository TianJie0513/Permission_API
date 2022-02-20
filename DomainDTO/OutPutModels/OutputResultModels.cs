using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDTO.OutPutModels
{
    public class OutputResultModels<T> where T:class,new()
    {
        public int Total { get; set; }
        public T Result { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
