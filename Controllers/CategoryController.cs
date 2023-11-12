using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AMS23_Carousel.Models;
using AMS23_Carousel.Data;
using AMS23_Carousel.Data.Repository;
using AMS23_Carousel.Models.Interfaces;

namespace AMS23_Carousel.Controllers;

[Controller]
[Route("[controller]/[action]")]

public class CategoryController : Controller
{
    private readonly ApplicationDataContext _applicatioDataContext;
    private readonly ILogger<CategoryController> _logger;
    public readonly IRepositoryBase<CategoryModel, Guid> _repositoryBase;

    public CategoryController(ILogger<CategoryController> logger, ApplicationDataContext dataContext ,IRepositoryBase<CategoryModel, Guid> repositoryBase)
    {
        _logger = logger;
        _applicatioDataContext = dataContext;
        _repositoryBase = repositoryBase;
    }


    [HttpPost]

    public IActionResult AddCategory(CategoryModel category)
    {
        _repositoryBase.Add(category);
        _repositoryBase.SaveChangesAsync();
        return RedirectToAction("Index", category);
        
    }


    public IActionResult Add()
    {
        return View();
    }
 

    public IActionResult Index()
    {
        IEnumerable<CategoryModel> category = _repositoryBase.GetAll();
        return View("Index",category);
    }
  

    public IActionResult Delete(Guid Id)
    {
        CategoryModel category = _applicatioDataContext.Category.Where(c => c.Id == Id).FirstOrDefault();
        return View(category);
    }

    public IActionResult DelCat(Guid Id)
    {
        var category = _applicatioDataContext.Category.Where(c => c.Id ==Id).FirstOrDefault();
        _applicatioDataContext.Category.Remove(category);
        _repositoryBase.SaveChangesAsync();
        return RedirectToAction("Index",category);
    }


    public IActionResult CatEdit(CategoryModel category)
    {
        var category2 = _applicatioDataContext.Category.Where(c => c.Id == category.Id).FirstOrDefault();
            if(category is null)
            {
                return BadRequest("category é null");
            }
            else if(category2 is null)
            {
                    return BadRequest("category2 é null");
                
            }
            else{
            category2.Name = category.Name;
            category2.Description = category.Description;
            category2.IsActive = category.IsActive;
        _repositoryBase.SaveChangesAsync();
        return RedirectToAction("Index",category);
            }
    }


    public IActionResult Edit(Guid Id)
    {
        CategoryModel category = _applicatioDataContext.Category.Where(c => c.Id == Id).FirstOrDefault();
        return View(category);
        
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
