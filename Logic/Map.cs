namespace Logic;
public class Map
{
    int[,] map;
    public Map(){
        //this.coordinates = new List<Coordinates>();
        this.map = new int[6,6];
    }

    public int Height => this.map.GetLength(0);//files number
    public int Width => this.map.GetLength(1);//columns number
    public bool ValidPos(Coordinates coor) => !(coor.X < 0 || coor.X >= this.Height || coor.Y < 0 || coor.Y >= this.Width);//Is a position valid
    public void PutSnakeBody(Coordinates pos)
    {
        if(ValidPos(pos)) 
            map[pos.X, pos.Y] = 1;
    }

    public void EliminateSnakeBody(Coordinates pos)
    {
        if(ValidPos(pos))
            map[pos.X, pos.Y] = 0;
    }

    public void PrintMap()
    {
        for(int  i = 0; i < this.map.GetLength(0); i++)
        {
            for(int j = 0; j < this.map.GetLength(1); j++)
            {
                if(map[i,j] == 0) System.Console.Write("| |");
                else System.Console.Write("|1|");
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }
     
}
