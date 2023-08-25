using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace TrainTicketsWebsite.Models;

public class RegisterUser
{
    [Required]
    public string userName { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
}