namespace API.Models.Dto
{
    public class UnitxCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Rate { get; set; } = string.Empty;
        public int Area { get; set; }
        public int Ocupancy { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Amenity { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }   
}
