using Core_Layer.Entities.Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.DTOs.Accommodations
{
    public class AccommodationBasesDTOs
    {
        #region DTOs
        public record MainDTO(
            int AccommodationBaseID,
            int HotleID,
            string? Discriptaion,
            short MaxCompactiy,
            byte NumberOfSingleBeds,
            byte NumberOfDoubleBeds,
            short Size,
            string AccommodationName,
            string AccommodationSeriaNumber,
            short NumberOfClones,
            bool Smoking,
            string? BedsDiscripation
            );


        public static async Task<MainDTO?> SendMainDTO(int Id)
        {
            if (Id < 0)
                return null;

            var accommodationBase = await eAccommdoationBasesDA.FindAsync(Id);

            if (accommodationBase == null)
                return null;

            return new MainDTO
            (
                AccommodationBaseID: accommodationBase.AccommodationBaseID,
                HotleID: accommodationBase.HotelID,
                Discriptaion: accommodationBase.Discription,
                MaxCompactiy: accommodationBase.MaxCapacity,
                NumberOfSingleBeds: accommodationBase.NumberOfSingleBeds,
                NumberOfDoubleBeds: accommodationBase.NumberOfDoubleBeds,
                Size: accommodationBase.Size,
                AccommodationName: accommodationBase.AccommadationName,
                AccommodationSeriaNumber: accommodationBase.AccommodationSerialNumber,
                NumberOfClones: accommodationBase.NumberOfClones,
                Smoking: accommodationBase.Smoking,
                BedsDiscripation: accommodationBase.BedsDiscription
            );
        }


        public record AddNewDTO(
            int HotleID,
            string? Discriptaion,
            short MaxCompactiy,
            byte NumberOfSingleBeds,
            byte NumberOfDoubleBeds,
            short Size,
            string AccommodationName,
            string AccommodationSeriaNumber,
            short NumberOfClones,
            bool Smoking,
            string? BedsDiscripation
            );

        public static eAccommdoationBasesDA ToAccommdoationBasesEntity(AddNewDTO addNewDTO)
        {
            return new eAccommdoationBasesDA
            {
                HotelID = addNewDTO.HotleID,  // Updated property name
                Discription = addNewDTO.Discriptaion,  // Updated property name
                MaxCapacity = addNewDTO.MaxCompactiy,  // Updated property name
                NumberOfSingleBeds = addNewDTO.NumberOfSingleBeds,
                NumberOfDoubleBeds = addNewDTO.NumberOfDoubleBeds,
                Size = addNewDTO.Size,
                AccommadationName = addNewDTO.AccommodationName,
                AccommodationSerialNumber = addNewDTO.AccommodationSeriaNumber,  // Updated property name
                NumberOfClones = addNewDTO.NumberOfClones,
                Smoking = addNewDTO.Smoking,
                BedsDiscription = addNewDTO.BedsDiscripation  // Updated property name
            };
        }

        public static eAccommdoationBasesDA ToAccommdoationBasesEntity(MainDTO dto)
        {
            return new eAccommdoationBasesDA
            {
                AccommodationBaseID = dto.AccommodationBaseID,
                HotelID = dto.HotleID,  // Updated property name
                Discription = dto.Discriptaion,  // Updated property name
                MaxCapacity = dto.MaxCompactiy,  // Updated property name
                NumberOfSingleBeds = dto.NumberOfSingleBeds,
                NumberOfDoubleBeds = dto.NumberOfDoubleBeds,
                Size = dto.Size,
                AccommadationName = dto.AccommodationName,
                AccommodationSerialNumber = dto.AccommodationSeriaNumber,  // Updated property name
                NumberOfClones = dto.NumberOfClones,
                Smoking = dto.Smoking,
                BedsDiscription = dto.BedsDiscripation  // Updated property name
            };
        }

        public static MainDTO FromEntityToDTO(eAccommdoationBasesDA AccommdoationBasesDA)
        {
            return new MainDTO(
                AccommodationBaseID: AccommdoationBasesDA.AccommodationBaseID,
                HotleID: AccommdoationBasesDA.HotelID,  // Updated property name
                Discriptaion: AccommdoationBasesDA.Discription,  // Updated property name
                MaxCompactiy: AccommdoationBasesDA.MaxCapacity,  // Updated property name
                NumberOfSingleBeds: AccommdoationBasesDA.NumberOfSingleBeds,
                NumberOfDoubleBeds: AccommdoationBasesDA.NumberOfDoubleBeds,
                Size: AccommdoationBasesDA.Size,
                AccommodationName: AccommdoationBasesDA.AccommadationName,
                AccommodationSeriaNumber: AccommdoationBasesDA.AccommodationSerialNumber,  // Updated property name
                NumberOfClones: AccommdoationBasesDA.NumberOfClones,
                Smoking: AccommdoationBasesDA.Smoking,
                BedsDiscripation: AccommdoationBasesDA.BedsDiscription  // Updated property name
            );
        }


        #endregion

        #region Send DTO

        public static MainDTO? SendAccommodationBaseDTO(eAccommdoationBasesDA AccommdoationBasesDA)
        {
            if (AccommdoationBasesDA is null)
                return null;

            return FromEntityToDTO(AccommdoationBasesDA);
        }

        #endregion
    }
}
