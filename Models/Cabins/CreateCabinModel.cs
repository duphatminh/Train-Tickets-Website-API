using System.ComponentModel.DataAnnotations;

namespace TrainTicketsWebsite.Models;

public class CreateCabinModel
{
    public int carriageID { get; set; }
    [Required]
    [MaxLength(10)]
    public string cabinName { get; set; }
}