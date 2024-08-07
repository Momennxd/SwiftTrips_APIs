using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.DTOs
{
    public static class EmailsDTOs
    {

        /// <summary>
        /// This DTO is the object that the user enters in the request body.
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        public record SendEmailDTO(string Subject, string Body);




    }
}
