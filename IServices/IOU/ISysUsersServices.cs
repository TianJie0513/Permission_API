using DomainDTO.OutPutModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices.IOU
{
    /// <summary>
    /// 用户数据操作接口
    /// </summary>
   public interface ISysUsersServices
    {
        int ExecuteAdd(DomainDTO.InputModels.SysUsersInputModels models);
        List<SysUsersOutputModels> GetUsers(int ouId);
        
    }
}
