using API_Layer.DTOs;
using Core_Layer;
using Core_Layer.Core_Classes.Sessions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using DataAccess_Layer;

namespace API_Layer.Controllers.people
{
    [Route("API/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {        

        public PeopleController()
        {
          
        }







        //EndPoints------------------------------------------------------->


        //[HttpGet("GetPerson")]
        //public ActionResult<DTOs.PeopleDTOs.SendPersonDTO> GetPerson(int PersonID)
        //{             
        //    return Ok(DTOs.PeopleDTOs.ToSendPersonDTO(clsPerson.GetItem(PersonID)));
        //}




    }
}
