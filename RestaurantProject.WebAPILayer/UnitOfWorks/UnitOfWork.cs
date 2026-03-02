using RestaurantProject.WebAPILayer.Context;
using RestaurantProject.WebAPILayer.Entities;
using RestaurantProject.WebAPILayer.Repositories;

namespace RestaurantProject.WebAPILayer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiContext _context;

        public IRepository<Category> Categories { get; private set; }

        public IRepository<Chef> Chefs { get; private set; }

        public IRepository<Contact> Contacts { get; private set; }

        public IRepository<Feature> Features { get; private set; }

        public IRepository<Image> Images { get; private set; }

        public IRepository<Message> Messages { get; private set; }

        public IRepository<Product> Products { get; private set; }

        public IRepository<Reservation> Reservations { get; private set; }

        public IRepository<Service> Services { get; private set; }

        public IRepository<Testimonial> Testimonials { get; private set; }

        public IRepository<Events> Events { get; private set; }

        public UnitOfWork(ApiContext context)
        {
            _context = context;
            Categories = new GenericRepository<Category>(_context);
            Chefs = new GenericRepository<Chef>(_context);
            Contacts = new GenericRepository<Contact>(_context);
            Features = new GenericRepository<Feature>(_context);
            Images = new GenericRepository<Image>(_context);
            Messages = new GenericRepository<Message>(_context);
            Products = new GenericRepository<Product>(_context);
            Reservations = new GenericRepository<Reservation>(_context);
            Services = new GenericRepository<Service>(_context);
            Testimonials = new GenericRepository<Testimonial>(_context);
            Events = new GenericRepository<Events>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
