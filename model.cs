namespace EfCoreExample.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // One Model -> Many Cars
        public ICollection<Car> Cars { get; set; }
    }
}
