namespace MotorcycleCrudApi.Motorcycles.Dto
{
    public class UpdateMotorcycleRequest
    {
        public double? Price { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public DateTime? DateOfFabrication { get; set; }
    }
}
