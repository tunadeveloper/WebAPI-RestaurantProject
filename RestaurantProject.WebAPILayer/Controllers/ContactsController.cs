using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.WebAPILayer.DTOs.ContactDTOs;
using RestaurantProject.WebAPILayer.Entities;
using RestaurantProject.WebAPILayer.UnitOfWorks;
using System.Threading.Tasks;

namespace RestaurantProject.WebAPILayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ContactsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _uow.Contacts.GetAllAsync();
            var mapper = _mapper.Map<List<ResultContactDTO>>(values);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDTO dto)
        {
            var mapper = _mapper.Map<Contact>(dto);
            await _uow.Contacts.AddAsync(mapper);
            await _uow.SaveAsync();
            return Ok("Eklendi!");
        }

        [HttpPut]
        public IActionResult Update(UpdateContactDTO dto)
        {
            var mapper = _mapper.Map<Contact>(dto);
            _uow.Contacts.Update(mapper);
            _uow.SaveAsync();
            return Ok("Güncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _uow.Contacts.GetByIdAsync(id);
            _uow.Contacts.Delete(values);
            await _uow.SaveAsync();
            return Ok("Silindi!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _uow.Contacts.GetByIdAsync(id);
            var mapper = _mapper.Map<List<ResultContactDTO>>(values);
            return Ok(mapper);
        }
    }
}
