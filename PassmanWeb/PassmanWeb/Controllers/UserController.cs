using Microsoft.AspNetCore.Mvc;
using PassmanWeb.Models;

namespace PassmanWeb.Controllers;

public class UserController: Controller
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        EncryptedType encryptedType = new EncryptedType();
        
        var user = _context.Users.FirstOrDefault(u => u.Username == password && u.Password == encryptedType.Hash(password));

        if (user == null)
        {
            // User not found
            return View();
        }
        else
        {
            // User found
            // Here you can start a new session or set a cookie
            return RedirectToAction("Index", "Home");
        }
    }
}
