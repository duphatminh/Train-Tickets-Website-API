using System.ComponentModel.DataAnnotations;

namespace TrainTicketsWebsite.Models;

public class UpdateSeatModel
{
    [MaxLength(20)]
    [Required]
    public string seatType { get; set; }
    
    public string seatAvailability { get; set; }
    
    public int price { get; set; }
}