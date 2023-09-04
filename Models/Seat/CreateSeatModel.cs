using System.ComponentModel.DataAnnotations;

namespace TrainTicketsWebsite.Models;

public class CreateSeatModel
{
    public int cabinID { get; set; }
    
    [Required]
    public int seatNumber { get; set; }
    
    [MaxLength(20)]
    [Required]
    public string seatType { get; set; }
    
    public string seatAvailability { get; set; }
    
    public int price { get; set; }
}