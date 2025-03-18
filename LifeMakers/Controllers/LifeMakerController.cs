using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using LifeMakers.dbcontexts;
using LifeMakers.Models;

namespace LifeMakers.Controllers
{
    public class LifeMakerController : Controller
    {
        private readonly DbContexting DB = new DbContexting();

        public IActionResult VolunteerDashboard(int id, string name, string phone, long nationalID, string email, DateTime joinDate, string profileImage, string activities, string status)
        {
            var volunteer = new LifeMaker
            {
                Id = id,
                Name = name,
                Phone = phone,
                NationalId = nationalID,
                Email = email,
                JoinDate = joinDate,
                ProfileImage = profileImage,
                Activities = activities,
                Status = status
            };

            string safeActivities = activities ?? string.Empty;

            int campaignCount = Regex.Matches(safeActivities, "(حملة|حملات)", RegexOptions.IgnoreCase).Count;
            int convoyCount = Regex.Matches(safeActivities, "(قافلة|قوافل)", RegexOptions.IgnoreCase).Count;
            int attractCount = Regex.Matches(safeActivities, "(جذب)", RegexOptions.IgnoreCase).Count;

            ViewBag.CampaignCount = campaignCount;
            ViewBag.ConvoyCount = convoyCount;
            ViewBag.AttractionCount = attractCount;

            return View(volunteer);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
