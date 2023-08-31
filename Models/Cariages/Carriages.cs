using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsWebsite.Models;

public class Carriages
{
    [Key]
    public int carriageID { get; set; }
    public int trainID { get; set; }
    [Required]
    public string carriageName { get; set; }
    [Required]
    public string carriageType { get; set; }
    public string carriageStatus { get; set; }
    
    [ForeignKey("trainID")]
    public virtual Trains Trains { get; set; } 
    
    public virtual ICollection<Cabins> Cabins { get; set; }
}