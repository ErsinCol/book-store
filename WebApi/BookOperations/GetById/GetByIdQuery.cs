using System.Data;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetById
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int Id { get; set; }

        public GetByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookViewModel Handle()
        {  
            var book = _dbContext.Books.Find(Id);
            if(book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            BookViewModel vm = new BookViewModel(){
                Title = book.Title,
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                Genre = ((GenreEnum)book.GenreId).ToString(),
            };
            return vm;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}