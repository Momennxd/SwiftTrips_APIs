using API_Layer.DTOs;
using Core_Layer;
using Core_Layer.Core_Classes.Sessions;
using Core_Layer.Core_Classes.Users;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        public ActionResult GetUser(int UserID, [FromHeader]string SessionID)
        {
            if (UserID <= 0 || string.IsNullOrEmpty(SessionID))
                return BadRequest("Enter valid info");


            clsUser? user = new clsUser(clsUser.GetItem(UserID));

            if (user == null || user.BaseObject == null)
                return BadRequest("User Not Found");

            clsUserSession.enSessionValidationResult ses_result =
                clsUserSession.ValidateSession(SessionID, user.BaseObject.UserID);

     
            if (ses_result != clsUserSession.enSessionValidationResult.eSession_Valid)
                return Unauthorized(ses_result.ToString());


            UsersDTOs.SendUserDTO sendUserDTO = UsersDTOs.ToSendUserDTO(user.BaseObject);



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
