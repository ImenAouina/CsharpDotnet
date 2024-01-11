using Microsoft.AspNetCore.Mvc;
namespace RazorFun.Controllers;
public class FoodController : Controller
{
   
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }
    
}

