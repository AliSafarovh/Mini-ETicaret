using Newtonsoft.Json;

namespace AdminPanel.DTOs.CategoryDto
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        [JsonProperty("Name")] 
        public string ProductName { get; set; }
        
    }
}
