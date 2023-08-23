using Microsoft.Build.Framework;

namespace TrainTicketsWebsite.Models;

public class CreateTrainModel
{
    [Required]
    public int stationID { get; set; }
    [Required]
    public string trainName { get; set; }
    [Required]
    public string departureStation { get; set; }
    [Required]
    public string arrivalStation { get; set; }
}