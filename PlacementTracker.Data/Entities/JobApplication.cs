namespace PlacementTracker.Data.Entities;

public class JobApplication 
{
    public int Id { get; set; }
    public string Position { get; set; }
    public string Name { get; set; }
    public DateTime ActivityDate { get; set; }
    public string PlacementOrg { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }

    // Navigation properties
    public User User { get; set; }
}