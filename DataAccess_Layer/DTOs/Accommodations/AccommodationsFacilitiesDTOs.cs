using Core_Layer.DTOs.Facilities;
using Core_Layer.Entities.Accommodation;
using Core_Layer.Entities.Facilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.DTOs.Accommodations
{
    public class AccommodationsFacilitiesDTOs
    {
        #region DTOs

        public record AddNewAccommodationsFacilitiesDTO
            (
            int FacilityID,
            int AccommodationBaseID
            );

        public record AccommodationsFacilitiesMainDTO
        (
            int AccommodationsFacilityID,
            FacilitiesDTOs.FacilitiesMainDTO? Facilities,
            AccommodationBasesDTOs.MainDTO? AccommdoationBases
        );

        public static async Task<AccommodationsFacilitiesMainDTO?> SendMainDTO(int ID)
        {
            var entity = await eAccommodationFacilitiesDA.FindAsync(ID);

            if (entity == null)
                return null;

            return new AccommodationsFacilitiesMainDTO
            (
                AccommodationsFacilityID: entity.AccommodationsFacilityID,
                await FacilitiesDTOs.SendDTO( entity.FacilityID),
                await AccommodationBasesDTOs.SendMainDTO( entity.AccommodationBaseID)
            );
        }

        public static eAccommodationFacilitiesDA? ConvertFromAddNewDTOtoEntity(AddNewAccommodationsFacilitiesDTO addNewDTO)
        {
            if (addNewDTO == null)
                return null;

            return new eAccommodationFacilitiesDA
            {
                FacilityID = addNewDTO.FacilityID,
                AccommodationBaseID = addNewDTO.AccommodationBaseID

            };
        }
        #endregion

        
    }
}
