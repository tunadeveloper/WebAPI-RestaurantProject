using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.WebAPILayer.DTOs.ChefDTOs;
using RestaurantProject.WebAPILayer.Entities;
using RestaurantProject.WebAPILayer.UnitOfWorks;
using System.Threading.Tasks;

namespace RestaurantProject.WebAPILayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChefsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ChefsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _uow.Chefs.GetAllAsync();
            var mapper = _mapper.Map<List<ResultChefDTO>>(values);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChefDTO dto)
        {
            var mapper = _mapper.Map<Chef>(dto);
            await _uow.Chefs.AddAsync(mapper);
            await _uow.SaveAsync();
            return Ok("Eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateChefDTO dto)
        {
            var mapper = _mapper.Map<Chef>(dto);
            _uow.Chefs.Update(mapper);
           await _uow.SaveAsync();
            return Ok("Güncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _uow.Chefs.GetByIdAsync(id);
            _uow.Chefs.Delete(values);
            await _uow.SaveAsync();
            return Ok("Silindi!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _uow.Chefs.GetByIdAsync(id);
            var mapper = _mapper.Map<ResultChefDTO>(values);
            return Ok(mapper);
        }
    }
}
