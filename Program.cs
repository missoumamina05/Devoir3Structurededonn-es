using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var liste = new DoublyLinkedList();
        bool quitter = false;

        while (!quitter)
        {
            Console.WriteLine("=== Liste doublement chaînée avec suppression paresseuse ===");
            Console.WriteLine("1. Ajouter un élément");
            Console.WriteLine("2. Rechercher un élément");
            Console.WriteLine("3. Supprimer (paresseux)");
            Console.WriteLine("4. Compactage");
            Console.WriteLine("5. Afficher les éléments actifs");
            Console.WriteLine("6. Tester la liste avec sentinelles (BONUS)");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");

            var choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.Write("Valeur à ajouter : ");
                    if (int.TryParse(Console.ReadLine(), out int valAjout))
                        liste.AddLast(valAjout);
                    else
                        Console.WriteLine("Valeur invalide.");
                    break;

                case "2":
                    Console.Write("Valeur à rechercher : ");
                    if (int.TryParse(Console.ReadLine(), out int valRech))
                    {
                        var node = liste.Find(valRech);
                        Console.WriteLine(node != null ? "Trouvé (non supprimé)." : "Non trouvé.");
                    }
                    break;

                case "3":
                    Console.Write("Valeur à supprimer (paresseux) : ");
                    if (int.TryParse(Console.ReadLine(), out int valSup))
                    {
                        bool ok = liste.LazyDelete(valSup);
                        Console.WriteLine(ok ? "Marqué comme supprimé." : "Valeur introuvable.");
                    }
                    break;

                case "4":
                    liste.Compact();
                    Console.WriteLine("Compactage effectué.");
                    break;

                case "5":
                    Console.WriteLine("Éléments actifs :");
                    foreach (var v in liste.ActiveValues())
                        Console.Write(v + " ");
                    Console.WriteLine();
                    break;

                case "6":
                    TesterBonus();
                    break;

                case "0":
                    quitter = true;
                    break;

                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }

            Console.WriteLine();
        }

        Environment.Exit(0);
    }

    private static void TesterBonus()
    {
        Console.WriteLine("\n=== TEST BONUS : Liste avec sentinelles ===");

        var bonusList = new DoublyLinkedListSentinel();

        bonusList.Add(10);
        bonusList.Add(20);
        bonusList.Add(30);

        Console.WriteLine("Valeurs actives (avant suppression) :");
        foreach (var v in bonusList.ActiveValues())
            Console.Write(v + " ");
        Console.WriteLine();

        bonusList.LazyDelete(20);

        Console.WriteLine("Valeurs actives (après suppression paresseuse) :");
        foreach (var v in bonusList.ActiveValues())
            Console.Write(v + " ");
        Console.WriteLine();

        bonusList.Compact();

        Console.WriteLine("Valeurs actives (après compactage) :");
        foreach (var v in bonusList.ActiveValues())
            Console.Write(v + " ");
        Console.WriteLine();
    }
}
