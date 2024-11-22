using System;
using System.Collections.Generic;
using ExerciceBibliothéque;

class Program
{
    static void Main(string[] args)
    {
        // List to store books in the library
        List<Book> library = new List<Book>();

        // List to store users of the library
        List<User> users = new List<User>();

        bool proceed = true; // Boolean to control the main program loop

        // Main loop to display a menu and execute actions
        while (proceed)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. List all books");
            Console.WriteLine("3. Search for a book by title");
            Console.WriteLine("4. Create a user");
            Console.WriteLine("5. Borrow a book");
            Console.WriteLine("6. Quit");
            Console.Write("Your choice? :3 ");

            string choix = Console.ReadLine()?.Trim(); // Read user input

            // Manage user choices via a switch statement
            switch (choix)
            {
                case "1":
                    AddBook(library); // Call method to add a book
                    break;
                case "2":
                    ListBook(library); // Call method to list all books
                    break;
                case "3":
                    SearchBook(library); // Call method to search for a book by title
                    break;
                case "4":
                    CreateUser(users); // Call method to create a user
                    break;
                case "5":
                    BorrowBook(users, library); // Call method to borrow a book
                    break;
                case "6":
                    proceed = false; // Exit the program loop
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice ! è-é Please try again."); // Handle invalid menu input
                    break;
            }
        }
    }

    // Method to add a new book to the library
    static void AddBook(List<Book> library)
    {
        Console.Write("Book title: ");
        string title = Console.ReadLine()?.Trim(); // Read the book title

        Console.Write("Book author: ");
        string author = Console.ReadLine()?.Trim(); // Read the book author

        Console.Write("Is the book available? (yes/no): ");
        string availabilityStr = Console.ReadLine()?.Trim().ToLower(); // Read book availability
        bool availability = availabilityStr == "yes";

        // Validate that title and author are not empty
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
        {
            Console.WriteLine("The title and author cannot be empty :c");
            return;
        }

        // Create a new book object and add it to the library
        Book book = new Book(title, author, availability);
        library.Add(book);

        Console.WriteLine("Book successfully added! o/");
    }

    // Method to list all books in the library
    static void ListBook(List<Book> library)
    {
        // Check if the library is empty
        if (library.Count == 0)
        {
            Console.WriteLine("No books in the library :c");
            return;
        }

        // Display each book in the library
        Console.WriteLine("\nList of books:");
        foreach (var book in library)
        {
            Console.WriteLine(book.ToString());
        }
    }

    // Method to search for a book by title
    static void SearchBook(List<Book> library)
    {
        Console.Write("Enter the title of the book to search for: ");
        string titleSearch = Console.ReadLine()?.Trim(); // Read the book title to search for

        // Validate that the title is not empty
        if (string.IsNullOrEmpty(titleSearch))
        {
            Console.WriteLine("The title cannot be empty :c");
            return;
        }

        // Find all books that match the search query (case insensitive)
        var foundBooks = library.FindAll(l => l.Title.Contains(titleSearch, StringComparison.OrdinalIgnoreCase));

        // Display the search results
        if (foundBooks.Count == 0)
        {
            Console.WriteLine("No books found with that title :<");
        }
        else
        {
            Console.WriteLine("Books found:");
            foreach (var book in foundBooks)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }

    // Method to create a new user
    static void CreateUser(List<User> users)
    {
        Console.Write("User's name: ");
        string name = Console.ReadLine()?.Trim(); // Read the user's name

        Console.Write("User's email: ");
        string email = Console.ReadLine()?.Trim(); // Read the user's email

        // Validate that name and email are not empty
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
        {
            Console.WriteLine("The name and email cannot be empty :/");
            return;
        }

        // Create a new user object and add it to the user list
        User user = new User(name, email);
        users.Add(user);

        Console.WriteLine($"User {name} successfully created o/");
    }

    // Method to borrow a book
    static void BorrowBook(List<User> users, List<Book> library)
    {
        Console.Write("Enter the user's name: ");
        string nameUser = Console.ReadLine()?.Trim(); // Read the user's name

        // Find the user in the user list
        User user = users.Find(u => u.Name.Equals(nameUser, StringComparison.OrdinalIgnoreCase));
        if (user == null)
        {
            Console.WriteLine("User not found :c");
            return;
        }

        Console.Write("Enter the title of the book to borrow: ");
        string bookTitle = Console.ReadLine()?.Trim(); // Read the book title to borrow

        // Find the book in the library
        Book book = library.Find(l => l.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        if (book == null)
        {
            Console.WriteLine("Book not found :c");
            return;
        }

        // Attempt to borrow the book
        user.BorrowBook(book);
    }
}