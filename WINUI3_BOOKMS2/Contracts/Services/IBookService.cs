using System.Collections.ObjectModel;
using WINUI3_BOOKMS2.Models;

namespace WINUI3_BOOKMS2.Contracts.Services;

public interface IBookService
{
    public Book selectedBook { get; set; }
    public ObservableCollection<Book> GetAllBooks();
    void UpdateBook(string NameTextBox, string AuthorTextBox, string PressTextBox);
    void deleteBook();
    void addBook(string NameTextBox, string AuthorTextBox, string PressTextBox);
    ObservableCollection<Book> searchBooks(string SearchTextBox);
}
