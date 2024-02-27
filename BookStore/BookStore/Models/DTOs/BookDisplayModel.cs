namespace BookStore.Models.DTOs
{
    public class BookDisplayModel
    {
        public IEnumerable<Book> Books { get; set; }

        public IEnumerable<Gerne> Gernes  { get; set; }
    }
}
