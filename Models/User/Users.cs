using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsWebsite.Models;
public class Users
{
    [Key]
    public int user_ID { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    [MaxLength(30)]
    public string email { get; set; }
    [Required]
    [MaxLength(10)]
    public string phoneNumber { get; set; }
    public string password { get; set; }
    public string role { get; set; }
}