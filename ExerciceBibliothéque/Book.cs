namespace ExerciceBibliothéque; // Defines a namespace to organize project classes
using System;

public class Book
{
    // Public properties with automatic getters and setters
    public string Title { get; set; } // Stores the title of the book
    public string Author { get; set; } // Stores the author's name
    public bool Availability { get; set; } // Indicates if the book is available (true) or not (false)

    // Constructor for the `Livre` class
    public Book(string title, string author, bool availability)
    {
        Title = title; // Initializes the `Titre` property with the given value
        Author = author; // Initializes the `Auteur` property with the given value
        Availability = availability; // Initializes the `Disponible` property with the given value
    }

    // Overrides the `ToString` method to display book information in a readable format
    public override string ToString()
    {
        // Returns a formatted string with the book's details
        return $"Title: {Title}, Author: {Author}, Availability: {(Availability ? "Yes" : "No")}";
    }
}