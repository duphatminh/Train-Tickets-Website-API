using Microsoft.Build.Framework;

namespace TrainTicketsWebsite.Models;

public class UpdateTrainModel
{
    [Required]
    public string departureStation { get; set; }
    [Required]
    public string arrivalStation { get; set; }
    [Required]
    public DateTime departureTime { get; set; }
    [Required]
    public DateTime arrivalTime { get; set; }
}