using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permission_API.Controllers
{
   
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost, Route("api/test")]
        [CustomResultFilter]
        public IActionResult test([FromBody] DomainDTO.EFTables.DemoModels test)
        {
            if (ModelState.IsValid)
            {
                return Ok("123");
            }
            else
            {
               
                return Ok();
            }
        }
    }
}
