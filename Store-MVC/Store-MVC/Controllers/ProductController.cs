using Microsoft.AspNetCore.Mvc;
using Store_MVC.Models.Product;

namespace Store_MVC.Controllers;

public class ProductController : Controller
{
    public static List<ProductViewModel> Products { get; set; } = new();

    // GET: ProductController
    public ActionResult Index() => View(Products);

    // GET: ProductController/Details/5
    public ActionResult Details(int id)
    {
        var product = Products.First(p => p.Id == id);

        return View(product);
    }

    // GET: ProductController/Create
    public ActionResult Create() => View();

    // POST: ProductController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ProductViewModel product)
    {
        if (ModelState.IsValid)
        {
            Products.Add(product);

            return RedirectToAction("Details", new
            {
                id = product.Id
            });
        }

        return View(product);
    }

    // GET: ProductController/Edit/5
    public ActionResult Edit(int id)
    {
        var product = Products.First(p => p.Id == id);

        return View();
    }

    // POST: ProductController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([FromQuery] int id, [FromBody] ProductViewModel product)
    {
        var orgProduct = Products.First(p => p.Id == id);
        orgProduct.Id = product.Id;
        orgProduct.Name = product.Name;
        orgProduct.Description = product.Description;
        orgProduct.Price = product.Price;

        return RedirectToAction("Details", new
        {
            id
        });
    }


    // GET: ProductController/Delete/5
    public ActionResult Delete(int id) => View();

    // POST: ProductController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}