using PlacementTracker.Data.Entities;
using System.Diagnostics;

namespace PlacementTracker.Web.Models.User
{
    public class StudDashboardViewModel
    {
        public IList<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
        public int CountActivities { get; set; }
        public int CountAppsSubmitted { get; set; }
        public int CountInterviews { get; set; }
        public int CountOffers { get; set; }

    }
}
