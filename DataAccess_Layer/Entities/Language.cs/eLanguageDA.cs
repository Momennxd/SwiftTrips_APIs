using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities.Language.cs
{
    public class eLanguageDA
    {
        [Key]
        public int LanguageID { get; set; }


        public string Language { get; set; }

    }
}
