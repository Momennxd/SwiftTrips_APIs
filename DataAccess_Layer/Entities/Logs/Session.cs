using ConsoleApp1;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities.Logs
{
    public class Session
    {
        public string SessionID { get; set; }


        public required int UserID { get; set; }


        public required DateTime LasAct_TimeStamp { get; set; }


        public required bool IsValid { get; set; }

        public byte? Invalid_Reason { get; set; }

       



    }
}
