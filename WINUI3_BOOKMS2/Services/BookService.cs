using System.Collections.ObjectModel;
using WINUI3_BOOKMS2.Contracts.Services;
using WINUI3_BOOKMS2.Models;
using Microsoft.UI.Xaml.Controls;
using static System.Reflection.Metadata.BlobBuilder;

namespace WINUI3_BOOKMS2.Services;

public class BookService : IBookService
{
    private ObservableCollection<Book> _allBooks{ get; set; }
    public Book selectedBook { get; set; }
    public BookService()
    {
        _allBooks ??= new ObservableCollection<Book>
            {
                new() { id = 1, name = "红楼梦", author = "曹雪芹", press = "人民文学出版社" },
                new() { id = 2, name = "西游记", author = "昊承恩", press = "中华书局" },
                new() { id = 3, name = "水浒传", author = "施耐庵", press = "人民文学出版社" },
                new() { id = 4, name = "三国演义", author = "罗贯中", press = "中华书局" },
                new() { id = 5, name = "百年孤独", author = "加西亚·马尔克斯", press = "南海出版社" },
                new() { id = 6, name = "追风筝的人", author = "卡勒德·胡赛尼", press = "上海人民出版社" },
                new() { id = 7, name = "小王子", author = "安托万·德·圣-埃克苏佩里", press = "译林出版社" },
                new() { id = 8, name = "1984", author = "乔治·奥威尔", press = "译林出版社" },
                new() { id = 9, name = "简爱", author = "夏洛蒂·勃朗特", press = "人民文学出版社" },
                new() { id = 10, name = "了不起的盖茨比", author = "F.斯科特·菲茨杰拉德", press = "上海译文出版社" },
                new() { id = 11, name = "时间简史", author = "斯蒂芬·威廉·霍金", press = "湖南科学技术出版社" },
                new() { id = 12, name = "思考，快与慢", author = "丹尼尔·卡尼曼", press = "中信出版社" },
                new() { id = 13, name = "活着", author = "余华", press = "作家出版社" },
                new() { id = 14, name = "人类简史", author = "尤瓦尔·赫拉利", press = "中信出版社" },
            };
    }

    public ObservableCollection<Book> GetAllBooks()
    {
        // 下面的代码是从MYSQL获取图书信息
        //_allBooks = new ObservableCollection<Book>();
        //using (var connection = new MySqlConnection(App.ConnectionString))
        //{
        //	connection.Open();
        //	using (var command = new MySqlCommand("SELECT * FROM book", connection))
        //	{
        //		using (var reader = command.ExecuteReader())
        //		{
        //			_allBooks.Clear();
        //			while (reader.Read())
        //			{
        //				_allBooks.Add(new Book
        //				{
        //					id = reader.GetInt32("id"),
        //					name = reader.GetString("name"),
        //					author = reader.GetString("author"),
        //					press = reader.GetString("press")
        //				});
        //			}
        //		}
        //	}
        //}
        return _allBooks;
    }

    public async void UpdateBook(string NameTextBox, string AuthorTextBox, string PressTextBox)
    {
        if (selectedBook == null)
        {
            ContentDialog noChangeDialog = new ContentDialog
            {
                Title = "未选择",
                Content = "请选择一条记录",
                CloseButtonText = "确定",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };

            await noChangeDialog.ShowAsync();
            return;
        }
        // 获取用户输入的新信息
        var newName = string.IsNullOrWhiteSpace(NameTextBox) ? selectedBook.name : NameTextBox;
        var newAuthor = string.IsNullOrWhiteSpace(AuthorTextBox) ? selectedBook.author : AuthorTextBox;
        var newPress = string.IsNullOrWhiteSpace(PressTextBox) ? selectedBook.press : PressTextBox;

        var dialogContent = $"确认更新图书信息：\n\n" +
                            $"旧信息：\n" +
                            $"名称：{selectedBook.name}\n" +
                            $"作者：{selectedBook.author}\n" +
                            $"出版社：{selectedBook.press}\n\n" +
                            $"新信息：\n" +
                            $"名称：{newName}\n" +
                            $"作者：{newAuthor}\n" +
                            $"出版社：{newPress}";

        // 如果未输入任何信息
        if (newName == selectedBook.name &&
            newAuthor == selectedBook.author &&
            newPress == selectedBook.press)
        {
            ContentDialog noChangeDialog = new ContentDialog
            {
                Title = "无更改",
                Content = "未检测到任何更改，请修改至少一个字段。",
                CloseButtonText = "确定",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };

            await noChangeDialog.ShowAsync();
            return;
        }

        ContentDialog dialog = new ContentDialog
        {
            Title = "确认更新",
            Content = dialogContent,
            PrimaryButtonText = "确认",
            CloseButtonText = "取消",
            DefaultButton = ContentDialogButton.Primary,
            XamlRoot = App.MainWindow.Content.XamlRoot
        };

        var result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            //using (var connection = new MySqlConnection(App.ConnectionString))
            //{
            //    connection.Open();
            //    using (var command = new MySqlCommand("UPDATE book SET name=@name, author=@auth, press=@press WHERE id=@id", connection))
            //    {
            //        command.Parameters.AddWithValue("@id", selectedBook.id);
            //        command.Parameters.AddWithValue("@name", name);
            //        command.Parameters.AddWithValue("@auth", author);
            //        command.Parameters.AddWithValue("@press", press);
            //        command.ExecuteNonQuery();
            //    }
            //}
            selectedBook.name = newName;
            selectedBook.author = newAuthor;
            selectedBook.press = newPress;
        }
    }

    public async void deleteBook()
    {
        if (selectedBook != null)
        {
            var dialog = new ContentDialog
            {
                Title = "删除确认",
                Content = $"是否要删除这本书？\n\nID: {selectedBook.id}\n书名: {selectedBook.name}\n作者: {selectedBook.author}\n出版社: {selectedBook.press}",
                PrimaryButtonText = "删除",
                CloseButtonText = "算了",
                DefaultButton = ContentDialogButton.Primary,
                XamlRoot = App.MainWindow.Content.XamlRoot
            };

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                //using (var connection = new MySqlConnection(App.ConnectionString))
                //{
                //    connection.Open();
                //    using (var command = new MySqlCommand("DELETE FROM book WHERE id=@id", connection))
                //    {
                //        command.Parameters.AddWithValue("@id", selectedBook.id);
                //        command.ExecuteNonQuery();
                //    }
                //}
                _allBooks.Remove(selectedBook);
            }
        }
        else
        {
            ContentDialog noSelectionDialog = new ContentDialog
            {
                Title = "删除失败",
                Content = "请选择要删除的图书。",
                CloseButtonText = "确定",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };
            await noSelectionDialog.ShowAsync();
        }
    }

    public ObservableCollection<Book> searchBooks(string SearchTextBox)
    {
        if (SearchTextBox == null)
        {
            return _allBooks;
        }

        // 关键字不区分大小写
        var keyword = SearchTextBox.Trim().ToLower();
        var filteredBooks = new ObservableCollection<Book>();
        foreach (var book in _allBooks)
        {
            if (book.name.ToLower().Contains(keyword) ||
                book.author.ToLower().Contains(keyword) ||
                book.press.ToLower().Contains(keyword))
            {
                filteredBooks.Add(book);
            }
        }
        return filteredBooks;
    }

    public async void addBook(string NameTextBox, string AuthorTextBox, string PressTextBox)
    {
        var name = NameTextBox;
        var author = AuthorTextBox;
        var press = PressTextBox;

        // 检查是否有字段为空
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(press))
        {
            ContentDialog emptyFieldDialog = new ContentDialog
            {
                Title = "输入错误",
                Content = "所有字段均为必填项。",
                CloseButtonText = "确定",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };
            await emptyFieldDialog.ShowAsync();
            return;
        }

        var dialog = new ContentDialog
        {
            Title = "添加确认",
            Content = $"是否要添加这本书\n\n书名: {name}\n作者: {author}\n出版社: {press}",
            PrimaryButtonText = "添加",
            CloseButtonText = "取消",
            DefaultButton = ContentDialogButton.Primary,
            XamlRoot = App.MainWindow.Content.XamlRoot
        };

        var result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            //using (var connection = new MySqlConnection(App.ConnectionString))
            //{
            //    connection.Open();
            //    using (var command = new MySqlCommand("INSERT INTO book (name, author, press) VALUES (@name, @auth, @press)", connection))
            //    {
            //        command.Parameters.AddWithValue("@name", name);
            //        command.Parameters.AddWithValue("@auth", author);
            //        command.Parameters.AddWithValue("@press", press);
            //        command.ExecuteNonQuery();
            //    }
            //}

            {
                int newId = _allBooks.Count + 1;
                Book newBook = new Book { id = newId, name = name, author = author, press = press };
                _allBooks.Add(newBook);
            }

            dialog = new ContentDialog
            {
                Title = "添加成功",
                Content = "添加成功",
                PrimaryButtonText = "确认",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };
            await dialog.ShowAsync();
        }
    }
}
