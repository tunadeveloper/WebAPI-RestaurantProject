using AutoMapper;
using RestaurantProject.WebAPILayer.DTOs.CategoryDTOs;
using RestaurantProject.WebAPILayer.DTOs.ChefDTOs;
using RestaurantProject.WebAPILayer.DTOs.ContactDTOs;
using RestaurantProject.WebAPILayer.DTOs.FeatureDTOs;
using RestaurantProject.WebAPILayer.DTOs.ImageDTOs;
using RestaurantProject.WebAPILayer.DTOs.MessageDTOs;
using RestaurantProject.WebAPILayer.DTOs.ProductDTOs;
using RestaurantProject.WebAPILayer.DTOs.ReservationDTOs;
using RestaurantProject.WebAPILayer.DTOs.ServiceDTOs;
using RestaurantProject.WebAPILayer.DTOs.TestimonialDTOs;
using RestaurantProject.WebAPILayer.Entities;

namespace RestaurantProject.WebAPILayer.AutoMapper
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Chef, CreateChefDTO>().ReverseMap();
            CreateMap<Chef, ResultChefDTO>().ReverseMap();
            CreateMap<Chef, UpdateChefDTO>().ReverseMap();

            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();

            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();

            CreateMap<Image, CreateImageDTO>().ReverseMap();
            CreateMap<Image, ResultImageDTO>().ReverseMap();
            CreateMap<Image, UpdateImageDTO>().ReverseMap();

            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, ResultMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<Reservation, CreateReservationDTO>().ReverseMap();
            CreateMap<Reservation, ResultReservationDTO>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDTO>().ReverseMap();

            CreateMap<Service, CreateServiceDTO>().ReverseMap();
            CreateMap<Service, ResultServiceDTO>().ReverseMap();
            CreateMap<Service, UpdateServiceDTO>().ReverseMap();

            CreateMap<Testimonial, CreateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();
        }
    }
}
