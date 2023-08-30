using System.ComponentModel.DataAnnotations;

namespace TrainTicketsWebsite.Models;

public class CreateCarriageModel
{
    public int trainID { get; set; }
    [Required]
    public string carriageName { get; set; }
    [Required]
    public string carriageType { get; set; }
    public string carriageStatus { get; set; }
}