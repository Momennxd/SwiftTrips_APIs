using API_Layer.DTOs;
using Core_Layer;
using Core_Layer.Core_Classes.Users;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Layer.Controllers
{
    [Route("API/HotelsManager")]
    [ApiController]
    public class HotelsManagersController : ControllerBase
    {


        public HotelsManagersController()
        {

        }



        //EndPoints------------------------------------------------------->



        [HttpPost("CreateHotelsManager")]
        public ActionResult AddHotelsManager(DTOs.HotelsManagersDTOs.CreateHotelsManagerDTO HotelsManager)
        {

            if (eUserDA.DoesUserExist(HotelsManager.Username))
                return BadRequest("Username already exists");


            int HotelsManagerID = eHotelManagerDA.AddItem(HotelsManager);

            if (HotelsManagerID != -1)
                return Ok(HotelsManagerID);

            else
                return BadRequest(HotelsManagerID);



        }



        [HttpGet("Login")]
        public ActionResult LoginHotelsManager(string Username, string Password)
        {

            var LoginResult = clsLoginValidation.ValidateUserInfo(new UsersDTOs.LoginUserDTO(Username, Password));


            if (LoginResult.enLoginResult == clsLoginValidation.enLoginResult.eWrongUsername)
                return BadRequest("Wrong Username");

            if (LoginResult.enLoginResult == clsLoginValidation.enLoginResult.eWrongPassword)
                return BadRequest("Wrong Password");


            return Ok(DTOs.HotelsManagersDTOs.ToSendHotelsManagerDTO(
                 eHotelManagerDA.GetHotelManager(LoginResult.userInfo.UserID),
                 LoginResult.sessionID));
        }



    }
}
