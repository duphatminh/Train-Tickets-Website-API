// Purpose: To store the data for updating a carriage.
namespace TrainTicketsWebsite.Models;

public class UpdateCarriageModel
{
    public int stationID { get; set; }
    public string carriageName { get; set; }
    public string carriageType { get; set; }
    public string carriageStatus { get; set; }
}