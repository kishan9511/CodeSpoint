using Microsoft.AspNetCore.Mvc;

namespace CodeSpoint.Controllers;

public class HTMLSectionController : Controller
{
    public IActionResult HTMLIntroduction()
    {
        return View();
    }
}
