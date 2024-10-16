public class GameState
{
    public char[,] PlayerGrid { get; set; }
    public bool?[,] OpponentGrid { get; set; }

    public GameState()
    {
        PlayerGrid = new char[10, 10];
        OpponentGrid = new bool?[10, 10];
    }
}
