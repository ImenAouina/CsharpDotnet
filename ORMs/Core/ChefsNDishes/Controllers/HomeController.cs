using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ChefsNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
     private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //*******Display Dishes*****//

    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
         ViewBag.AllDishes  = _context.Dishes
         .Include(dish => dish.Chef)
         .ToList();
        return View();
    }
    //*********Add a dish **//

    [HttpPost("dishes/new/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Dishes.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");  
        }
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View("AddDish");
    }

    [HttpGet("dishes/new")]
    public IActionResult AddDish()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View();
    }
    //***Display Chefs*****//

    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs
        .Include(c=>c.CreatedDishes)
        .ToList();
        return View(AllChefs);
    }
    [HttpGet("chefs/new")]
    public IActionResult AddChef()
    {
        return View();
    }

    [HttpPost("chefs/new/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            if(newChef.DateOfBirth > DateTime.Now)
            {
                ModelState.AddModelError("DateOfBirth", "Date of Birth must be in the past");
                return View("AddChef");
            }
            int Age = DateTime.Now.Year - newChef.DateOfBirth.Year;
            if(Age < 18)
            {
                ModelState.AddModelError("DateOfBirth", "Chef must be at least 18 years old to be added");
                return View("AddChef");
            }
            
            _context.Chefs.Add(newChef);
            _context.SaveChanges();
    
            return RedirectToAction("Index");   
            
        }
        else{
            return View("AddChef"); 
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
