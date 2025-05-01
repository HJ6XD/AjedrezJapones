using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class View : MonoBehaviour
{
    Controller controller;

    [SerializeField] GameObject tilePrefab;
    [SerializeField] Transform gridParent;

    SquareView[,] gridView;
    private void Awake()
    {
        controller = new Controller(this);
    }

    public void CreateGrid(ref Board board, int rows, int cols)
    {
        gridView = new SquareView[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                gridView[i,j] = Instantiate(tilePrefab, gridParent).GetComponent<SquareView>();
                int2 coords = board.GetSquare(i, j).GetCoord;
                gridView[i,j].SetSquare(coords.x, coords.y);
            }
        }
    }

    public void AddPiece(ref Pieces _piece, int2 _coor)
    {
        gridView[_coor.x, _coor.y].AddPiece(ref _piece);
    }
}
