namespace Logic;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        Stopwatch clock = new Stopwatch();
        clock.Start();
        Game game = new Game();
        for(int i = 0; i < 4; i++)
        {
            game.Play();
            game.PrintMap();
        }
    }
}
