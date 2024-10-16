namespace Battleship.Models;

public class Grid
{
    public char[,] PlayerGrid { get; set; }
    public bool?[,] OpponentGrid { get; set; }

    public Grid(int size = 10)
    {
        PlayerGrid = new char[size, size];
        OpponentGrid = new bool?[size, size]; // null = non touché, true = touché, false = raté
    }
}
