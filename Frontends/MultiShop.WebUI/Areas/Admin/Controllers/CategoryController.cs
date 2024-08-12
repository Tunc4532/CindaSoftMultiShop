using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CategoryViewBagList();
            ViewBag.link3 = "Kategori Listesi";
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }

        [Route("CreateCategory")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            CategoryViewBagList();
            ViewBag.link3 = "Kategori Girişi";
            return View();
        }

        [Route("CreateCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [Route("RemoveCategory/{id}")]
        public async Task<IActionResult> RemoveCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryViewBagList();
            ViewBag.link3 = "Category Güncelle";
            var values = await _categoryService.GetByIdCategoryAsync(id);
            return View(values);
        }

        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            //istenilen halde buradan gerekli konfigürasyon ayarlamaları yapılabilir yada validation ile daha kullanışlı işlemler yapılabilir
            //if (updateCategoryDto is null)
            //{
            //    return BadRequest("Güncellenecek kategori bilgileri eksik veya hatalı.");
            //}
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        //linkleri tekrar yazmak yerine aynı olan yerleri method halinde çağırıyouz
        void CategoryViewBagList()
        {
            ViewBag.link1 = "Kategori Listesi";
            ViewBag.link2 = "Kategori İşlemleri";
            ViewBag.link4 = "Kategori İşlemleri";
        }
    }
}
