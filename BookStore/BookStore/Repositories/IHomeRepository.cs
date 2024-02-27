namespace BookStore.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Book>> GetBooks(string sTerm = "", int gerneId = 0);
        Task<IEnumerable<Gerne>> Gernes();
    }
}