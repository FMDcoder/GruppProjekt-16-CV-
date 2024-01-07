using Microsoft.AspNetCore.Mvc;

namespace GruppProjekt_Grupp16_CV.Controllers
{
	public class CvController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
