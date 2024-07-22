using API_Layer.DTOs;
using Core_Layer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Layer.Controllers.people
{
    [Route("API/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private clsUser _User { get; set; }


        public UsersController()
        {
            _User = new clsUser();
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
                return BadRequest(UserID);
        }



        [HttpGet("GetUser")]
        public ActionResult GetUser(int UserID)
        {

            if (UserID <= 0)
                return BadRequest();

            UsersDTOs.SendUserDTO sendUserDTO = UsersDTOs.ToSendUserDTO(_User.GetItem(UserID));


            if (sendUserDTO == null)           
                return BadRequest();
            

            return Ok(sendUserDTO);

           
        }



    }
}
