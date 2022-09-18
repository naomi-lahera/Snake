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
    public void Play()
    {
        if(coordinates.Count == 0) return;

        Coordinates newHeadPos = coordinates[0].Y - 1 >= 0 ? new Coordinates(coordinates[0].X, coordinates[0].Y - 1) : new Coordinates(coordinates[0].X, map.Height - 1);
        coordinates.Insert(0, newHeadPos);
        map.PutSnakeBody(coordinates[0]);
        map.EliminateSnakeBody(coordinates[coordinates.Count - 1]);
        coordinates.RemoveAt(coordinates.Count - 1);
    }
}