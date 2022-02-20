using DomainDTO.InputModels;
using IServices.IOU;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permission_API.Controllers
{
  
    [ApiController]
    [Authorize]
    public class OusController : ControllerBase
    {
        private IOrganizationServices services;
        public OusController(IOrganizationServices services)
        {
            this.services = services;
        }
        [HttpPost, Route("api/AddDept")]
        public int Add([FromBody] SysOUsInputModels models)
        {
            //判断验证是否通过
            if (ModelState.IsValid)
            {
                return services.Dept.ExecuteOUs(models);
            }
            else {
                return 0;
            }
        }
        [HttpGet, Route("api/getAllDept")]
        public IActionResult GetAllDept()
        {
            return Ok(services.Dept.GetAllList());
        }
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost, Route("api/ExecuteUsers")]
        public int ExecuteUsers([FromBody]SysUsersInputModels models)
        {
            if (ModelState.IsValid)
            {
                return services.SysUser.ExecuteAdd(models);
            }
            else
            {
                return 0;
            }
           
        }
        [HttpPost, Route("api/GetSysUsers")]
        protected IActionResult GetSysUsers()
        {
          return  Ok(services.SysUser.GetUsers(1));
          
        }
    }
}
