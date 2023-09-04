using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsWebsite.Models;

public class Bookings
{
    [Key]
    public int bookingID { get; set; }
    public int userID { get; set; }
    public int seatID { get; set; }
    public int departureStation { get; set; }
    public int arrivalStation { get; set; }
    public DateTime departureTime { get; set; }
    public int numberOfTickets { get; set; }
    public int totalPrice { get; set; }
    
    [ForeignKey("userID")]
    public virtual Users Users { get; set; }
    
    [ForeignKey("seatID")]
    public virtual Seats Seats { get; set; }
}