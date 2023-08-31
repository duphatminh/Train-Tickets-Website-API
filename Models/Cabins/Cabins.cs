using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsWebsite.Models;

public class Cabins
{
    [Key]
    public int cabinID { get; set; }
    public int carriageID { get; set; }
    [Required]
    [MaxLength(10)]
    public string cabinName { get; set; }
    
    [ForeignKey("carriageID")]
    public virtual Carriages Carriages { get; set; }
    
    public virtual ICollection<Seats> Seats { get; set; }
    
}