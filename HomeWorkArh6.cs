using bookmanager;
using bookrepository;
using domainbook;

namespace HomeWorkArh6 {

    internal static class Program
    {

    private static Business? bookService;

    static void Main(String[] args)
    {
        BookRepository bookRepository = new BookRepository();
        bookService = new Business(bookRepository);

        while (true)
        {
            Console.WriteLine("1 - добавить книгу");
            Console.WriteLine("2 - удалить книгу");
            Console.WriteLine("3 - показать все книги");
            Console.WriteLine("4 - выйти из программы");
            Console.Write("Выберите раздел меню: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    addBook();
                    break;
                case 2:
                    removeBook();
                    break;
                case 3:
                    showAllBooks();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Выбран несуществующий пунк меню");
                    break;
            }
        }
    }

    private static void addBook()
    {
        String title = ""; String author = ""; double price = 0;
        askforBook(ref title, ref author, ref price);

        bookService.addBook(title, author, price);

        Console.WriteLine("Книга добавлена в базу данных");
    }

    private static void removeBook()
    {
        String title = ""; String author = ""; double price = 0;
        askforBook(ref title, ref author, ref price);

        bookService.removeBook(title, author, price);

        Console.WriteLine("Книга удалена из базы данных");
    }

    private static void askforBook(ref String title, ref String author, ref double price)
    {
        Console.Write("Введите название книжки: ");
        title = Convert.ToString(Console.ReadLine());

        Console.Write("Введите автора: ");
        author = Convert.ToString(Console.ReadLine());

        Console.Write("Введите цену: ");
        price = Convert.ToDouble(Console.ReadLine());
    }

        private static void showAllBooks()
    {
        List<Book> books = bookService.getAllBooks();

        if (books.Count == 0)
        {
            Console.WriteLine("Книги не найдены");
        }
        else
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.getTitle() + " автора " + book.getAuthor() + " - цена: " + book.getPrice());
                Console.WriteLine("");
            }
        }
    }
}
}