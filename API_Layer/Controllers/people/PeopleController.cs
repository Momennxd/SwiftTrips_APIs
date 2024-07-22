using API_Layer.DTOs;
using Core_Layer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Layer.Controllers.people
{
    [Route("API/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {        
        private clsPerson _Person { get; set; }


        public PeopleController()
        {
            _Person = new clsPerson();
        }







        //EndPoints------------------------------------------------------->

        [HttpGet("GetAllPeople")]
        public ActionResult GetAllPeople()
        {
           return Ok(PeopleDTOs.ToSendPersonDTO(_Person.GetAllItem()));
        }








        //[HttpGet("GetPerson")]
        //public ActionResult<dtoPerson> GetPerson(int PersonID)
        //{
        //    var person = _basicRepo.GetItem(PersonID);



        //    if (person == null)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(dtoPerson.ToDTO(person));
        //}



        //[HttpPost("AddPerson")]
        //public ActionResult<dynamic> CreatePerson([FromBody] ePeopleDA Person)
        //{

        //    if (!ModelState.IsValid)           
        //        return BadRequest(ModelState);


        //    if (Person == null)           
        //        return BadRequest();


        //    if (_basicRepo.AddItem(Person))
        //    {
        //        return Ok(Person);
        //    }

        //    return BadRequest();
        //}



        //[HttpDelete("DeletePerson")]
        //public ActionResult<dynamic> DeletePerson(int ID)
        //{

        //    if (_basicRepo.DeleteItem(ID))
        //    {
        //        return Ok();
        //    }



        //    return BadRequest();
        //}


        //[HttpPut("putPeron")]
        //public ActionResult<dynamic> UpdatePerson([FromBody] ePeopleDA NewPerson, int ID)
        //{

        //    if (_basicRepo.UpdateItem(NewPerson, ID))
        //    {
        //        return Ok();
        //    }



        //    return BadRequest();
        //}


        //[HttpPatch("UpdatePartialPerson")]
        //public ActionResult<dynamic> PatcheCountry([FromBody] JsonPatchDocument<ePeopleDA> NewPerson, int ID)
        //{

        //    if (_basicRepo.PatchItem(NewPerson, ID))
        //    {
        //        return Ok(true);
        //    }


        //    return BadRequest();
        //}

    }
}
