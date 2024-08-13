using API_Layer.DTOs;
using Core_Layer;
using Core_Layer.Core_Classes.Users;
using DataAccess_Layer.Entities.People;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_Layer.Controllers
{
    [Route("API/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {



        #region Controller init

        public UsersController()
        {
        }

        #endregion



        #region Add user

        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddUser([FromBody]UsersDTOs.CreateUserDTO userDTO)
        {

            if (await eUserDA.DoesUserExistAsync(userDTO.Username))
                return BadRequest("Username already exists");


            int UserID = await eUserDA.AddItemAsync(userDTO);

            if (UserID != -1)
                return Ok(UserID);

            else
                return BadRequest("error");
        }

        #endregion



        #region Get user

        [HttpGet("GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<DTOs.UsersDTOs.SendUserDTO>> GetUser(int UserID)
        {
            if (UserID <= 0)
                return BadRequest("Enter valid info");


            eUserDA? user = await eUserDA.FindAsync(UserID);

            if (user == null)
                return NotFound();


            UsersDTOs.SendUserDTO sendUserDTO = await UsersDTOs.ToSendUserDTOAsync(user);


            return Ok(sendUserDTO);


        }

        #endregion



        #region Login

        [HttpGet("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> LoginUser(string Username, string Password)
        {


            var LoginResult = 
                await clsLoginValidation.ValidateUserInfoAsync(new UsersDTOs.LoginUserDTO(Username, Password));


            if (LoginResult.enLoginResult == clsLoginValidation.enLoginResult.eWrongUsername)
                return BadRequest("Wrong Username");

            if (LoginResult.enLoginResult == clsLoginValidation.enLoginResult.eWrongPassword)
                return BadRequest("Wrong Password");


            return Ok(await DTOs.UsersDTOs.ToSendUserDTOAsync(LoginResult.userInfo));


        }

        #endregion



    }
}
