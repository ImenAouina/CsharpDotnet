using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscodeGenerator.Models;
using Microsoft.AspNetCore.Http;




namespace RandomPasscodeGenerator.Controllers;

public class HomeController : Controller
{
    public int numberOfPasscode;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpPost("Generate")]
    public IActionResult Generate()
    {    
        if (HttpContext.Session.GetInt32("keyNumberOfPasscode") != null)
        {
            // if "keyNumberOfPasscode" key exist in session so redefine numberOfPasscode by it's value
            numberOfPasscode = (int)HttpContext.Session.GetInt32("keyNumberOfPasscode");
        }
            // else redefine it to 0
        else numberOfPasscode = 0;
        //***********other way************// 

        //numberOfPasscode = HttpContext.Session.GetInt32("keyNumberOfPasscode") ?? 0;

        string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";  
        Random rand = new Random();  
        string randomPassCode ="";
        //numberOfPasscode = HttpContext.Session.GetInt32("keyNumberOfPasscode") ?? 0;
        
        for(int i=0; i<14; i++)
        {
            randomPassCode += chars[rand.Next(chars.Length)];
            
        }
        numberOfPasscode++;
        
        HttpContext.Session.SetInt32("keyNumberOfPasscode", numberOfPasscode);
        HttpContext.Session.SetString("keyRandomPassCode", randomPassCode);
        return RedirectToAction("Index");
    }


    public IActionResult Index()
    {
        return View();
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
