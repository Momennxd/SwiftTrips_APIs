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

        [HttpGet("GetAllPeople")]
        public ActionResult GetAllPeople()
        {
            return Ok(PeopleDTOs.ToSendPersonDTO(clsPerson.GetAllItem()));
        }



        [HttpGet("GetPerson")]
        public ActionResult<DTOs.PeopleDTOs.SendPersonDTO> GetPerson(int PersonID)
        {
               
            return Ok(DTOs.PeopleDTOs.ToSendPersonDTO(clsPerson.GetItem(PersonID)));
        }



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
