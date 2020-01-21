namespace DreamsBytes.Core.Entites
{
    public class OrderItem : BaseEntity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public string Name { get; set; }
    }
}
