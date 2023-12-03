using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PassmanWeb.Controllers;


public class JelszoController : Controller
{
    public IActionResult MainPage()
    {
        var username = HttpContext.Session.GetString("Username");
        if (string.IsNullOrEmpty(username))
        {
            return RedirectToAction("MainPage", "Jelszo");
        }
        return View();
    }
}