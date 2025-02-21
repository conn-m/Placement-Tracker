namespace PlacementTracker.Web.Models.JobApp
{
    public class AddJobAppViewModel
    {
        public string Position { get; set; }
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public string PlacementOrg { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        //store job application id
        public int? id { get; set; }
    }
}
