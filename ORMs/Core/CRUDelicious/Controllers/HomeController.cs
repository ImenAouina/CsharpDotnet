using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    // ****** Get all Dishes ***** //
    public IActionResult Index()
    {
        // Dishes should be displayed in reverse chronological order (newest dish first)
        List<Dish> AllDishes = _context.Dishes
            .OrderByDescending(d => d.CreatedAt)
            .ToList();
        return View(AllDishes);
    }
//     public IActionResult Index()
//     {
//         // Get all Dishes
//         ViewBag.AllDishes = _context.Dishes.ToList();

//     	// Dishes should be displayed in reverse chronological order (newest dish first)
//         ViewBag.MostRecent = _context.Dishes
//     	    .OrderByDescending(u => u.CreatedAt)
//     	    .ToList();
// 	    return View();
//   }
//******** Get One Dish ****** //
[HttpGet("dishes/{dishId}")]
public IActionResult GetOneDish(int  dishId)
{
    Dish oneDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
    return View("OneDish", oneDish);
}

//***** Delete a Dish ****//

[HttpPost("deleteDish")]
public IActionResult DeleteDish(int  dishId)
{
    Dish? DishToDestroy = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
    _context.Dishes.Remove(DishToDestroy);
    _context.SaveChanges();
    return RedirectToAction("Index");
}

//****** Edit a Dish ****//

public IActionResult EditDish(int  dishId)
{
    Dish editedDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
    return View("EditDish", editedDish);
} 

[HttpPost("{dishId}/edit")]
public IActionResult UpdateDish(int  dishId, Dish newDish)
{
    Dish? oldDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
    if(ModelState.IsValid)
    {
        oldDish.Name = newDish.Name;
        oldDish.Chef= newDish.Chef;
        oldDish.Tastiness = newDish.Tastiness;
        oldDish.Calories = newDish.Calories;
        oldDish.Description = newDish.Description;
        oldDish.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    return View("EditDish", newDish);
}


//****** Add a dish ********//

[HttpPost("new")]
public IActionResult AddDish(Dish newDish)
{
    if(ModelState.IsValid)
    {
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    else 
    {
        return View("AddDish");
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
