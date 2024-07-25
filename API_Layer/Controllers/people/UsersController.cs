using API_Layer.DTOs;
using Core_Layer;
using Core_Layer.Core_Classes.Users;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Layer.Controllers.people
{
    [Route("API/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public UsersController()
        {
        }








        //EndPoints------------------------------------------------------->



        [HttpPost("AddUser")]
        public ActionResult AddUser(UsersDTOs.CreateUserDTO userDTO)
        {

            if (clsUser.DoesUserExist(userDTO.Username))
                return BadRequest("Username already exists");


            int UserID = clsUser.AddItem(userDTO);

            if (UserID != -1)
                return Ok(UserID);

            else
                return BadRequest("error");
        }






        [HttpGet("GetUser")]
        public ActionResult GetUser(int UserID)
        {

            if (UserID <= 0)
                return BadRequest("Enter valid UserID");

            UsersDTOs.SendUserDTO sendUserDTO = UsersDTOs.ToSendUserDTO(clsUser.GetItem(UserID));


            if (sendUserDTO == null)
                return BadRequest("User Not Found");


            return Ok(sendUserDTO);


        }






        [HttpGet("Login")]
        public ActionResult LoginUser(string Username, string Password)
        {


            var LoginResult = clsUserValidation.ValidateUserInfo(new UsersDTOs.LoginUserDTO(Username, Password));


            if (LoginResult.enLoginResult == clsUserValidation.enLoginResult.eWrongUsername)
                return BadRequest("Wrong Username");

            if (LoginResult.enLoginResult == clsUserValidation.enLoginResult.eWrongPassword)
                return BadRequest("Wrong Password");


            return Ok(DTOs.UsersDTOs.ToSendUserDTO(LoginResult.userInfo.BaseObject, LoginResult.sessionID));


        }



    }
}
