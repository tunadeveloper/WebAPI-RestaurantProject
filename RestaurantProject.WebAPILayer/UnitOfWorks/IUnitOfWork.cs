using RestaurantProject.WebAPILayer.Entities;
using RestaurantProject.WebAPILayer.Repositories;

namespace RestaurantProject.WebAPILayer.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get; }
        IRepository<Chef> Chefs { get; }
        IRepository<Contact> Contacts { get; }
        IRepository<Feature> Features { get; }
        IRepository<Image> Images { get; }
        IRepository<Message> Messages { get; }
        IRepository<Product> Products { get; }
        IRepository<Reservation> Reservations { get; }
        IRepository<Service> Services { get; }
        IRepository<Testimonial> Testimonials { get; }
        IRepository<Events> Events { get; }

        Task<int> SaveAsync();
    }
}
