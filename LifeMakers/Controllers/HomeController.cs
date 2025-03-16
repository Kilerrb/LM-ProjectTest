using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using LifeMakers.dbcontexts;
using LifeMakers.Models;

namespace LifeMakers.Controllers
{
    public class HomeController : Controller
    {
        DbContexting DB = new DbContexting();


        [HttpPost]
        public async Task<IActionResult> VerifyVolunteer(long nationalID)
        {
            var volunteer = await DB.LifeMaker.FirstOrDefaultAsync(lm => lm.NationalId == nationalID);

            if (volunteer != null)
            {
                return RedirectToAction("VolunteerDashboard", "LifeMaker", new
                {
                    id = volunteer.Id,
                    name = volunteer.Name,
                    phone = volunteer.Phone,
                    nationalID = volunteer.NationalId,
                    email = volunteer.Email,
                    joinDate = volunteer.JoinDate,
                    profileImage = volunteer.ProfileImage,
                    activities = volunteer.Activities,
                    status = volunteer.Status
                });
            }
            else
            {
                TempData["Error"] = "«·—ﬁ„ «·ﬁÊ„Ì €Ì— „ÊÃÊœ ›Ì ﬁ«⁄œ… «·»Ì«‰« .";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
