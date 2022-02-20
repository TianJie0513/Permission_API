using IServices.IOU;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.OUS
{
    public class OrganizationServices : IServices.IOU.IOrganizationServices
    {
        private readonly IOUsServices ous;
        private readonly ISysUsersServices users;
        public OrganizationServices(IOUsServices ous, ISysUsersServices users)
        {
            this.ous = ous;
            this.users = users;
        }
        /// <summary>
        /// 获取部门操作的接口
        /// </summary>
        public IOUsServices Dept { get { return this.ous; } }
        public IServices.IOU.ISysUsersServices SysUser { get { return this.users; } }

       
    }
}
