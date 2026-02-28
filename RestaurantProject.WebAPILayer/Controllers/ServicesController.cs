using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.WebAPILayer.DTOs.ServiceDTOs;
using RestaurantProject.WebAPILayer.Entities;
using RestaurantProject.WebAPILayer.UnitOfWorks;
using System.Threading.Tasks;

namespace RestaurantProject.WebAPILayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ServicesController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _uow.Services.GetAllAsync();
            var mapper = _mapper.Map<List<ResultServiceDTO>>(values);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDTO dto)
        {
            var mapper = _mapper.Map<Service>(dto);
            await _uow.Services.AddAsync(mapper);
            await _uow.SaveAsync();
            return Ok("Eklendi!");
        }

        [HttpPut]
        public IActionResult Update(UpdateServiceDTO dto)
        {
            var mapper = _mapper.Map<Service>(dto);
            _uow.Services.Update(mapper);
            _uow.SaveAsync();
            return Ok("Güncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _uow.Services.GetByIdAsync(id);
            _uow.Services.Delete(values);
            await _uow.SaveAsync();
            return Ok("Silindi!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _uow.Services.GetByIdAsync(id);
            var mapper = _mapper.Map<List<ResultServiceDTO>>(values);
            return Ok(mapper);
        }
    }
}
