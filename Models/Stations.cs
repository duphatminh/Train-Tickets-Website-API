using System.ComponentModel.DataAnnotations;

namespace TrainTicketsWebsite.Models;

public class Stations
{
    [Key]
    public int stationID { get; set; }
    [Required]
    [MaxLength(20)]
    public string stationName { get; set; }
    public string stationLocation { get; set; }
    
    public virtual ICollection<TrainDetailsModel> Trains { get; set; }
}