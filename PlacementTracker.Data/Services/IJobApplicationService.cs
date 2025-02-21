using PlacementTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementTracker.Data.Services
{
    // This interface describes the operations that a JobApplicationService class implementation should provide
    public interface IJobApplicationService
    {
        // Initialise the repository - only to be used during development 
        void Initialise();

        // ---------------- Job Application Management --------------
        IList<JobApplication> GetJobAppsByUserId(int id);
        IList<JobApplication> GetJobAppDetailsByUserId(int id, string company, string position);
        Paged<JobApplication> GetJobAppsByUserId(int page = 1, int size = 20, string orderBy = "id", string direction = "asc");
        JobApplication GetJobApp(int id);
        JobApplication AddJobApp(JobApplication newJobApp);
        JobApplication UpdateJobApp(JobApplication user);
        bool DeleteJobApp(int id);

    }
}

