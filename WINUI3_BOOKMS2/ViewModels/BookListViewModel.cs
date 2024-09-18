using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Controls;
using WINUI3_BOOKMS2.Contracts.ViewModels;
//using WINUI3_BOOKMS2.Core.Contracts.Services;
using WINUI3_BOOKMS2.Models;
using WINUI3_BOOKMS2.Services;
using WINUI3_BOOKMS2.Contracts.Services;
using static System.Reflection.Metadata.BlobBuilder;

namespace WINUI3_BOOKMS2.ViewModels;

public partial class BookListViewModel : ObservableRecipient, INavigationAware
{
    
    public readonly IBookService _bookService;
    public ICommand UpdateBookCommand { get; }
    public ICommand DeleteBookCommand { get; }
    public ICommand SearchBookCommand { get; }
    private ObservableCollection<Book>? _books;
    public ObservableCollection<Book>? books 
    {
        get => _books;
        // 指向地址改变时通知
        set
        {
            if (_books != value)
            {
                _books = value;
                OnPropertyChanged();
            }
        }
    }

    private string? _NameTextBox;
    public string NameTextBox
    {
        get => _NameTextBox;
        set
        {
            if (_NameTextBox != value)
            {
                _NameTextBox = value;
                OnPropertyChanged(nameof(NameTextBox));
            }
        }
    }

    private string? _AuthorTextBox;
    public string AuthorTextBox
    {
        get => _AuthorTextBox;
        set
        {
            if (_AuthorTextBox != value)
            {
                _AuthorTextBox = value;
                OnPropertyChanged(nameof(AuthorTextBox));
            }
        }
    }

    private string? _PressTextBox;
    public string PressTextBox
    {
        get => _PressTextBox;
        set
        {
            if (_PressTextBox != value)
            {
                _PressTextBox = value;
                OnPropertyChanged(nameof(PressTextBox));
            }
        }
    }

    private string? _SearchTextBox;
    public string SearchTextBox
    {
        get => _SearchTextBox;
        set
        {
            if (_SearchTextBox != value)
            {
                _SearchTextBox = value;
                OnPropertyChanged(nameof(SearchTextBox));
            }
        }
    }

    public BookListViewModel(IBookService bookService)
    {
        books = new ObservableCollection<Book>();
        _bookService = bookService;
        UpdateBookCommand = new RelayCommand(ExecuteUpdateBook);
        DeleteBookCommand = new RelayCommand(ExecuteDeleteBook);
        SearchBookCommand = new RelayCommand(ExecuteSearchBook);
    }

    private void ExecuteSearchBook()
    {
        books = new ObservableCollection<Book>();
        books = _bookService.searchBooks(SearchTextBox);
    }

    private void ExecuteUpdateBook()
    {
        _bookService.UpdateBook(NameTextBox, AuthorTextBox, PressTextBox);
        ClearInputFields();
    }
    private void ClearInputFields()
    {
        NameTextBox = string.Empty;
        AuthorTextBox = string.Empty;
        PressTextBox = string.Empty;
    }
    private void ExecuteDeleteBook()
    {
        _bookService.deleteBook();
    }

    public void OnNavigatedTo(object parameter)
    {
        books = _bookService.GetAllBooks(); 
        //books.Clear();

        //// TODO: Replace with real data.
        //var data = await _bookService.GetGridDataAsync();

        //foreach (var item in data)
        //{
        //    books.Add(item);
        //}
    }

    public void OnNavigatedFrom()
    {
    }
}
