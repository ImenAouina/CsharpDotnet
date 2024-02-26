using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TasksApp.Models;

namespace TasksApp.Controllers;

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
            HttpContext.Session.SetString("username", newUser.FirstName);
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
    //Dashboard//
    [HttpGet("todos")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        List<Todo> AllTodos = _context.Todos
        .ToList();
        return View(AllTodos);
    }

    //Add Task //
    [HttpGet("todos/new")]
    public IActionResult AddTask()
    {
         if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpPost]
    public IActionResult CreateTask(Todo newTodo)
    {
         if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        if (ModelState.IsValid)
        {
            _context.Todos.Add(newTodo);
            _context.SaveChanges();
            return RedirectToAction("ShowDetails", new { todoId = newTodo.TodoId});
        }
        return View("AddTask");
    }

    //Show Todo Details//
    [HttpGet("todos/{todoId}")]
    public IActionResult ShowDetails(int todoId)
    {
         if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        Todo? todo = _context.Todos
        .Include(u=>u.UsersInCharge)
        .Include(w=>w.Publisher)
        .FirstOrDefault(w=> w.TodoId == todoId);

        ViewBag.AllUsers = _context.Users.ToList();
        return View(todo);
    }

    //Delegate Task to the User//
    // [HttpPost]   
    // public IActionResult DelegateTask(int todoId, Delegation newDelegation)
    // {
    //     if(ModelState.IsValid)
    //     {
    //         bool delegationExists = _context.Delegations
    //         .Any(a => a.TodoId == newDelegation.TodoId && a.UserId == newDelegation.UserId);

    //         if (!delegationExists)
    //         {
    //         _context.Delegations.Add(newDelegation);
    //         _context.SaveChanges();
    //         }
    //         return RedirectToAction("ShowDetails", new { todoId = newDelegation.TodoId });   
    //     }
    //     // Todo? todo = _context.Todos
    //     //     .Include(p=>p.Publisher)
    //     //     .Include(p => p.UsersInCharge)
    //     //     .ThenInclude(c => c.User)
    //     //     .FirstOrDefault(p => p.TodoId == newDelegation.TodoId);
    //     //     ViewBag.AllUsers = _context.Users.ToList();
    //         return View("ShowDetails", new{todoId});    
    // }
    [HttpPost]
    public IActionResult DelegateTask(Delegation newDelegation)
    {
            bool delegationExists = _context.Delegations
            .Any(a => a.TodoId == newDelegation.TodoId && a.UserId == newDelegation.UserId);

            if (!delegationExists)
            {
            _context.Delegations.Add(newDelegation);
            _context.SaveChanges();
            }
            return RedirectToAction("ShowDetails", new { todoId = newDelegation.TodoId });   
    }

    //update Task //
    [HttpPost]
    public IActionResult UpdateTodo(int todoId, Todo.StatusEnum status)
    {
         if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
            Todo oldTodo = _context.Todos.FirstOrDefault(t => t.TodoId == todoId);
            oldTodo.Status = status;
            oldTodo.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
    }

    public IActionResult DeleteTask(int todoId)
    {
        Todo todoToRemove = _context.Todos.FirstOrDefault(t => t.TodoId == todoId);
        _context.Remove(todoToRemove);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }




   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
