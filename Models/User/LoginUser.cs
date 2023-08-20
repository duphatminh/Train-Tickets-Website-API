using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsWebsite.Models;
[Table("LoginUsers")]
public class LoginUser
{
    [Required]
    public string username { get; set; }
    [Required]
    public string password { get; set; }
}