using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JumpStarter.Models;

namespace JumpStarter.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //Index: Registration-login-Logout //

    [HttpGet("/")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("userId") != null)
        {
            return RedirectToAction("Dashboard");
        }
        return View();
    }

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

    //*******Dashboard*****//
    [HttpGet("projects")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        
        List<Project> AllProjects = _context.Projects
        .Include(c => c.Creator)
        .Include(c => c.Supporters)
        .ThenInclude(a=>a.User)
        .ToList();
        // List<Project> AllProjects = _context.Projects
        // .Include(c => c.Creator)
        // .Include(a=>a.Supporters)
        // .ToList();

        //raised//
         int totalraised = 0;
         foreach(Project p in AllProjects)
         {
             foreach(Support s in p.Supporters)
             {
                 totalraised += s.SupportAmount;
             }
             ViewBag.TotalRaised = totalraised;
         }

        // total pledges //
        List<Support> AllSupports = _context.Supports.ToList();
        ViewBag.TotalPledges = AllSupports.Count();

        // total projects have reached their funding goal 
        int totalProjects = 0;
        foreach(Project p in AllProjects)
        {
            bool reachedGoal = p.Supporters.Any(s => s.SupportAmount >= p.Goal);
            if (reachedGoal)
            {
                totalProjects++;
            }
        }
        ViewBag.TotalProjects = totalProjects;
        return View(AllProjects);

        // int totalProjects = 0;
        // foreach(Project p in AllProjects)
        // {
        //     foreach(Support s in p.Supporters)
        //     {
        //         if(s.SupportAmount >= p.Goal)
        //         totalProjects++;
        //     }
        //     ViewBag.TotalProjects = totalProjects;
        // }
        

        
    }
    

    //*****Add Project ****//
    [HttpGet("projects/new")]
    public IActionResult AddProject()
    {
         if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpPost]
    public IActionResult CreateProject(Project newProject)
    {
         if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        
        if (ModelState.IsValid)
        {
            if(newProject.Date < DateTime.Now)
            {
                ModelState.AddModelError("Date", "End Date  must be in the future");
                return View("AddProject");
            }
            _context.Projects.Add(newProject);
            _context.SaveChanges();
            return RedirectToAction("ShowDetails", new { projectId = newProject.ProjectId});
        }
        return View("AddProject");
    }

    //*** Show Project Details ***//

    [HttpGet("projects/{projectId}")]
    public IActionResult ShowDetails(int projectId)
    {
         if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        Project? project = _context.Projects
        .Include(s=>s.Supporters)
        //.ThenInclude(u=>u.User)
        .FirstOrDefault(p=> p.ProjectId == projectId);

        int totalFunded = project.Supporters.Sum(s=>s.SupportAmount);
        ViewBag.TotalFunded = totalFunded;
        return View(project);    
    }

    public IActionResult SupportProject(int projectId, Support newSupport)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        //newSupport.UserId= (int)HttpContext.Session.GetInt32("userId");
        if (ModelState.IsValid)
        {
            bool supportExists = _context.Supports
            .Any(s => s.ProjectId == newSupport.ProjectId && s.UserId == newSupport.UserId);

            if (supportExists)
            {
                ModelState.AddModelError("SupportAmount", "You have this project already supported!");
                Project project = _context.Projects.FirstOrDefault(p=>p.ProjectId == newSupport.ProjectId);
                return View("ShowDetails",project);
            }
            _context.Supports.Add(newSupport);
            _context.SaveChanges();
            return RedirectToAction("ShowDetails", new {projectId}); 
        }
        Project selectedProject = _context.Projects.FirstOrDefault(p=>p.ProjectId == newSupport.ProjectId);
        return View("ShowDetails",selectedProject);
    }


   
   // Delete a project //
    public IActionResult DeleteProject(int projectId)
    {
        Project? projectToRemove = _context.Projects.SingleOrDefault(p => p.ProjectId == projectId);
        _context.Projects.Remove(projectToRemove);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
