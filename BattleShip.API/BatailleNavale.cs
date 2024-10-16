using System;
using System.Collections.Generic;
namespace BattleShip.API
{

    public class BatailleNavale
    {
        private const int TAILLE_GRILLE = 10; // Taille de la grille
        private static readonly (char lettre, int taille)[] bateaux = {
        ('A', 4), ('B', 3), ('C', 3), ('D', 2), ('E', 2), ('F', 1)
    };

        // Chaque bateau aura une lettre et une liste de positions au format "a1"
        public List<Dictionary<string, List<string>>> PositionsBateaux { get; private set; }

        public BatailleNavale()
        {
            // Générer les positions des bateaux
            PositionsBateaux = GenererPositionsBateaux();
        }

        private List<Dictionary<string, List<string>>> GenererPositionsBateaux()
        {
            List<Dictionary<string, List<string>>> positions = new List<Dictionary<string, List<string>>>();
            char[,] grilleTemp = new char[TAILLE_GRILLE, TAILLE_GRILLE]; // Grille temporaire pour vérifier les conflits

            foreach (var bateau in bateaux)
            {
                bool bateauPlace = false;

                while (!bateauPlace)
                {
                    bool horizontal = Random.Shared.Next(2) == 0;
                    int ligne = Random.Shared.Next(TAILLE_GRILLE);
                    int colonne = Random.Shared.Next(TAILLE_GRILLE);

                    // Vérification de l'espace libre
                    if (horizontal && colonne + bateau.taille <= TAILLE_GRILLE)
                    {
                        bool espaceLibre = true;
                        for (int i = 0; i < bateau.taille; i++)
                        {
                            if (grilleTemp[ligne, colonne + i] != '\0')
                            {
                                espaceLibre = false;
                                break;
                            }
                        }

                        if (espaceLibre)
                        {
                            List<string> positionsBateau = new List<string>();

                            // Ajout des positions dans la liste et marquage dans la grille temporaire
                            for (int i = 0; i < bateau.taille; i++)
                            {
                                grilleTemp[ligne, colonne + i] = bateau.lettre;
                                // Conversion des coordonnées (x, y) en format "a1", "b7", etc.
                                char coordX = (char)('a' + ligne); // Conversion de l'index de ligne en lettre
                                char coordY = (char)('1' + (colonne + i)); // Conversion de l'index de colonne en chiffre
                                positionsBateau.Add($"{coordX}{coordY}"); // Ajouter la position au format "a1"
                            }

                            // Ajouter le bateau et ses positions au dictionnaire
                            positions.Add(new Dictionary<string, List<string>> { { $"bateau-{bateau.lettre}", positionsBateau } });
                            bateauPlace = true;
                        }
                    }
                    else if (!horizontal && ligne + bateau.taille <= TAILLE_GRILLE)
                    {
                        bool espaceLibre = true;
                        for (int i = 0; i < bateau.taille; i++)
                        {
                            if (grilleTemp[ligne + i, colonne] != '\0')
                            {
                                espaceLibre = false;
                                break;
                            }
                        }

                        if (espaceLibre)
                        {
                            List<string> positionsBateau = new List<string>();

                            // Ajout des positions dans la liste et marquage dans la grille temporaire
                            for (int i = 0; i < bateau.taille; i++)
                            {
                                grilleTemp[ligne + i, colonne] = bateau.lettre;
                                // Conversion des coordonnées (x, y) en format "a1", "b7", etc.
                                char coordX = (char)('a' + (ligne + i)); // Conversion de l'index de ligne en lettre
                                char coordY = (char)('1' + colonne); // Conversion de l'index de colonne en chiffre
                                positionsBateau.Add($"{coordX}{coordY}"); // Ajouter la position au format "a1"
                            }

                            // Ajouter le bateau et ses positions au dictionnaire
                            positions.Add(new Dictionary<string, List<string>> { { $"bateau-{bateau.lettre}", positionsBateau } });
                            bateauPlace = true;
                        }
                    }
                }
            }

            return positions;
        }
    }
}