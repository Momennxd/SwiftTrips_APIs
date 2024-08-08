using DataAccess_Layer.Entities.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities.Language.cs
{

    public class ePreferedPeopleLanguagesDA
    {
        [Key]
        public int LanguagePersonID { get; set; }


        public int LanguageID { get; set; }


       public int PersonID { get; set; }


        public int LanguagePersonIndex { get; set; }


        public ePersonDA ePeople {  get; set; }

        public eLanguageDA eLanguage { get; set; }
    }
}
