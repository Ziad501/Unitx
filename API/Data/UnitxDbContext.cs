using API.Models.Dto;

namespace API.Data
{
    public static class UnitxDbContext 
    {
        public static List<UnitxDto> unitsList = [
            new() { Id = 1, Name = "Ziad", Ocupancy=3, Area= 120 },
            new() { Id = 2, Name = "Amr" , Ocupancy=4, Area= 130},
            new() {Id = 3, Name = "Nour", Ocupancy = 5, Area = 140}
        ];
        
    }
}
