using Microsoft.UI.Xaml.Controls;

using WINUI3_BOOKMS2.ViewModels;

namespace WINUI3_BOOKMS2.Views;

public sealed partial class AddBookPage : Page
{
    public AddBookViewModel ViewModel
    {
        get;
    }

    public AddBookPage()
    {
        ViewModel = App.GetService<AddBookViewModel>(); 
        InitializeComponent();
    }
}
