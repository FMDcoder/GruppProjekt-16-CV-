using Microsoft.AspNetCore.Mvc;

namespace GruppProjekt_Grupp16_CV.Controllers
{
    public class CreateController : BaseController
    {
        public IActionResult Education()
        {
            return View();
        }
        public IActionResult Project()
        {
            return View();
        }

    }
}
