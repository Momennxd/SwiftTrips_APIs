﻿using Azure;
using DataAccess_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_Layer.Controllers.people
{
    [Route("API/Counties")]
    [ApiController]
    public class CoutriesController : ControllerBase
    {




        [HttpGet("GetCountries")]
        public ActionResult<dynamic> GetAllCountries()
        {

            return eCountriesDA.GetAllCountries();
        }

        [HttpGet("GetCountry")]
        public ActionResult<dynamic> GetCountry(int ID)
        {

            return eCountriesDA.GetCountry(ID);
        }



        [HttpPost("AddCountry")]
        public ActionResult<dynamic> CreateCountry([FromBody] eCountriesDA country)
        {
            if (eCountriesDA.AddCountry(country))
            {

                return Ok(country);
            }

            return BadRequest();
        }




        [HttpPut("PutCountry")]
        public ActionResult<dynamic> UpdateCountry([FromBody] eCountriesDA Newcountry, int ID)
        {

            if (eCountriesDA.updateCountry(Newcountry, ID))
            {
                return Ok(Newcountry);
            }



            return BadRequest();
        }



        [HttpPatch("UpdatePartialCountry")]
        public ActionResult<dynamic> PatcheCountry([FromBody] JsonPatchDocument<eCountriesDA> Newcountry, int ID)
        {

            if (eCountriesDA.PatchCountry(Newcountry, ID))
            {
                return Ok(true);
            }





            return BadRequest();
        }


        [HttpDelete("DeleteCountry")]
        public ActionResult<dynamic> DeleteCountry(int ID)
        {

            if (eCountriesDA.DeleteCountry(ID))
            {
                return true;
            }



            return BadRequest();
        }

    }
}