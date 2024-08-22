using Core_Layer.Entities.Facilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.DTOs.Facilities
{
    public class FacilitiesDTOs
    {
        public record FacilitiesMainDTO
            (
                int FacilityID,
                string FacilityName,
                string Discription,
                FacilitiesCategoriesDTOs.FacilitiesCategoriesMainDTO? FacilityCategory
            );

        public static async Task<FacilitiesMainDTO?> SendDTO(int FacilityID)
        {
            if (FacilityID < 0)
                return null;

            var Facility = await eFacilitiesDA.FindAsync( FacilityID );

            if(Facility == null)
                return null;

            return new FacilitiesMainDTO
                (
                    Facility.FacilityID,
                    Facility.FacilityName,
                    Facility.Discription,
                    await FacilitiesCategoriesDTOs.SendMainDTO(Facility.FacilityCategoryID)
                );

        }
    }
}
