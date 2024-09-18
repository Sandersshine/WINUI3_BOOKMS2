using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WINUI3_BOOKMS2.Contracts.Services;
using WINUI3_BOOKMS2.Services;
using WinUIEx.Messaging;

namespace WINUI3_BOOKMS2.ViewModels;

public partial class AddBookViewModel : ObservableRecipient
{
    public readonly IBookService _bookService;
    public ICommand AddBookCommand { get; }
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

    public AddBookViewModel(IBookService bookService)
    {
        _bookService = bookService;
        AddBookCommand = new RelayCommand(ExecuteAddBook);
    }

    private void ExecuteAddBook()
    {
        _bookService.addBook(NameTextBox, AuthorTextBox, PressTextBox);
    }
}
