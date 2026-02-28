using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.WebAPILayer.DTOs.ProductDTOs;
using RestaurantProject.WebAPILayer.Entities;
using RestaurantProject.WebAPILayer.UnitOfWorks;
using System.Threading.Tasks;

namespace RestaurantProject.WebAPILayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProductsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _uow.Products.GetAllAsync();
            var mapper = _mapper.Map<List<ResultProductDTO>>(values);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO dto)
        {
            var mapper = _mapper.Map<Product>(dto);
            await _uow.Products.AddAsync(mapper);
            await _uow.SaveAsync();
            return Ok("Eklendi!");
        }

        [HttpPut]
        public IActionResult Update(UpdateProductDTO dto)
        {
            var mapper = _mapper.Map<Product>(dto);
            _uow.Products.Update(mapper);
            _uow.SaveAsync();
            return Ok("Güncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _uow.Products.GetByIdAsync(id);
            _uow.Products.Delete(values);
            await _uow.SaveAsync();
            return Ok("Silindi!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _uow.Products.GetByIdAsync(id);
            var mapper = _mapper.Map<List<ResultProductDTO>>(values);
            return Ok(mapper);
        }
    }
}
