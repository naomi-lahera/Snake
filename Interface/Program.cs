namespace System;
using Logic;
public class Program
{
    public static void Main(string[] args)
    {
        Game game = init_game();
        print_board(game);
    }

    public static Game init_game()
    {
        Console.WriteLine("Welcome to the snake game");
        Console.WriteLine("Please specify the dimension of the board game");
        int dimension = 9;
        string input = Console.ReadLine();

        while(!int.TryParse(input, out dimension) || dimension < 9 || dimension > 100)
            input = Console.ReadLine();

        Console.WriteLine("dimension");
        Game game = new Game(dimension);
        return game;
    }

    public static void print_board(Game game)
    {
        int dimension = game.Dimension_Board;
        for (int i = 0; i < dimension; i++)
        {
            for(int j = 0; j < dimension; j++)
            {
                if (game.Board[i, j] == board_values.snake)
                    Console.Write("s ");
                    //Console.WriteLine("🐍");
                else if (game.Board[i,j] == board_values.egg)
                    Console.Write("e ");
                    //Console.WriteLine("🥚");
                else if (game.Board[i, j] == board_values.obstacule)
                    Console.Write("o ");
                    //Console.WriteLine("🟫");
                else
                    //Console.Write("⬜");
                    Console.Write("  ");
            }
            Console.WriteLine();
        }
    }
}