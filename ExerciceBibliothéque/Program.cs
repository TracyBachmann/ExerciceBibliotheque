using System;
using System.Collections.Generic;
using ExerciceBibliothéque; // Importation de l'espace de noms contenant la classe `Livre`

class Program
{
    static void Main(string[] args)
    {
        // Liste pour stocker les livres dans la bibliothèque
        List<Livre> bibliotheque = new List<Livre>();
        bool continuer = true; // Booléen pour contrôler la boucle principale du programme
    
        // Boucle principale pour afficher un menu et exécuter des actions
        while (continuer)
        {
            Console.WriteLine("\nMenu :");
            Console.WriteLine("1. Ajouter un livre");
            Console.WriteLine("2. Lister tous les livres");
            Console.WriteLine("3. Rechercher un livre par titre");
            Console.WriteLine("4. Quitter");
            Console.Write("Votre choix ? :3 ");

            string choix = Console.ReadLine(); // Lecture de l'entrée utilisateur
            
            // Gestion des choix utilisateur via un switch
            switch (choix)
            {
                case "1":
                    AjouterLivre(bibliotheque); // Appelle la méthode pour ajouter un livre
                    break;
                case "2":
                    ListerLivres(bibliotheque); // Appelle la méthode pour lister tous les livres
                    break;
                    break;
                case "3":
                    RechercherLivre(bibliotheque); // Appelle la méthode pour rechercher un livre par titre
                    break;
                case "4":
                    continuer = false; // Met fin à la boucle pour quitter le programme
                    Console.WriteLine("Au revoir ! :<");
                    break;
                default:
                    Console.WriteLine("Ce n'est pas un choix valide, envoi au goulag initialisé.");
                    break;
            }
        }
    }
    
    static void AjouterLivre(List<Livre> bibliotheque)
    {
        Console.Write("Titre du livre : ");
        string titre = Console.ReadLine(); // Lecture du titre du livre

        Console.Write("Auteur du livre : ");
        string auteur = Console.ReadLine(); // Lecture de l'auteur

        Console.Write("Le livre est-il disponible ? (oui/non) : ");
        string disponibleStr = Console.ReadLine(); // Lecture de la disponibilité
        bool disponible = disponibleStr.Trim().ToLower() == "oui";

        // Création d'un nouvel objet `Livre` et ajout à la liste
        Livre livre = new Livre(titre, auteur, disponible);
        bibliotheque.Add(livre);

        Console.WriteLine("Livre ajouté avec succès ! o/");
    }

    static void ListerLivres(List<Livre> bibliotheque)
    {
        if (bibliotheque.Count == 0) // Vérifie si la bibliothèque est vide :c
        {
            Console.WriteLine("Aucun livre dans la bibliothèque. :c");
            return;
        }

        Console.WriteLine("\nListe des livres :");
        foreach (var livre in bibliotheque) // Parcourt la liste des livres
        {
            Console.WriteLine(livre.ToString()); // Affiche chaque livre (en utilisant la méthode `ToString` de `Livre`)
        }
    }

    static void RechercherLivre(List<Livre> bibliotheque)
    {
        Console.Write("Entrez le titre du livre à rechercher : ");
        string titreRecherche = Console.ReadLine(); // Lecture du titre à rechercher

        // Recherche des livres contenant le texte saisi (insensible à la casse)
        var livresTrouves = bibliotheque.FindAll(l => l.Titre.Contains(titreRecherche, StringComparison.OrdinalIgnoreCase));

        if (livresTrouves.Count == 0) // Si aucun livre n'est trouvé
        {
            Console.WriteLine("Aucun livre trouvé avec ce titre. :c");
        }
        else
        {
            Console.WriteLine("Livres trouvés :");
            foreach (var livre in livresTrouves) // Affiche tous les livres trouvés
            {
                Console.WriteLine(livre.ToString());
            }
        }
    }
}