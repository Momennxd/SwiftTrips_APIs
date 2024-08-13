using DataAccess_Layer.Entities.Hotels;
using Microsoft.AspNetCore.Mvc;
using Core_Layer.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Core_Layer.Entities.Hotels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace API_Layer.Controllers.Hotels
{
    [Route("api/Hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {

    


        #region Add New Hotel
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddHotel(HotelsDTOs.CreateHotelDTO NewHotel)
        {
            if (NewHotel == null)
                return BadRequest();

            int HotelID = await eHotelDA.AddItemAsync(NewHotel);

            if(HotelID == -1)
                return BadRequest();

            return Ok(HotelID);
        }

        #endregion

        #region Get Hotel

        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Core_Layer.DTOs.HotelsDTOs.SendHotelDTO>> GetHotel(int HotelsId)
        {
            if (HotelsId <= 0)
                return BadRequest("ID is invalid");

            eHotelDA? Hotel = await eHotelDA.FindAsync(HotelsId);
            if (Hotel == null)
                return NotFound("Hotel Not Found");

            return Ok(HotelsDTOs.ToSendHotelDTO(Hotel));

        }

        #endregion

        #region Update Hotel
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HotelsDTOs.SendHotelDTO>> UpdateHotel(HotelsDTOs.SendHotelDTO UpdatedHotel)
        {
            if (UpdatedHotel == null)
                return BadRequest();

            if (UpdatedHotel.HotelID <= 0)
                return BadRequest("Invalid Hotel ID");

            eHotelDA? Hotel = await eHotelDA.UpdateItemAsync(UpdatedHotel);

            if (Hotel == null)
                return BadRequest();

            return Ok(Hotel);
        }

        #endregion

        #region Delete Hotel

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteHotel(int HotelID)
        {
            if(HotelID < 0) 
                return BadRequest();

            if(! eHotelDA.DeleteItem(HotelID))
                return BadRequest();

            return Ok($"Hotel with ID {HotelID} Deleted Successfully!");
        }

        #endregion









        [HttpPatch("PatchHotel")]
        public async Task<ActionResult<dynamic>> PatchHotel([FromBody]
        JsonPatchDocument<eHotelDA> NewHotel, int HotelID)
        {

            if(await eHotelDA.PatchItemAsync(NewHotel, HotelID) != null)
            {
                return Ok();
            }
           
            return BadRequest();
        }
    }
}
