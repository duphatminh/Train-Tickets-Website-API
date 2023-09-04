using System.ComponentModel.DataAnnotations;

namespace TrainTicketsWebsite.Models;

public class Payments
{
    [Key]
    public int paymentID { get; set; }
    public string paymentMethod { get; set; }
    public string creditCardNumber { get; set; }
    public DateTime expirationDate { get; set; }
    public string cvv { get; set; }
}