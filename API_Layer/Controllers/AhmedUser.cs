using Business_Logic.Interfaces;
using DataAccess_Layer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AhmedUser : ControllerBase
    {
        private readonly IGenericServices<eHotelsManagersDA> hotleMangerServices;

        public AhmedUser(IGenericServices<eHotelsManagersDA> hotleMangerServices)
        {
            this.hotleMangerServices=hotleMangerServices;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var hotleMangers = hotleMangerServices.GetAllItem();

            return Ok(hotleMangers);
        }
    }
}
