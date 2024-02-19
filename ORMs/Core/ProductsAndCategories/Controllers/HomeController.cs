using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    ///*****Products*****//
    public IActionResult Index()
    {
        ViewBag.AllProducts = _context.Products.ToList();
        return View();
    }

    [HttpPost("AddProduct")]
    public IActionResult AddProduct(Product newProduct)
    {
        if(ModelState.IsValid)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index"); 
        }
        ViewBag.AllProducts = _context.Products.ToList();
        return View("Index"); 
          
    }
    ///*****Categories*****//
    
     public IActionResult Categories()
    {
        ViewBag.AllCategories = _context.Categories.ToList();
        return View();
    }

    [HttpPost("AddCategory")]
    public IActionResult AddCategory(Category newCategory)
    {
        if(ModelState.IsValid)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Categories"); 
        }
        ViewBag.AllCategories = _context.Categories.ToList();
        return View("Categories"); 
          
    }

    //**Show Categories of product**//
    [HttpGet("products/{productId}")]
    public IActionResult ShowProduct(int productId)
    {
        var CategoriesOfProduct = _context.Products
            .Include(p => p.MyCategories)
            .ThenInclude(c => c.Category)
            .FirstOrDefault(prod => prod.ProductId == productId);

            ViewBag.AllCategories = _context.Categories.ToList();
    
         return View(CategoriesOfProduct);   
    }
    
    //**Show Products of Category**//
    [HttpGet("categories/{categoryId}")]
    public IActionResult ShowCategory(int categoryId)
    {
        var ProductsOfCategory = _context.Categories
            .Include(c => c.MyProducts)
            .ThenInclude(p => p.Product)
            .FirstOrDefault(prod => prod.CategoryId == categoryId);

            ViewBag.AllProducts = _context.Products.ToList();
    
         return View(ProductsOfCategory);   
    }
    //Add Category to Product 
    [HttpPost]   
    public IActionResult AddCategoryToProduct(Association newAssociation)
    {
        if(ModelState.IsValid)
        {
            
            bool associationExists = _context.Associations
            .Any(a => a.ProductId == newAssociation.ProductId && a.CategoryId == newAssociation.CategoryId);

            if (!associationExists)
            {
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            }
            return RedirectToAction("ShowProduct", new { productId = newAssociation.ProductId });   
        }
        Product? product = _context.Products
            .Include(p => p.MyCategories)
            .ThenInclude(c => c.Category)
            .FirstOrDefault(p => p.ProductId == newAssociation.ProductId);
            ViewBag.AllCategories = _context.Categories.ToList();
            return View("ShowProduct", product);    
    }
    //Add Product To Category

    [HttpPost]
    public IActionResult AddProductToCategory(Association newAssociation)
    {
        if(ModelState.IsValid)
        {    
            bool associationExists = _context.Associations
            .Any(a => a.ProductId == newAssociation.ProductId && a.CategoryId == newAssociation.CategoryId);

            if (!associationExists)
            {
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            }
            return RedirectToAction("ShowCategory", new { categoryId = newAssociation.CategoryId });   
        }
        Category? category = _context.Categories
            .Include(c => c.MyProducts)
            .ThenInclude(p => p.Product)
            .FirstOrDefault(a=> a.CategoryId == newAssociation.CategoryId);
            ViewBag.AllProducts = _context.Products.ToList();
            return View("ShowCategory", category);    
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
