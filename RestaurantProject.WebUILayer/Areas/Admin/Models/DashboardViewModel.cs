namespace RestaurantProject.WebUILayer.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int ReservationsCount { get; set; }
        public int ContactsCount { get; set; }
        public int EventsCount { get; set; }
        public int ProductsCount { get; set; }
        public int CategoriesCount { get; set; }
        public int FeaturesCount { get; set; }
        public int ServicesCount { get; set; }
        public int TestimonialsCount { get; set; }
        public int ChefsCount { get; set; }
        public int MessagesCount { get; set; }
        public int ImagesCount { get; set; }
        public List<DailyReservationCount> Last7DaysReservations { get; set; } = new();
        public List<MonthlyReservationCount> MonthlyReservations { get; set; } = new();
        public List<ReservationStatusCount> ReservationStatusCounts { get; set; } = new();
        public List<CategoryProductCount> CategoryProductCounts { get; set; } = new();
    }

    public class ReservationStatusCount
    {
        public string StatusName { get; set; } = "";
        public int Count { get; set; }
    }

    public class MonthlyReservationCount
    {
        public string MonthLabel { get; set; } = "";
        public int Count { get; set; }
    }

    public class DailyReservationCount
    {
        public string DateLabel { get; set; } = "";
        public int Count { get; set; }
    }

    public class CategoryProductCount
    {
        public string CategoryName { get; set; } = "";
        public int ProductCount { get; set; }
    }
}
