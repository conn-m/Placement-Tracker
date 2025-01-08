using System;

namespace PlacementTracker.Models
{
    public class PlacementActivity
    {
        public int Id { get; set; }
        public string ActivityType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
