using API_Layer.DTOs;
using Azure;
using DataAccess_Layer;
using DataAccess_Layer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_Layer.Controllers
{
    [Route("API/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("GetAllPeople")]
        public ActionResult<dynamic> GetAllPeople()
        {
            return dtoPerson.GetAllPeople();

          //  return temp.ExecGetAllPeople();
        }



        [HttpGet("GetPerson")]
        public ActionResult<dynamic> GetPerson(int PersonID)
        {
            dtoPerson person = dtoPerson.GetPerson(PersonID);

            if (person == null)
            {
                return BadRequest();
            }

            return Ok(person);
        }



        [HttpPost("AddPerson")]
        public ActionResult<dynamic> CreatePerson([FromBody] ePeopleDA Person)
        {
            if (ePeopleDA.AddPerson(Person))
            {
                return Ok(Person);
            }

            return BadRequest();
        }



        [HttpDelete("DeletePerson")]
        public ActionResult<dynamic> DeletePerson(int ID)
        {

            if (dtoPerson.DeletePerson(ID))
            {
                return Ok();
            }



            return BadRequest();
        }




    }
}
