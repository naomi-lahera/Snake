namespace Logic;
public class Game
{
    Map current_game;
    public Game(int dimension_map)
    {
        this.current_game = new Map(dimension_map);
    }

    public board_values[,] Board => current_game.Board;
    public int Dimension_Board => current_game.Dimension;
}