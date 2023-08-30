using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsWebsite.Models;

public class TrainsDetailModel
{
    [Key]
    public int trainID { get; set; }
    [Required]
    public int stationID { get; set; }
    
    public string trainName { get; set; }
    public DateTime schedule { get; set; }
    
    public string departureStation { get; set; }
    public string arrivalStation { get; set; }
    
    public DateTime departureTime { get; set; }
    public DateTime arrivalTime { get; set; }
    
    [ForeignKey("stationID")]
    public virtual StationsDetailModel StationsDetailModel { get; set; }
    
    public virtual ICollection<CarriagesDetailModel> Carriages { get; set; }
    
}