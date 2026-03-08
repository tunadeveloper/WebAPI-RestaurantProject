using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.WebAPILayer.DTOs.TestimonialDTOs;
using RestaurantProject.WebAPILayer.Entities;
using RestaurantProject.WebAPILayer.UnitOfWorks;
using System.Threading.Tasks;

namespace RestaurantProject.WebAPILayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public TestimonialsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _uow.Testimonials.GetAllAsync();
            var mapper = _mapper.Map<List<ResultTestimonialDTO>>(values);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDTO dto)
        {
            var mapper = _mapper.Map<Testimonial>(dto);
            await _uow.Testimonials.AddAsync(mapper);
            await _uow.SaveAsync();
            return Ok("Eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialDTO dto)
        {
            var mapper = _mapper.Map<Testimonial>(dto);
            _uow.Testimonials.Update(mapper);
            await _uow.SaveAsync();
            return Ok("Güncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _uow.Testimonials.GetByIdAsync(id);
            _uow.Testimonials.Delete(values);
            await _uow.SaveAsync();
            return Ok("Silindi!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _uow.Testimonials.GetByIdAsync(id);
            var mapper = _mapper.Map<ResultTestimonialDTO>(values);
            return Ok(mapper);
        }
    }
}
