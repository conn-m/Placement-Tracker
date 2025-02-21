using PlacementTracker.Data.Entities;
using PlacementTracker.Data.Services;
using PlacementTracker.Data.Security;
using PlacementTracker.Data.Repositories;
using Microsoft.Extensions.Logging;
using Bogus.DataSets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PlacementTracker.Data.Services
{
    public class JobApplicationServiceDb : IJobApplicationService
    {
        private readonly DatabaseContext ctx;

        public JobApplicationServiceDb(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public void Initialise()
        {
            //ctx.Initialise(); 
        }

        // ------------------ Job Application Related Operations ------------------------

        public JobApplication AddJobApp(JobApplication newJobApp)
        {
            var jobApp = new JobApplication
            {
                Position = newJobApp.Position,
                Name = newJobApp.Name,
                ActivityDate = newJobApp.ActivityDate,
                PlacementOrg = newJobApp.PlacementOrg,  
                Description = newJobApp.Description,
                UserId = newJobApp.UserId
            };
            ctx.JobApplications.Add(jobApp);
            ctx.SaveChanges();
            return jobApp; // return newly added jobApp
        }

        public JobApplication GetJobApp(int id)
        {
            return ctx.JobApplications.FirstOrDefault(s => s.Id == id);
        }

        public IList<JobApplication> GetJobAppsByUserId(int id)
        {
            return ctx.JobApplications.Where(x => x.UserId == id).ToList();
        }

        public IList<JobApplication> GetJobAppDetailsByUserId(int id, string company, string position)
        {
            return ctx.JobApplications.Where(x => x.UserId == id && x.PlacementOrg == company && x.Position == position).ToList();
        }

        public Paged<JobApplication> GetJobAppsByUserId(int page = 1, int size = 20, string orderBy = "id", string direction = "asc")
        {
            throw new NotImplementedException();
        }

        public JobApplication UpdateJobApp(JobApplication user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteJobApp(int id)
        {
            var s = GetJobApp(id);
            if (s == null)
            {
                return false;
            }
            ctx.JobApplications.Remove(s);
            ctx.SaveChanges();
            return true;
        }
        
    }
}
