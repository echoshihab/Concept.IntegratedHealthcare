using Microsoft.AspNetCore.Mvc;

namespace Proto.PatientRecordSystem.Controllers.Fhir
{
    public class BundleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
