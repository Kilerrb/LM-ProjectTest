using LifeMakers.dbcontexts;
using LifeMakers.Models;
using Microsoft.AspNetCore.Mvc;

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


            int campaignCount = activities.Split(' ').Count(word => word.Contains("حملة"));
            int convoyCount = activities.Split(' ').Count(word => word.Contains("قافلة"));
            int otherCount = activities.Split(' ').Length - (campaignCount + convoyCount);

            ViewBag.CampaignCount = campaignCount;
            ViewBag.ConvoyCount = convoyCount;
            ViewBag.OtherCount = otherCount;

            return View(volunteer);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
