using API_Layer.DTOs;
using Core_Layer;
using DataAccess_Layer.Entities.Hotels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        
        [HttpGet("GetPerson")]
        public ActionResult<DTOs.PeopleDTOs.SendPersonDTO> GetPerson(int PersonID)
        {             
            return Ok(DTOs.PeopleDTOs.ToSendPersonDTO(clsPerson.GetItem(PersonID)));
        }



       
    }
}
