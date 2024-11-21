namespace ExerciceBibliothéque; // Définit un namespace pour organiser les classes du projet
using System;
public class Livre
{
    // Propriétés publiques avec getters et setters automatiques
    public string Titre { get; set; }
    public string Auteur { get; set; }
    public bool Disponible { get; set; }

    // Constructeur de la classe `Livre`
    public Livre(string titre, string auteur, bool disponible)
    {
        Titre = titre; // Initialise la propriété `Titre` avec la valeur passée en paramètre
        Auteur = auteur; // Same pour auteur
        Disponible = disponible; // Same pour disponbile
    }
    
    // Redéfinition de la méthode `ToString` pour afficher les informations du livre sous une forme lisible
    public override string ToString()
    {
        // Renvoie une chaîne formatée contenant les détails du livre
        return $"Titre: {Titre}, Auteur: {Auteur}, Disponible: {(Disponible ? "Oui" : "Non")}";
    }
}