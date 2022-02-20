using DomainDTO.InputModels;
using DomainDTO.OutPutModels;
using System;
using System.Collections.Generic;

namespace IServices.IOU
{
    /// <summary>
    /// 专门用来服务ou使用
    /// </summary>
    public interface IOUsServices
    {
        int ExecuteOUs(SysOUsInputModels models);
        DomainDTO.OutPutModels.OutputResultModels<List<DeptOutPustModels>> GetAllList();
    }
}
