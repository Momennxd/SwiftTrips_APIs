using API_Layer.DTOs;
using Business_Logic.Interfaces;
using Business_Logic.Mappers;
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



        [HttpPost("AddItem")]
        public IActionResult AddItem()
        {
            var hotleMangers = hotleMangerServices.AddItem(eHotelsManagersDA as );

            return Ok(hotleMangers);
        }
    }
}
