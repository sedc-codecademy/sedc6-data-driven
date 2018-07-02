namespace DapperDemo.Entities
{
    public class ProductFull
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
    }
}
