using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers;
public class HelloController : Controller
{
   
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public string Index()
    {
        return "This is my index";
    }
    
    // This will go to "localhost:5XXX/Projects"
    [HttpGet("Projects")]
    public string Projects()
    {
        return "These are my Projects";
    }
    
    // This will go to "localhost:5XXX/Contact"
    [HttpGet("Contact")]
    public string Contact()
    {
        return "This is my Contact ";
    }
}

