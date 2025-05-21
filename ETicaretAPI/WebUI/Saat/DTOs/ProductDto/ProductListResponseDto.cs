using AdminPanel.DTOs.CategoryDto;

namespace AdminPanel.DTOs.ProductDto
{
    public class ProductListResponseDto
    {
        public int TotalCount { get; set; }
        public List<ResultProductDto> Products { get; set; }
    }

}
