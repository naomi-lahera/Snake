namespace Logic;
//Al usar struct no puedo asignar valores directamente por eso utilizo class
public class Coordinates
{
    int x;
    int y;

    public Coordinates(int x, int y)
    {
        this.X = x;
        this.y = y;
    }

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
}

//The following enum wil representete the direction 
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}
