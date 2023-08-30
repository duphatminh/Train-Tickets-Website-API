using System.ComponentModel.DataAnnotations;

namespace TrainTicketsWebsite.Models;

public class StationsDetailModel
{
    [Key]
    public int stationID { get; set; }
    [Required]
    [MaxLength(20)]
    public string stationName { get; set; }
    public string stationLocation { get; set; }
    
    public virtual ICollection<TrainsDetailModel> Trains { get; set; }
}