namespace UOW.EntityLayer.Entities
{
    public class Product : BaseClass
    {
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        // Relations 
        public virtual Category? Category { get; set; }
    }
}