using Core_Layer.Entities.Facilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.DTOs.Facilities
{
    public class FacilitiesCategoriesDTOs
    {
        public record FacilitiesCategoriesMainDTO
            (
                int FacilityCategoryID,
                string CategoryName,
                string? Discription
            );

        public static async Task< FacilitiesCategoriesMainDTO?> SendMainDTO(int FacilityCategoryID)
        {
            if (FacilityCategoryID < 0)
                return null;

            eFacilitiesCategoriesDA? FacilitiesCategories = await eFacilitiesCategoriesDA.FindAsync(FacilityCategoryID);

            if( FacilitiesCategories == null )
                return null;


            return new FacilitiesCategoriesMainDTO(FacilitiesCategories.FacilityCategoryID, FacilitiesCategories.CategoryName, FacilitiesCategories.Discription);
        }
    }
}
