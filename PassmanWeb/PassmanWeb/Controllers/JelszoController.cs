using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PassmanWeb.Models;

namespace PassmanWeb.Controllers;


public class JelszoController : Controller
{
    private readonly ApplicationDbContext _context;
    
    public JelszoController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult MainPage()
    {
        var username = HttpContext.Session.GetString("Username");
        if (string.IsNullOrEmpty(username))
        {
            // Redirect to a login action
            return RedirectToAction("Login", "User");
        }
        return View();
    }

    [HttpGet]
    public IActionResult AddVaultEntry()
    {
        var username = HttpContext.Session.GetString("Username");
        if (string.IsNullOrEmpty(username))
        {
            // Redirect to a login action
            return RedirectToAction("Login", "User");
        }
        return View();
    }

    [HttpPost]
    public IActionResult AddVaultEntry(string username, string password, string website)
    {
        var usernameSession = HttpContext.Session.GetString("Username");
        if (string.IsNullOrEmpty(usernameSession))
        {
            return RedirectToAction("MainPage", "Jelszo");
        }
        var user = _context.Users.FirstOrDefault(u => u.Username == usernameSession);
        EncryptedType encryptedType = new EncryptedType();
        if (user != null) _context.VaultEntries.Add(new VaultEntry(user.Id, username, encryptedType.Encrypt(password, user.Email).Secret, website));
        _context.SaveChanges();
        return RedirectToAction("MainPage", "Jelszo");
    }
}