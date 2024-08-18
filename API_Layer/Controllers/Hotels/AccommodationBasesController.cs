using Core_Layer.DTOs;
using Core_Layer.Entities.Accommodation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using static Core_Layer.DTOs.AccommodationBasesDTOs;

namespace Core_Layer.Controllers.Hotels
{
    [Route("api/AccommodationBases")]
    [ApiController]
    public class AccommodationBasesController : ControllerBase
    {


        #region Get By ID
        [HttpGet("AccommodationBaseByID")]
        public async Task<ActionResult<Core_Layer.DTOs.AccommodationBasesDTOs>> GetHotel(int ID)
        {
            if (ID < 0)
                return BadRequest("Invalid input");

            eAccommdoationBasesDA? AccommdoationBase = await eAccommdoationBasesDA.FindAsync(ID);
            if (AccommdoationBase == null)
                return NotFound();


            return Ok(AccommodationBasesDTOs.SendAccommodationBaseDTO(AccommdoationBase));
        }
        #endregion



        #region Add New 
        [HttpPost("AddNewAccommodationBase")]
        public async Task<ActionResult> AddNewAccommodationBase(Core_Layer.DTOs.AccommodationBasesDTOs.AddNewDTO addNewDTO)
        {
            if (addNewDTO == null)
                return BadRequest();

           int NewID = await eAccommdoationBasesDA.AddItemAsync(addNewDTO);

            if (NewID == -1)
                return BadRequest();


            return Ok(NewID);


        }
        #endregion



        #region Patch

        [HttpPatch("PatchAccommodationBase")]
        public async Task<ActionResult> Update(JsonPatchDocument< eAccommdoationBasesDA > UpdatedDTO, int ID)
        {
            if(await eAccommdoationBasesDA.PatchItemAsync(UpdatedDTO, ID) != null)
                return Ok();

            return BadRequest();
        }

        #endregion



        #region Delete

        [HttpDelete("DeleteAccommodationBase")]
        public async Task<ActionResult> Delete(int AccommodationBaseID)
        {

            if(AccommodationBaseID < 0)
                return BadRequest();

            if(! await eAccommdoationBasesDA.DeleteItemAsync(AccommodationBaseID))
                return BadRequest();

            return Ok($"Accommodation Base with ID {AccommodationBaseID} Deleted Successfully!\"");

        }

        #endregion




    }
}
