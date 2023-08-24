using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsWebsite.Models;
public class Users
{
    [Key]
    public int user_ID { get; set; }
    public string userName { get; set; }
    [MaxLength(30)]
    public string email { get; set; }
    [MaxLength(10)]
    public string phoneNumber { get; set; }
    [Required]
    public string password { get; set; }
    public string role { get; set; }
}