using Microsoft.AspNetCore.Mvc;
namespace Portfolio2.Controllers;
public class PortfolioController : Controller
{
   
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public ViewResult Home()
    {
        return View("Home");
    }
    
    // This will go to "localhost:5XXX/Projects"
    [HttpGet("Projects")]
    public ViewResult Projects()
    {
        //return "These are my Projects";
        return View("Projects");
    }
    
    // This will go to "localhost:5XXX/Contact"
    [HttpGet("Contact")]
    public ViewResult Contact()
    {
        //return "This is my Contact ";
        return View("Contact");
    }
}

