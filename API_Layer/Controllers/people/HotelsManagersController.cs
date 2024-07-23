using API_Layer.DTOs;
using Core_Layer;
using Core_Layer.Core_Classes.Users;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Layer.Controllers.people
{
    [Route("API/HotelsManager")]
    [ApiController]
    public class HotelsManagersController : ControllerBase
    {

        private clsHotelsManager _HotelsManager { get; set; }


        public HotelsManagersController()
        {
            _HotelsManager = new clsHotelsManager();
        }







        //EndPoints------------------------------------------------------->



        [HttpPost("CreateHotelsManager")]
        public ActionResult AddHotelsManager(DTOs.HotelsManagersDTOs.CreateHotelsManagerDTO HotelsManager)
        {

            if (clsUserValidation.DoesUserExist(HotelsManager.Username))
                return BadRequest("Username already exists");


            int HotelsManagerID = clsHotelsManager.AddItem(HotelsManager);

            if (HotelsManagerID != -1)
                return Ok(HotelsManagerID);

            else
                return BadRequest(HotelsManagerID);



        }


       




    }
}
