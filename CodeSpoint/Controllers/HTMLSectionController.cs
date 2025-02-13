using Microsoft.AspNetCore.Mvc;

namespace CodeSpoint.Controllers;

public class HTMLSectionController : Controller
{

    #region--index--

    public IActionResult Index()
    {
        return View();
    }

    #endregion


    #region--Introduction--

    public IActionResult HTMLIntroduction()
    {
        return View();
    }

    #endregion





}
