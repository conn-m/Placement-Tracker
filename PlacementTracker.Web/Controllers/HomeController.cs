using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlacementTracker.Data.Services;
using PlacementTracker.Web.Models;
using PlacementTracker.Web.Models.User;

namespace PlacementTracker.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IJobApplicationService _jobAppService;

        public HomeController(IJobApplicationService jobAppService)
        {
            _jobAppService = jobAppService;
        }

        public IActionResult Index()
        {
            int id = User.GetSignedInUserId();

            StudDashboardViewModel vm = new StudDashboardViewModel();
            vm.JobApplications = _jobAppService.GetJobAppsByUserId(User.GetSignedInUserId()).Where(x => x.Name== "Applied For Job").ToList();
            vm.CountActivities = 1; // await _context.Activity.CountAsync();
            vm.CountAppsSubmitted = 2; // await _context.Activity.Where(x => x.Name == "Applied For Job").CountAsync();
            vm.CountInterviews = 3; // await _context.Activity.Where(x => x.Name == "Attended Interview").CountAsync();
            vm.CountOffers = 4; // await _context.Activity.Where(x => x.Name == "Received Job Offer").CountAsync();

            return View(vm);
        }

        [Authorize]
        public IActionResult Secure()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
