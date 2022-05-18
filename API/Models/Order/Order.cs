namespace API.Models.Order
{
    public class Order
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public Guid UserGuid { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Piece { get; set; }
        public Guid OrderId { get; set; }
    }
}
