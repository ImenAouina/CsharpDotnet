using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string message= "message";
        return View("Index", message);
    }

    public IActionResult Privacy()
    {
        return View();
    }

     [HttpGet("numbers")]
     public IActionResult Numbers()
     {
        int [] intArray = new int[] {1,30,23,56,33,209,100,456,28};
        return View(intArray);
     }

      [HttpGet("user")]
     public IActionResult AUser()
     {
        User newUser = new User()
        {
            FirstName = "Moose",
            LastName = "Philipp"
        };
        return View(newUser);
     }

       [HttpGet("users")]
     public IActionResult Users()
     {
        List<User> userList = new List<User>();
        User newUser1 = new User()
        {
            FirstName = "Moose",
            LastName = "Philipp"
        };
        User newUser2 = new User()
        {
            FirstName = "Sarah",
            LastName = ""
        };
        User newUser3 = new User()
        {
            FirstName = "Jerry",
            LastName = ""
        };
        User newUser4 = new User()
        {
            FirstName = "Rene",
            LastName = "Ricky"
        };
        userList.Add(newUser1) ;
        userList.Add(newUser2);
        userList.Add(newUser3);
        userList.Add(newUser4);
        return View(userList);
     }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
