using Microsoft.AspNetCore.Authorization;
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
        if (username.Trim().Length!=0 && password.Trim().Length!=0)
        {
            EncryptedType encryptedType = new EncryptedType();
        
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == encryptedType.Hash(password));

            if (user == null)
            {
                // User not found
                return View();
            }
            else
            {
                // Add the user to the session
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Email", user.Email);
                return RedirectToAction("Index", "Home");
            }
        }else
        {
            return View();
        }
        
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(string username, string password, string email, string firstName, string lastName)
    {
        EncryptedType encryptedType = new EncryptedType();
        
        var user = _context.Users.FirstOrDefault(u => u.Username == username);

        if (user == null)
        {
            // User not found
            _context.Users.Add(new User(username, encryptedType.Hash(password), email, firstName, lastName));
            _context.SaveChanges();
            HttpContext.Session.SetString("Username", username);
            HttpContext.Session.SetString("Email", email);
            return RedirectToAction("JelszoMainPage", "Jelszo");
        }
        else
        {
            
            return RedirectToAction("Index", "Home");
        }
    }
}
