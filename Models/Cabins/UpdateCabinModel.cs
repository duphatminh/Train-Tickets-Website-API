using System.ComponentModel.DataAnnotations;

namespace TrainTicketsWebsite.Models;

// This class is used to update a cabin
public class UpdateCabinModel
{
    public int carriageID { get; set; }
    [Required]
    [MaxLength(10)]
    public string cabinName { get; set; }
}