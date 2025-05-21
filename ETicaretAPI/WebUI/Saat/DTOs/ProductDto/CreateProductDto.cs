namespace AdminPanel.DTOs.CategoryDto
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public  decimal Price { get; set; }
        public  decimal? DiscountPrice { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
    }
}
