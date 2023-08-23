using Microsoft.Build.Framework;

namespace TrainTicketsWebsite.Models;

public class UpdateTrainModel
{
    [Required]
    public string departureStation { get; set; }
}