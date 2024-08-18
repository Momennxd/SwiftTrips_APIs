using Core_Layer.DTOs;
using Core_Layer.Glob;
using Microsoft.AspNetCore.Mvc;

namespace Core_Layer.Controllers
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
