namespace CodeFirstApproch.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Manufacture { get; set; }
        public decimal Price { get; set; }
        public decimal DateOfExpire { get; set; }
        public decimal DateofMake { get; set; }
    }
}
