using API_Layer.DTOs;
using Core_Layer;
using Core_Layer.Glob;
using Core_Layer.DTOs;
using DataAccess_Layer.Entities.Hotels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace API_Layer.Controllers
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
        public async Task<ActionResult> SendEmail([FromBody] EmailsDTOs.SendEmailDTO emailDTO, string ToMail)
        {
            if (await clsCore.SendEmailAsync(ToMail, emailDTO.Subject, emailDTO.Body))
                return Ok(emailDTO);
            else
                return BadRequest("Error");
        }


    }
}
