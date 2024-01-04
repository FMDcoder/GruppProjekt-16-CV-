using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace GruppProjekt_Grupp16_CV.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SearchBarValidate commonData = new SearchBarValidate();

            foreach (var key in ModelState.Keys.ToList())
            {
                if (key != "search")
                {
                    ModelState.Remove(key);
                }
            }

            TryValidateModel(commonData);

            ViewBag.CommonData = commonData;

            base.OnActionExecuting(filterContext);
        }
    }
}
