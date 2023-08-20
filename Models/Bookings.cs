namespace TrainTicketsWebsite.Models;

public class Bookings
{
    public int bookingID { get; set; }
    public int trainID { get; set; }
    public int userID { get; set; }
    public int carriageID { get; set; }
    public int cabinID { get; set; }
    public int seatID { get; set; }
    public int departureStation { get; set; }
    public int arrivalStation { get; set; }
    public DateTime departureTime { get; set; }
    public int numberOfTickets { get; set; }
    public int totalPrice { get; set; }
}