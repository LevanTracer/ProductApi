namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public float Price { get; set; } = 0;
    }
}
