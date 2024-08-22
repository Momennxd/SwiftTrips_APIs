using Core_Layer.DTOs.Accommodations;
using Core_Layer.Entities.Accommodation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_Layer.Controllers.Accommodations
{
    [Route("api/AccommodationsFacilities")]
    [ApiController]
    public class AccommodationsFacilitiesController : ControllerBase
    {
        #region Add New

        [HttpPost("AddNewAccommodationFacility")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddNewAccommodationFacility(AccommodationsFacilitiesDTOs.AddNewAccommodationsFacilitiesDTO addNewDTO)
        {
            if (addNewDTO == null)
                return BadRequest();

            var IsAdded = await eAccommodationFacilitiesDA.AddItemAsync(AccommodationsFacilitiesDTOs.ConvertFromAddNewDTOtoEntity(addNewDTO));

            if (IsAdded)
                return Ok();


            return BadRequest();

        }

        #endregion

        #region Get Item

        [HttpGet("GetAccommodationFacility")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAccommodationFacility(int ID)
        {
            if(ID < 0)
                return BadRequest();

            var MainDTO = await AccommodationsFacilitiesDTOs.SendMainDTO(ID);

            if (MainDTO == null)
                return NotFound();


            return Ok(MainDTO);
        }

        #endregion

        #region Delete Item

        [HttpDelete("DeleteAccommodationFacility")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAccommodationFacility(int ID)
        {
            if (ID < 0)
                return BadRequest();

            var IsDeleted = await eAccommodationFacilitiesDA.DeleteItemAsync(ID);

            if (IsDeleted)
                return Ok(IsDeleted);


            return NotFound();
        }



        #endregion

        #region Patch

        [HttpPatch("PatchAccommodationFacility")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PatchAccommodationFacility(JsonPatchDocument<eAccommodationFacilitiesDA> UpdatedDTO, int ID)
        {
            if (await eAccommodationFacilitiesDA.PatchItemAsync(UpdatedDTO, ID) != null)
                return Ok();

            return BadRequest();
        }


        #endregion
    }
}
