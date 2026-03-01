using RestaurantProject.WebUILayer.DTOs.ProductDTOs;

namespace RestaurantProject.WebUILayer.DTOs.CategoryDTOs
{
    public class ResultCategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<ResultProductDTO> Products { get; set; }
    }
}
