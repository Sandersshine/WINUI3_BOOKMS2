using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WINUI3_BOOKMS2.Models;
public class Book : INotifyPropertyChanged
{
    public int id
    {
        get; set;
    }

    private string _name;
    public string name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }

    private string _author;
    public string author
    {
        get => _author;
        set
        {
            if (_author != value)
            {
                _author = value;
                OnPropertyChanged();
            }
        }
    }

    private string _press;
    public string press
    {
        get => _press;
        set
        {
            if (_press != value)
            {
                _press = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
