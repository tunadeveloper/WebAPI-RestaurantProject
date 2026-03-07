using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.WebAPILayer.DTOs.CategoryDTOs;
using RestaurantProject.WebAPILayer.Entities;
using RestaurantProject.WebAPILayer.UnitOfWorks;

namespace RestaurantProject.WebAPILayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CategoriesController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _uow.Categories.GetAllAsync();
            var mapper = _mapper.Map<List<ResultCategoryDTO>>(values);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO dto)
        {
            var mapper = _mapper.Map<Category>(dto);
            await _uow.Categories.AddAsync(mapper);
            await _uow.SaveAsync();
            return Ok("Eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDTO dto)
        {
            var mapper = _mapper.Map<Category>(dto);
            _uow.Categories.Update(mapper);
            await _uow.SaveAsync();
            return Ok("Güncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _uow.Categories.GetByIdAsync(id);
            _uow.Categories.Delete(values);
            await _uow.SaveAsync();
            return Ok("Silindi!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _uow.Categories.GetByIdAsync(id);
            var mapper = _mapper.Map<List<ResultCategoryDTO>>(values);
            return Ok(mapper);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetCategoryWithProducts(int id)
        {
            var allCategories = await _uow.Categories.GetAllAsync(x => x.Products);
            var values = allCategories.FirstOrDefault(x => x.Id == id);
            var mapper = _mapper.Map<ResultCategoryDTO>(values);
            return Ok(mapper);
        }
    }
}
