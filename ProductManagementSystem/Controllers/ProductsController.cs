using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;

using ProductManagementSystem.Services.Interfaces; 

namespace ProductManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

       
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

       
    public async Task<IActionResult> Index(string? searchString)
{
    var products = await _productService.GetAllProductsAsync(searchString);
    ViewData["SearchString"] = searchString;
    return View(products);
}

       
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); 
        }

        
        public IActionResult Create()
        {
            return View(); 
        }

        // POST: /Products/Create (Xử lý thêm mới)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Stock,Description")] Product product)
        {
            if (ModelState.IsValid) // Kiểm tra DataAnnotations
            {
                await _productService.CreateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product); // Nếu lỗi validation, hiển thị lại form
        }

        // GET: /Products/Edit/5 (Form sửa)
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); // Trả về Views/Products/Edit.cshtml
        }

        // POST: /Products/Edit/5 (Xử lý sửa)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Stock,Description")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid) // Kiểm tra DataAnnotations
            {
                try
                {
                    await _productService.UpdateProductAsync(product);
                }
                catch (Exception)
                {
                    if (await _productService.GetProductByIdAsync(id) == null)
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Products/Delete/5 (Form xác nhận xóa)
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); // Trả về Views/Products/Delete.cshtml
        }

        // POST: /Products/Delete/5 (Xử lý xóa)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
