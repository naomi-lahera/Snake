using System.Collections;
using System;
namespace Logic;
using System.Collections.Generic;

public enum board_values
{
    snake,
    egg,
    obstacule,
    empty
}

public class Map
{
    int dimension;
    board_values[,] board;
    List<(int, int)> snake;
    Dictionary<(int, int), int> eggs;

    public board_values[,] Board { get => board; set => board = value; }
    public int Dimension { get => dimension; set => dimension = value; }

    public Map(int dimension)
    {
        this.Dimension = dimension;
        this.board = new board_values[dimension, dimension];
        for (int i = 0; i < dimension; i++)
            for(int j = 0; j < dimension; j++)
                this.board[i,j] = board_values.empty;

        List<(int, int)> obst = init_obstacle();
        while(!valid_board(obst))
            obst = init_obstacle();
        put_obstacle(obst);

        this.snake = new List<(int, int)>();
        init_snake();

        this.eggs = new Dictionary<(int, int), int>();
        init_eggs();

    }

    public bool valid_board(List<(int, int)> obst)
    {
        bool[,] mask = new bool[dimension, dimension];
        Queue<(int, int)> q = new Queue<(int, int)>();

        for (int i = 0; i < obst.Count; i++)
            mask[obst[i].Item1, obst[i].Item2] = true;

        Random r = new Random();
        (int, int) pos = (r.Next(0, dimension), r.Next(0, dimension));
        while(obst.Contains(pos))
            pos = (r.Next(0, dimension), r.Next(0, dimension));
        q.Enqueue(pos);

        (int, int)[] dir = {(-1, 0), (1, 0), (0, -1), (0, 1)};

        while(q.Count != 0)
        {
            (int, int) p = q.Dequeue();
            for (int i = 0 ; i < dir.Length; i++)
            {
                if(vali_pos((p.Item1 + dir[i].Item1, p.Item2 + dir[i].Item2)) && !mask[p.Item1 + dir[i].Item1, p.Item2 + dir[i].Item2])
                {
                    mask[p.Item1 + dir[i].Item1, p.Item2 + dir[i].Item2]  = true;
                    q.Enqueue((p.Item1 + dir[i].Item1, p.Item2 + dir[i].Item2));
                }
            }
        } 

        for (int i = 0; i < mask.GetLength(0); i++)
            for(int j = 0; j < mask.GetLength(1); j++)
                if( !mask[i, j])
                    return false;
        
        return true;
    }

    bool vali_pos((int, int) pos) => pos.Item1 >= 0 && pos.Item1 < dimension && pos.Item2 >= 0 && pos.Item2 < dimension;

    void put_obstacle(List<(int, int)> obst)
    {
        for (int i = 0; i < obst.Count; i++)
            board[obst[i].Item1, obst[i].Item2] = board_values.obstacule;
    }

    public void init_snake()
    {
        Random r = new Random();
        snake.Add((r.Next(0, Dimension), r.Next(0, Dimension)));
        Board[snake[0].Item1, snake[0].Item2] = board_values.snake;

        (int, int)[] dir = {(-1, 0), (1, 0), (0, -1), (0, 1)};
        int new_tail_dir = r.Next(0, 4);
        int tail_x = (dir[new_tail_dir].Item1 + snake[0].Item1) % Dimension;
        int tail_y = (dir[new_tail_dir].Item2 + +snake[0].Item2) % Dimension;
        snake.Add((tail_x, tail_y));
        this.board[tail_x, tail_y] = board_values.snake;
    }

    public void init_eggs()
    {
        int total = (int)((10 * Math.Pow(9, 2)) / 100);
        Random r = new Random();
        int x = 0;
        int y = 0;
        while(total > 0)
        {
            x = r.Next(0, Dimension);
            y = r.Next(0, Dimension);
            if (board[x, y] == board_values.empty)
            {
                this.eggs.Add((x,y), r.Next(0, Dimension));
                this.board[x, y] = board_values.egg;
                total--;
            }
        }
    }

    public List<(int, int)> init_obstacle()
    {
        List<(int, int)> result = new List<(int, int)>();
        int total = (int)((30 * Math.Pow(9, 2)) / 100);
        Random r = new Random();
        int x = 0;
        int y = 0;
        while(total > 0)
        {
            x = r.Next(0, Dimension);
            y = r.Next(0, Dimension);
            if (board[x, y] == board_values.empty)
            {
                // this.board[x, y] = board_values.obstacule;
                result.Add((x,y));
                total--;
            }
        }
        return result;
    }
}
