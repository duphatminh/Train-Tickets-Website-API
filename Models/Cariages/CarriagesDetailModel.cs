using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsWebsite.Models;

public class CarriagesDetailModel
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
    public virtual TrainsDetailModel TrainsDetailModel { get; set; } 
    
    public virtual ICollection<CabinsDetailModel> Cabins { get; set; }
}