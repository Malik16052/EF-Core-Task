namespace EfCoreExample.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }
    }
}
