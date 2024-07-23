using API_Layer.DTOs;
using Business_Logic.DTOs;
using DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Mappers
{
    public static class  HotleMangerMapper
    {

        // These Just For Exsample
        public static HotelsManagersDTO2222s ToDto(eHotelsManagersDA hotelsManagers)
        {

            if(hotelsManagers == null)
            {

                return null; 
            }

            return new HotelsManagersDTO2222s
            {
                HotelManagerID = hotelsManagers.HotelManagerID
            };
        }



        public static eHotelsManagersDA ToEntity(eHotelsManagersDA hotelsManagers)
        {

            if (hotelsManagers == null)
            {

                return null;
            }

            return new eHotelsManagersDA
            {
                UserID = hotelsManagers.UserID,

            };
        }
    }
}
