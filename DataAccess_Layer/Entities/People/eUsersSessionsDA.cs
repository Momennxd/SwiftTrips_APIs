using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities.People
{
    public class eUsersSessionsDA
    {
        [Key]

        public int SessionID { get; set; }

        public int UserID { get; set; }


        public DateTime LasAct_TimeStamp { get; set; }

        public bool IsValid { get; set; }

        public int InValidReason {  get; set; }


       
    }
}
