using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context= context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("customers")]
    public IActionResult Customers()
    {
        ViewBag.AllCustomers = _context.Customers.ToList();
        return View();
    }
    [HttpPost]
    public IActionResult CreateCustomer(Customer newCustomer)
    {
        if (ModelState.IsValid)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return RedirectToAction("Customers");
        }
        ViewBag.AllCustomers = _context.Customers.ToList();
        return View("Customers");
    }

    // Delete Customer
    public IActionResult DeleteCustomer(int customerId)
    {
        Customer? CustomerToRemove = _context.Customers
        .SingleOrDefault(b=> b.CustomerId == customerId);
        _context.Customers.Remove(CustomerToRemove);
        _context.SaveChanges();
        return RedirectToAction("Customers");
    }

    [HttpGet("orders")]
    public IActionResult Orders()
    {
        ViewBag.AllOrders = _context.Orders
        .Include(c=> c.Customer)
        .OrderByDescending(o=>o.CreatedAt).
        ToList();
        ViewBag.AllCustomers = _context.Customers.ToList();
        ViewBag.AllProducts = _context.Products.ToList();
        return View();
    }

    //   public IActionResult CreateOrder(int customerId, int productId, int quantity)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         Order newOrder = new Order() { CustomerId = customerId, ProductId = productId, Quantity= quantity };
    //         Product orderedProduct = _context.Products.FirstOrDefault(p=>p.ProductId == productId);

    //         if(newOrder.Quantity >  orderedProduct.Quantity || orderedProduct.Quantity==0 )
    //         {
    //             ModelState.AddModelError("Quantity", "Solde out");
    //             return View("Orders");
    //         }
    //         _context.Orders.Add(newOrder);

    //         if(orderedProduct.Quantity - newOrder.Quantity > 0)
    //             orderedProduct.Quantity -= newOrder.Quantity;
    //         else
    //             orderedProduct.Quantity = 0;
    //         _context.SaveChanges();
    //         return RedirectToAction("Orders");
    //     }
    //     ViewBag.AllOrders = _context.Orders
    //     .Include(c=>c.Customer)
    //     .Include(p=>p.Product)
    //     .OrderByDescending(o=>o.CreatedAt).ToList();
    //     ViewBag.AllCustomers = _context.Customers.ToList();
    //     ViewBag.AllProducts = _context.Products.ToList();
    //     return View("Orders");
    // }

    public IActionResult CreateOrder(int customerId, int productId, int quantity)
{
    if (ModelState.IsValid)
    {
        Product orderedProduct = _context.Products.FirstOrDefault(p => p.ProductId == productId);

        if (orderedProduct == null)
        {
            ModelState.AddModelError("ProductId", "Invalid product selected");
            PopulateDropdowns();
            return View("Orders");
        }

        if (quantity <= 0)
        {
            ModelState.AddModelError("Quantity", "Quantity must be greater than zero");
            PopulateDropdowns();
            return View("Orders");
        }

        if (orderedProduct.Quantity < quantity)
        {
            ModelState.AddModelError("Quantity", "Insufficient stock");
            PopulateDropdowns();
            return View("Orders");
        }

        Order newOrder = new Order() { CustomerId = customerId, ProductId = productId, Quantity = quantity };
        _context.Orders.Add(newOrder);
        orderedProduct.Quantity -= quantity;
        _context.SaveChanges();
        return RedirectToAction("Orders");
    }

    PopulateDropdowns();
    return View("Orders");
}

private void PopulateDropdowns()
{
    ViewBag.AllOrders = _context.Orders
        .Include(c => c.Customer)
        .Include(p => p.Product)
        .OrderByDescending(o => o.CreatedAt)
        .ToList();
    ViewBag.AllCustomers = _context.Customers.ToList();
    ViewBag.AllProducts = _context.Products.ToList();
}

    [HttpGet("products")]
    public IActionResult Products()
    {
        ViewBag.AllProducts = _context.Products
        .Include(o=>o.OrderedBy)
        .ToList();
        return View();
    }

    [HttpPost]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Products");
        }
        ViewBag.AllProducts = _context.Products.ToList();
        return View("Products");
    }

    [HttpGet("/")]
    public IActionResult Dashboard()
    {
        ViewBag.AllProducts = _context.Products
        .Take(6)
        .ToList();
        ViewBag.AllCustomers = _context.Customers
        .OrderByDescending(c=>c.CreatedAt)
        .Take(3)
        .ToList();
        ViewBag.AllOrders = _context.Orders
        .Include(c=> c.Customer)
        .Include(p=>p.Product)
        .OrderByDescending(o=>o.CreatedAt)
        .Take(3)
        .ToList();
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
