using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsWebsite.Models;
[Table("LoginUsers")]
public class LoginUser
{
    [Required]
    public string userNameOrEmail { get; set; }
    [Required]
    public string password { get; set; }
}