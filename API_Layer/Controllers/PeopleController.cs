using Core_Layer.DTOs;
using Core_Layer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Core_Layer;
using Core_Layer.Entities.People;

namespace Core_Layer.Controllers
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
        //    return Ok(DTOs.PeopleDTOs.ToSendPersonDTO(Person.Find(PersonID)));
        //}


       



    }
}
