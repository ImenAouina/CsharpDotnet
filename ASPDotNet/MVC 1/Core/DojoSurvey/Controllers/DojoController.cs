using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;
public class DojoController : Controller
{
   
    // This will go to "localhost:5XXX"
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }
      // This will go to "localhost:5XXX/Result"
    [HttpPost("Result")]
     public IActionResult Result(string name, string location, string language, string comment){
        //return View();
        ViewBag.name = name;
        ViewBag.location = location;
        ViewBag.language = language;
        ViewBag.comment = comment;
        //return RedirectToAction("Result");
        return View();
    }   

     // [HttpPost]
    // [Route("Result")]
    // public IActionResult Result(string name, string location, string language, string comment)
    // {
    //     ViewData["name"] = name;
    //     ViewData["location"] = location;
    //     ViewData["language"] = language;
    //     ViewData["comment"] = comment;
    //     return View("Result");
    // }
}

