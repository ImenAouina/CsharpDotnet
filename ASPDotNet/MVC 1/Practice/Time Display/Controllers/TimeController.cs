using Microsoft.AspNetCore.Mvc;
namespace TimeDisplay.Controllers;
public class TimeController : Controller
{
   
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public ViewResult Time()
    {
        return View();
    }
    
    
}

