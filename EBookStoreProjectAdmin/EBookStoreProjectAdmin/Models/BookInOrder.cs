namespace EBookStoreProjectAdmin.Models
{
    public class BookInOrder
    {
        public Guid BookId { get; set; }
        public Book? OrderedProduct { get; set; }

        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public int Quantity { get; set; }
    }
}
