namespace WebApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
    }
}
