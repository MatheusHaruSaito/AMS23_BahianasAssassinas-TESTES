using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AMS23_Carousel.Models;
using AMS23_Carousel.Data;
using AMS23_Carousel.Models.Category;


namespace AMS23_Carousel.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    public readonly ICategoryRepository _categoryRepository;

    public CategoryController(ILogger<CategoryController> logger, ICategoryRepository categoryRepository)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
    }
    public IActionResult AddCat(CategoryModel category)
    {
        _categoryRepository.Add(category);
        _categoryRepository.SaveChangesAsync();
        return RedirectToAction("Index",category);
    }
    public IActionResult Add()
    {
        return View();
    }

 
    public async Task<IActionResult> Index()
    {
        return View(await _categoryRepository.GetAll());
    }
   
    public async Task<IActionResult> Delete(Guid Id)
    {
        return View( await _categoryRepository.GetById(Id));
    }

        public IActionResult DeleteCat(CategoryModel category)
    {
        _categoryRepository.Delete(category);
        _categoryRepository.SaveChangesAsync();
       
        return RedirectToAction("Index",category);
    }

    public async Task<IActionResult> Edit(Guid Id)
    {
        return View(await _categoryRepository.GetById(Id));
    }

    public IActionResult EditCat(CategoryModel category)
    {
        _categoryRepository.Update(category);
        _categoryRepository.SaveChangesAsync();
        return RedirectToAction("Index",category);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
