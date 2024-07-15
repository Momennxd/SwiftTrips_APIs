
using API_Layer.DTOs;
using DataAccess_Layer;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_Layer.Controllers.people
{
    [Route("API/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IBasicRepository<ePeopleDA> _basicRepo;

        public PeopleController(IBasicRepository<ePeopleDA> basicRepo)
        {
            _basicRepo=basicRepo;
        }

        [HttpGet("GetAllPeople")]
        public dynamic GetAllPeople()
        {
            return _basicRepo.GetAllItem();

            //return dtoPerson.GetAllPeople();

            //return temp.ExecGetAllPeople();
        }



        [HttpGet("GetPerson")]
        public ActionResult<dynamic> GetPerson(int PersonID)
        {
            var person = _basicRepo.GetItem(PersonID);

            if (person == null)
            {
                return BadRequest();
            }

            return Ok(person);
        }



        [HttpPost("AddPerson")]
        public ActionResult<dynamic> CreatePerson(ePeopleDA Person)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (_basicRepo.AddItem(Person))
            {
                return Ok(Person);
            }

            return BadRequest();
        }



        [HttpDelete("DeletePerson")]
        public ActionResult<dynamic> DeletePerson(int ID)
        {

            if (_basicRepo.DeleteItem(ID))
            {
                return Ok();
            }



            return BadRequest();
        }


        [HttpPut("putPeron")]
        public ActionResult<dynamic> UpdatePerson([FromBody] ePeopleDA NewPerson, int ID)
        {

            if (_basicRepo.UpdateItem(NewPerson, ID))
            {
                return Ok();
            }



            return BadRequest();
        }


        [HttpPatch("UpdatePartialPerson")]
        public ActionResult<dynamic> PatcheCountry([FromBody] JsonPatchDocument<ePeopleDA> NewPerson, int ID)
        {

            if (_basicRepo.PatchItem(NewPerson, ID))
            {
                return Ok(true);
            }


            return BadRequest();
        }

    }
}
