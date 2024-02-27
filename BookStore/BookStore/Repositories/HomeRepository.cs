

using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class HomeRepository:IHomeRepository
    {
        private readonly ApplicationDbContext _db;
        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Gerne>> Gernes()
        {
            return await _db.Gernes.ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetBooks(string sTerm="",int gerneId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Book> books = await (from book in _db.Books
                         join gerne in _db.Gernes
                         on book.GerneId equals gerne.Id
                        where string.IsNullOrWhiteSpace(sTerm) || (book!= null && book.BookName.ToLower().StartsWith(sTerm))

                         select new Book
                         {
                             Id = book.Id,
                             Image = book.Image,
                             AuthorName = book.AuthorName,
                             BookName = book.BookName,
                             GerneId = book.GerneId,
                             Price = book.Price,
                             GerneName = gerne.GerneName
                         }
                         ).ToListAsync();
            if(gerneId > 0)
            {
                books = books.Where(a => a.GerneId == gerneId).ToList();
            }
            return books;
        }
    }
}
