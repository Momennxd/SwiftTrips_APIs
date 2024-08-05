using API_Layer.DTOs;
using Core_Layer;
using Core_Layer.Core_Classes.Sessions;
using Core_Layer.Core_Classes.Users;
using DataAccess_Layer.Entities.Logs;
using DataAccess_Layer.Entities.People;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_Layer.Controllers
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

            if (clsUserCore.DoesUserExist(userDTO.Username))
                return BadRequest("Username already exists");


            int UserID = clsUserCore.AddItem(userDTO);

            if (UserID != -1)
                return Ok(UserID);

            else
                return BadRequest("error");
        }






        [HttpGet("GetUser")]
        public ActionResult GetUser(int UserID, [FromHeader] string SessionID)
        {
            if (UserID <= 0 || string.IsNullOrEmpty(SessionID))
                return BadRequest("Enter valid info");


            eUserDA? user = eUserDA.Find(UserID);

            if (user == null)
                return BadRequest("User Not Found");






            clsUserSessionCore.enSessionValidationResult ses_result =
                clsUserSessionCore.ValidateSession(SessionID, user.UserID);


            if (ses_result != clsUserSessionCore.enSessionValidationResult.eSession_Valid)
                return Unauthorized(ses_result.ToString());


            UsersDTOs.SendUserDTO sendUserDTO = UsersDTOs.ToSendUserDTO(user);



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


            return Ok(DTOs.UsersDTOs.ToSendUserDTO(LoginResult.userInfo, LoginResult.sessionID));


        }



    }
}
