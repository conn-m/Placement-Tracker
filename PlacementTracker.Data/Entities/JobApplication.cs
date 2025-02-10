namespace PlacementTracker.Data.Entities;

public class JobApplication 
{
    public int Id { get; set; }
    public string JobTitle { get; set; }

    // Navigation properties
    public int UserId { get; set; }
    public User User { get; set; }
}