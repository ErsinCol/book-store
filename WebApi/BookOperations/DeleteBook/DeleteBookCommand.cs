using WebApi.DbOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.Find(BookId) ?? throw new InvalidOperationException("Silinmek istenen kitap bulunamadı.");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }

}