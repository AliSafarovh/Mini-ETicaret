namespace AdminPanel.DTOs.CategoryDto
{
    public class UpdateProductImageDto
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public bool IsHover { get; set; }
    }
}
