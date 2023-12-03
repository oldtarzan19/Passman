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
    public IActionResult JelszoMainPage()
    {
        var username = HttpContext.Session.GetString("Username");
        if (string.IsNullOrEmpty(username))
        {
            // Redirect to a login action
            return RedirectToAction("Login", "User");
        }
        
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        var rawVaultEntries = _context.VaultEntries.Where(v => v.UserId == user.Id).ToList();
       

        // Pass the vault entries to the view
        return View(rawVaultEntries);
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
            return RedirectToAction("JelszoMainPage", "Jelszo");
        }
        var user = _context.Users.FirstOrDefault(u => u.Username == usernameSession);
        EncryptedType encryptedType = new EncryptedType();
        if (user != null) _context.VaultEntries.Add(new VaultEntry(user.Id, username, encryptedType.EncryptString(password, user.Email), website));
        _context.SaveChanges();
        return RedirectToAction("JelszoMainPage", "Jelszo");
    }

    public IActionResult Delete(string id)
    {
        var username = HttpContext.Session.GetString("Username");
       
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        var vaultEntry = _context.VaultEntries.FirstOrDefault(v => v.Id == int.Parse(id));
        if (vaultEntry != null && user != null && vaultEntry.UserId == user.Id)
        {
            _context.VaultEntries.Remove(vaultEntry);
            _context.SaveChanges();
        }
        return RedirectToAction("JelszoMainPage", "Jelszo");
    }
    

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }
}