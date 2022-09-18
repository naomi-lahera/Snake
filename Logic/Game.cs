namespace Logic;
public class Game
{
    List<Coordinates> coordinates;
    Map map;

    public Game()
    {
        this.coordinates = new List<Coordinates>();
        coordinates.Add(new Coordinates(0,0));
        coordinates.Add(new Coordinates(0,1));
        coordinates.Add(new Coordinates(1,1));
        coordinates.Add(new Coordinates(1,2));
        this.map = new Map();
        foreach(var x in this.coordinates)
            map.PutSnakeBody(x);
        map.PrintMap();
    }
    public void PrintMap() => this.map.PrintMap();
    public void Play(Direction currentDirectionMove)
    {
        int newHeadPosX = (coordinates[0].X + RowIncrement[currentDirectionMove] + map.Width) % map.Width;
        int newHeadPosY = (coordinates[0].Y + ColIncrement[currentDirectionMove] + map.Height) % map.Height;
        coordinates.Insert(0, new Coordinates(newHeadPosX, newHeadPosY));
        map.PutSnakeBody(coordinates[0]);
        map.EliminateSnakeBody(coordinates[coordinates.Count - 1]);
        coordinates.RemoveAt(coordinates.Count - 1);
    }

    //The following dictionaries will representate de increment un the snake move
public static Dictionary<Direction,int> RowIncrement = new Dictionary<Direction, int>()
                        {
                            {Direction.Left, 0},
                            {Direction.Right, 0},
                            {Direction.Up, -1},
                            {Direction.Down, 1}
                        };

public static Dictionary<Direction, int> ColIncrement = new Dictionary<Direction, int>()
                        {
                            {Direction.Left, -1},
                            {Direction.Right, 1},
                            {Direction.Up, 0},
                            {Direction.Down, 0}
                        };
}