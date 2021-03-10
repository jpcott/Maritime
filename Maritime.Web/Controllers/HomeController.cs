using Maritime.Web.ModelBuilders.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maritime.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIndexModelBuilder indexModelBuilder;

        public HomeController(IIndexModelBuilder indexModelBuilder)
        {
            this.indexModelBuilder = indexModelBuilder;
        }

        public IActionResult Index()
        {
            return View(indexModelBuilder.Build());
        }
    }
}
