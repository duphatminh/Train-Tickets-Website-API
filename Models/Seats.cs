using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsWebsite.Models;

public class Seats
{
    [Key]
    public int seatID { get; set; }
    public int cabinID { get; set; }
    
    [Required]
    public int seatNumber { get; set; }
    
    [MaxLength(20)]
    [Required]
    public string seatType { get; set; }
    
    public string seatAvailability { get; set; }
    
    public int price { get; set; }
    
    [ForeignKey("cabinID")]
    public virtual CabinsDetailModel CabinsDetailModel { get; set; }
}