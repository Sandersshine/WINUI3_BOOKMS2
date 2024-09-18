using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Controls;

using WINUI3_BOOKMS2.ViewModels;

namespace WINUI3_BOOKMS2.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class BookListPage : Page
{
    public BookListViewModel ViewModel
    {
        get; 
    }

    public BookListPage()
    {
        ViewModel = App.GetService<BookListViewModel>();
        InitializeComponent(); 
    }
}
