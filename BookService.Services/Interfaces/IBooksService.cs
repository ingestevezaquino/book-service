using BookService.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Services.Interfaces
{
    public interface IBooksService
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> GetBookByNameAsync(string name);
        Task<List<Book>> GetBooksByAuthorIdAsync(int authorId);
        Task<List<Book>> GetAllBooksAsync();
        Task<bool> DeleteBookById(int id);
    }
}
