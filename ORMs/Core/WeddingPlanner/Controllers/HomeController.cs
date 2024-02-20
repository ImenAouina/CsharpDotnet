using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("userId") != null)
        {
            return RedirectToAction("Dashboard");
        }
        return View();
    }

    //Register-login-Logout

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email already taken!!");
                return View("Index");
            }
            // Hash Password
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            System.Console.WriteLine(newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            // Add User ID in Session
            HttpContext.Session.SetInt32("userId", newUser.UserId);
            return RedirectToAction("Dashboard");
        }
        return View("Index");
    }

    [HttpPost("/users/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            // Login
            // search for a user that match the login email
            var UserFromDB = _context.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
            if (UserFromDB == null)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            //  verify Password 
            var result = hasher.VerifyHashedPassword(loginUser, hashedPassword: UserFromDB.Password, loginUser.LoginPassword);
            if (result == 0)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("userId", UserFromDB.UserId);
            HttpContext.Session.SetString("username", UserFromDB.FirstName);
            return RedirectToAction("Dashboard");
        }
        return View("Index");
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    //*******Dashboard*******//
    [HttpGet("weddings")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        List<Wedding> AllWeddings = _context.Weddings
        .Include(w => w.MyGuests)
        .ThenInclude(a => a.User)
        .ToList();
        return View(AllWeddings);
    
    }

    [HttpGet("weddings/new")]
    public IActionResult AddWedding()
    {
         if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpPost]
    public IActionResult CreateWedding(Wedding newWedding)
    {
         if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        
        if (ModelState.IsValid)
        {
            if(newWedding.Date < DateTime.Now)
            {
                ModelState.AddModelError("Date", "Date  must be in the future");
                return View("AddWedding");
            }
            _context.Weddings.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("ShowWedding", new { weddingId = newWedding.WeddingId});
        }
        return View("AddWedding");
    }

    [HttpGet("weddings/{weddingId}")]
    public IActionResult ShowWedding(int weddingId)
    {
         if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        Wedding? wedding = _context.Weddings
        .Include(w=>w.MyGuests)
        .ThenInclude(u=>u.User)
        .FirstOrDefault(w=> w.WeddingId == weddingId);
        return View(wedding);
    }

    public IActionResult DeleteWedding(int weddingId)
    {
        Wedding? weddingToRemove = _context.Weddings.SingleOrDefault(w => w.WeddingId == weddingId);
        _context.Weddings.Remove(weddingToRemove);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    public IActionResult RSVPWedding(int weddingId)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        Attendance newAttendance = new Attendance
        {
            UserId = (int)HttpContext.Session.GetInt32("userId"),
            WeddingId = weddingId
        };
            _context.Attendances.Add(newAttendance);
            _context.SaveChanges();
            
            return RedirectToAction("Dashboard");   
    }

    public IActionResult UnRSVPWedding(int weddingId)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        Attendance? attendanceToDelete = _context.Attendances
        .FirstOrDefault(a => a.WeddingId == weddingId 
        && a.UserId == (int)HttpContext.Session.GetInt32("userId"));
        
        _context.Attendances.Remove(attendanceToDelete);
        _context.SaveChanges();     
        return RedirectToAction("Dashboard");   
    }

    //(Optional) Weddings expire when the scheduled date passes, and are removed from the database.
    public IActionResult RemoveExpiredWeddings()
    {
        var AllWeddings = _context.Weddings.ToList();
        var expiredWeddings = AllWeddings.Where(w => w.Date < DateTime.Now).ToList();
        foreach(Wedding wedding in expiredWeddings)
        {
            _context.Weddings.Remove(wedding);
        }
        _context.SaveChanges();
        return RedirectToAction("Dashboard"); 
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
