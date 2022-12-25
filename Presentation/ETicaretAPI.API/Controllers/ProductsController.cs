
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {

            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(_productReadRepository.GetAll(false));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
          
           
            return Ok(await _productReadRepository.GetByIdAsync(id,false));

        }

        [HttpPost]

        public async Task<IActionResult> Post(VM_Create_Product model)
        {
           await _productWriteRepository.AddAsync(new() { Name = model.Name,Price=model.Price,Stock=model.Stock});
           await _productWriteRepository.SaveAsync();

            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Stock = model.Stock;
            await _productWriteRepository.SaveAsync();

            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync(); 
            return Ok();
        }
































        //[HttpGet]
        //public async Task Get()
        //{
        //    //await _productWriteRepository.AddAsync(new() { Name = "Hamican", Price = 150, Stock = 25});



        //    // Product product = await  _productReadRepository.GetByIdAsync("7d02b613-42a8-442b-a6ef-642ebfa16346");
        //    //product.Stock = 250;
        //    await _productWriteRepository.SaveAsync();

        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product = await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}
    }
}
