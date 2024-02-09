using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginAndRegistration.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
       if(ModelState.IsValid) 
       {
            if(_context.Users.Any(a => a.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email is already in use!");
                return View("Index");
            }
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            user.Password = Hasher.HashPassword(user, user.Password);
            var newUser = _context.Users.Add(user).Entity;
            //_context.Add(newUser);
            _context.SaveChanges();

            // Add userId to the session
            HttpContext.Session.SetInt32("userId", newUser.UserId);
            return RedirectToAction("Success");

       }
       else
       {
            return View("Index");
       }
    }
    [HttpGet("success")]
    public IActionResult Success()
     {
        if(HttpContext.Session.GetInt32("userId") == null)
            return RedirectToAction("Register");
        return View();
    }

     [HttpPost("login")]
    public IActionResult Login(UserLogin logUser)
    {
       if(ModelState.IsValid) 
       {
            User registeredUser = _context.Users.FirstOrDefault(u => u.Email == logUser.LoginEmail);
            if(registeredUser == null)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email or Password");
                return View("Index");
            }
            PasswordHasher<UserLogin> PasswordHasher = new PasswordHasher<UserLogin>();
            var result = PasswordHasher.VerifyHashedPassword(logUser, registeredUser.Password, logUser.LoginPassword);
            if(result == 0)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email or Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("userId", registeredUser.UserId);
            return RedirectToAction("Success");
            
       }
       return View("Index");
      
    }
    [HttpGet("login")]
    public IActionResult Login()
    {
        return View("_Login");
    }

    [HttpGet("logout")]
    public RedirectToActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
