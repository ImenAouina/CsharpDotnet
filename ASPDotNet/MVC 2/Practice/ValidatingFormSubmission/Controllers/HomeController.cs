using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ValidatingFormSubmission.Models;

namespace ValidatingFormSubmission.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

     [HttpPost("success")]
    //public IActionResult Create(User newUser)
    public IActionResult Create()
    {
        if (ModelState.IsValid)
        {
            //return View("Success", newUser);
            return View("Success");

        }
        else
        {
            // render validation in the View
            return View("Index");
        }
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
