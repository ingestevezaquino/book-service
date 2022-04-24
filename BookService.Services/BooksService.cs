using BookService.Persistence;
using BookService.Persistence.Models;
using BookService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Services
{
    public class BooksService : IBooksService
    {
        private readonly BooksDBContext _context;
        private readonly ILogger _logger;

        public BooksService(BooksDBContext context, ILogger<BooksDBContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> DeleteBookById(int id)
        {
            Book book = await _context.Books.Where(b => b.Id.Equals(id)).FirstOrDefaultAsync();
            if (book == null)
            {
                _logger.LogWarning($"Unable to find a book with ---> Id = {id} ...");
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Book was removed successfully!");
            return true;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.Where(b => b.Id.Equals(id))
                .Include(b => b.Author)
                .Include(b => b.Rating)
                .FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookByNameAsync(string name)
        {
            return await _context.Books.Where(b => b.Name.ToUpper() == name.ToUpper()).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await _context.Books.Where(b => b.Id.Equals(authorId)).ToListAsync();
        }
    }
}
