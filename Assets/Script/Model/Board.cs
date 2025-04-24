using Unity.Mathematics;
using UnityEngine;

public struct Board
{

    Square[,] grid;

    public Board(int rows, int cols) 
    { 
        grid = new Square[rows, cols];
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                grid[i, j] = new Square(i, j);
            }
        }
    }
    public ref Square GetSquare(int row, int col) => ref grid[row, col];
}

public struct Square
{
    int2 coord;
    public Square(int x, int y) 
    { 
        coord = new int2(x, y);
    }

    public int2 GetCoord => coord;
}
