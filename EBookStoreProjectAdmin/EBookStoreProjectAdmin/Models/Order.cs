namespace EBookStoreProjectAdmin.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string? OwnerId { get; set; }
        public EBookStoreAppUser? Owner { get; set; }
        public IEnumerable <BookInOrder>? BooksInOrders { get; set; }
    }
}
