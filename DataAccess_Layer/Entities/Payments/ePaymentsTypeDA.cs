using System.ComponentModel.DataAnnotations;

public class ePaymentsTypeDA
{
    [Key]
    public int PaymentTypeID { get; set; }

    public string PaymentTypeName { get; set; } 

}