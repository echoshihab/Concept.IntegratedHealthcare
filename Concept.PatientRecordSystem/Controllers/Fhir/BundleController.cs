using Microsoft.AspNetCore.Mvc;

namespace Concept.PatientRecordSystem.Controllers.Fhir
{
    public class BundleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
