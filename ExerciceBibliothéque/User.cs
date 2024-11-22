namespace ExerciceBibliothéque; // Defines a namespace to organize project classes

public class User
{
    // Public properties with automatic getters and setters
    public string Name { get; set; } // Stores the user's name
    public string Email { get; set; } // Stores the user's email address
    public List<Book> BorrowedBooks { get; private set; } // List of books borrowed by the user

    // Constructor for the `Utilisateur` class
    public User(string name, string email)
    {
        Name = name; // Initializes the `Nom` property with the given value
        Email = email; // Initializes the `Email` property with the given value
        BorrowedBooks = new List<Book>(); // Initializes the list of borrowed books as empty
    }

    // Overrides the `ToString` method to display user information in a readable format
    public override string ToString()
    {
        // Generates a string listing borrowed books if any, otherwise displays "No books borrowed"
        string borrowed = BorrowedBooks.Count > 0
            ? string.Join(", ", BorrowedBooks.Select(l => l.Title)) // Join book titles with commas
            : "No books borrowed.";
        
        // Returns a formatted string with the user's name, email, and borrowed books
        return $"Name: {Name}, Email: {Email}, Borrowed Books: {borrowed}";
    }
    
    // Method to borrow a book
    public bool BorrowBook(Book book)
    {
        // Check if the user has already borrowed 3 books
        if (BorrowedBooks.Count >= 3)
        {
            Console.WriteLine($"{Name} has already borrowed 3 books, cannot borrow more :c");
            return false;
        }

        // Check if the book is available
        if (!book.Availability)
        {
            Console.WriteLine($"The book \"{book.Title}\" is not available :c");
            return false;
        }

        // Add the book to the list of borrowed books and mark it as unavailable
        BorrowedBooks.Add(book);
        book.Availability = false;

        Console.WriteLine($"{Name} has borrowed \"{book.Title}\".");
        return true;
    }
}

