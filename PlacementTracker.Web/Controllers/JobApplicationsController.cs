using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlacementTracker.Data.Entities;
using PlacementTracker.Data.Repositories;
using PlacementTracker.Data.Services;
using PlacementTracker.Web.Models.JobApp;

namespace PlacementTracker.Web.Controllers
{
    [Authorize]
    public class JobApplicationsController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IJobApplicationService _jobAppService;

        public JobApplicationsController(IJobApplicationService jobAppService)
        {
            _jobAppService = jobAppService;
        }

        // GET: JobApplications
        public IActionResult Index()
        {
            return View(_jobAppService.GetJobAppsByUserId(User.GetSignedInUserId()).ToList());
        }

        // GET: JobApplications/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = _jobAppService.GetJobApp(id.Value);

            var jobDetails = _jobAppService.GetJobAppDetailsByUserId(User.GetSignedInUserId(), job.PlacementOrg, job.Position).ToList();

            return View(jobDetails);
        }

        // GET: JobApplications/AddActivity
        public IActionResult AddActivity(int id)
        {
            var job = _jobAppService.GetJobApp(id);

            AddJobAppViewModel viewModel = new AddJobAppViewModel
            {
                Position = job.Position,
                PlacementOrg = job.PlacementOrg,
                Name = job.Name,
                id = id,
                UserId = User.GetSignedInUserId()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddActivity(AddJobAppViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                JobApplication jobApp = new JobApplication
                {
                    Position = viewModel.Position,
                    Name = viewModel.Name,
                    ActivityDate = viewModel.ActivityDate,
                    Description = viewModel.Description,
                    PlacementOrg = viewModel.PlacementOrg,
                    UserId = viewModel.UserId
                };

                _jobAppService.AddJobApp(jobApp);

                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }

        // GET: JobApplications/Create
        public IActionResult Create()
        {
            AddJobAppViewModel viewModel = new AddJobAppViewModel();
            viewModel.UserId = User.GetSignedInUserId();
            return View(viewModel);
        }

        // POST: JobApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddJobAppViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                JobApplication jobApp = new JobApplication
                {
                    Position = viewModel.Position,
                    Name = viewModel.Name,
                    ActivityDate = viewModel.ActivityDate,
                    Description = viewModel.Description,
                    PlacementOrg = viewModel.PlacementOrg,
                    UserId = viewModel.UserId
                };

                _jobAppService.AddJobApp(jobApp);

                //_context.JobApplications.Add(jobApp);
                //_context.Add(jobApplication);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: JobApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication == null)
            {
                return NotFound();
            }
            return View(jobApplication);
        }

        // POST: JobApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ActivityDate,PlacementOrg,Description,AppUserId")] JobApplication jobApplication)
        {
            if (id != jobApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicationExists(jobApplication.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobApplication);
        }

        // GET: JobApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // POST: JobApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication != null)
            {
                _context.JobApplications.Remove(jobApplication);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(e => e.Id == id);
        }
    }
}
