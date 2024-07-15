

using Azure;
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_Layer.Controllers.people
{
    [Route("API/Counties")]
    [ApiController]
    public class CoutriesController : ControllerBase
    {

        private readonly IBasicRepository<eCountriesDA> _basicRepo;

        public CoutriesController(IBasicRepository<eCountriesDA> basicRepo)
        {
            _basicRepo=basicRepo;
        }

        [HttpGet("GetCountries")]
        public ActionResult<dynamic> GetAllCountries()
        {
            return _basicRepo.GetAllItem();
            //return eCountriesDA.GetAllCountries();
        }

        [HttpGet("GetCountry")]
        public ActionResult<dynamic> GetCountry(int ID)
        {
            return _basicRepo.GetItem(ID);
            // return eCountriesDA.GetCountry(ID);
        }



        [HttpPost("AddCountry")]
        public ActionResult<dynamic> CreateCountry([FromBody] eCountriesDA country)
        {
            if (_basicRepo.AddItem(country))
            {

                return Ok(country);
            }

            return BadRequest();
        }




        [HttpPut("PutCountry")]
        public ActionResult<dynamic> UpdateCountry([FromBody] eCountriesDA Newcountry, int ID)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_basicRepo.UpdateItem(Newcountry, ID))
            {
                return Ok(Newcountry);
            }



            return BadRequest();
        }



        [HttpPatch("UpdatePartialCountry")]
        public ActionResult<dynamic> PatcheCountry([FromBody] JsonPatchDocument<eCountriesDA> Newcountry, int ID)
        {

            if (_basicRepo.PatchItem(Newcountry, ID))
            {
                return Ok(true);
            }

            return BadRequest();
        }


        [HttpDelete("DeleteCountry")]
        public ActionResult<dynamic> DeleteCountry(int ID)
        {

            if (_basicRepo.DeleteItem(ID))
            {
                return true;
            }



            return BadRequest();
        }

    }
}



