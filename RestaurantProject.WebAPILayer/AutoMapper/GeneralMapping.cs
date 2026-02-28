using AutoMapper;
using RestaurantProject.WebAPILayer.DTOs.CategoryDTOs;
using RestaurantProject.WebAPILayer.Entities;

namespace RestaurantProject.WebAPILayer.AutoMapper
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
        }
    }
}
