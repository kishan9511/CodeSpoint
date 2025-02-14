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

    #region--HTML Basic--

    public IActionResult HTMLBasic()
    {
        return View();
    }

    #endregion



}
