namespace Battleship.Models;

public class Boat
{
    public char Identifier { get; set; }  // 'A' à 'F'
    public int Size { get; set; }          // Taille du bateau
    public bool IsVertical { get; set; }   // Orientation
}
