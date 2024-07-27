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


        public HotelsManagersController()
        {

        }



        //EndPoints------------------------------------------------------->



        [HttpPost("CreateHotelsManager")]
        public ActionResult AddHotelsManager(DTOs.HotelsManagersDTOs.CreateHotelsManagerDTO HotelsManager)
        {

            if (clsUser.DoesUserExist(HotelsManager.Username))
                return BadRequest("Username already exists");


            int HotelsManagerID = clsHotelsManager.AddItem(HotelsManager);

            if (HotelsManagerID != -1)
                return Ok(HotelsManagerID);

            else
                return BadRequest(HotelsManagerID);



        }



        [HttpGet("Login")]
        public ActionResult LoginHotelsManager(string Username, string Password)
        {        

            var LoginResult = clsUserValidation.ValidateUserInfo(new UsersDTOs.LoginUserDTO(Username, Password));


            if (LoginResult.enLoginResult == clsUserValidation.enLoginResult.eWrongUsername)
                return BadRequest("Wrong Username");

            if (LoginResult.enLoginResult == clsUserValidation.enLoginResult.eWrongPassword)
                return BadRequest("Wrong Password");


            return Ok(DTOs.HotelsManagersDTOs.ToSendHotelsManagerDTO(
                 clsHotelsManager.GetHotelManager(LoginResult.userInfo.BaseObject.UserID).BaseObject,
                 LoginResult.sessionID));
        }



    }
}
