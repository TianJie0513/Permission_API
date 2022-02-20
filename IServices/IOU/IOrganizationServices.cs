using System;
using System.Collections.Generic;
using System.Text;

namespace IServices.IOU
{
    /// <summary>
    /// 组织架构维护
    /// </summary>
   public interface IOrganizationServices
    {
        IOUsServices Dept { get; }
        ISysUsersServices SysUser { get; }
    }
}
