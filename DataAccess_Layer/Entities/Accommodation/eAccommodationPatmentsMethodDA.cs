using DataAccess_Layer.Entities.Accommodation;
using System.ComponentModel.DataAnnotations;

public class eAccommodationPatmentsMethodDA
{

    [Key]
    public int MethodId { get; set; }

    public int TypeMethod { get; set; }

    public int AccommdoationBaseID { get; set; }

  

}
