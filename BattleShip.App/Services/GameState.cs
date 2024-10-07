namespace BattleShip.App.Services;

public class GameState
{
    // Singleton Instance
    private static GameState _instance = null;
    private static readonly object _lock = new object();

    // Grille du joueur (char[,])
    public char[,] PlayerGrid { get; private set; }

    // Grille de l'adversaire (bool?[,])
    public bool?[,] OpponentGrid { get; private set; }

    // Taille des grilles (par exemple 10x10 pour un jeu classique)
    private const int gridSize = 10;

    // Constructeur privé pour empêcher l'instanciation
    public GameState()
    {
        // Initialisation des grilles
        PlayerGrid = new char[gridSize, gridSize];
        OpponentGrid = new bool?[gridSize, gridSize];

        // Optionnel: Initialiser la grille du joueur avec des bateaux (exemple)
        InitializePlayerGrid();
    }

    // Méthode pour récupérer l'instance unique
    public static GameState Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new GameState();
                }
                return _instance;
            }
        }
    }

    // Initialisation de la grille du joueur avec des bateaux
    private void InitializePlayerGrid()
    {
        // Exemple d'initialisation : placer des bateaux (indiqués par 'B')
        PlayerGrid[0, 0] = 'B'; // Placer un bateau sur la case (0,0)
        PlayerGrid[1, 1] = 'B'; // Placer un autre bateau sur la case (1,1)
                                // etc.
    }

    // Mettre à jour la grille de l'adversaire après un tir
    public void UpdateOpponentGrid(int x, int y, bool hit)
    {
        if (x >= 0 && x < gridSize && y >= 0 && y < gridSize)
        {
            OpponentGrid[x, y] = hit;
        }
    }

    // Vérifier l'état d'une case dans la grille de l'adversaire
    public string GetOpponentGridStatus(int x, int y)
    {
        if (x < 0 || x >= gridSize || y < 0 || y >= gridSize)
        {
            return "Invalid position";
        }

        bool? status = OpponentGrid[x, y];
        if (status == null)
        {
            return "Never fired";
        }
        else if (status == true)
        {
            return "Hit!";
        }
        else
        {
            return "Miss!";
        }
    }

    // Exemple de méthode pour vérifier si une case du joueur est touchée
    public bool IsPlayerHit(int x, int y)
    {
        if (x >= 0 && x < gridSize && y >= 0 && y < gridSize)
        {
            return PlayerGrid[x, y] == 'B'; // 'B' représente un bateau
        }
        return false;
    }
}
