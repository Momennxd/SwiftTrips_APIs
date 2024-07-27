using API_Layer.DTOs;
using Core_Layer;
using Core_Layer.Core_Classes.Sessions;
using Core_Layer.DTOs;
using DataAccess_Layer;
using DataAccess_Layer.Entities.Hotels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace API_Layer.Controllers.people
{
    [Route("API/People")]
    [ApiController]
    public class EmailController : ControllerBase
    {        

        public EmailController()
        {
          
        }







        //EndPoints------------------------------------------------------->




        [HttpPost("SendEmail")]
        public ActionResult SendEmail([FromBody] EmailsDTOs.SendEmailDTO emailDTO, string ToMail)
        {
            return Ok(clsCore.SendEmail(ToMail, emailDTO.Subject, emailDTO.Body));
        }


    }
}
