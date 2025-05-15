using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class View : MonoBehaviour
{
    Controller controller;

    [SerializeField] GameObject tilePrefab;
    [SerializeField] Transform gridParent;

    [SerializeField] CementeryView whiteCementery;
    [SerializeField] CementeryView blackCementery;

    SquareView[,] gridView;
    private void Awake()
    {
        controller = new Controller(this);
    }

    private void Start()
    {
        whiteCementery.SetCementeryCellsView(this);
        blackCementery.SetCementeryCellsView(this);
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
                gridView[i,j].SetSquare(coords.x, coords.y, this);
            }
        }
    }

    public void AddPiece(ref Pieces _piece, int2 _coor)
    {
        gridView[_coor.x, _coor.y].AddPiece(ref _piece);
    }

    public void RemovePiece(int2 coor)
    {
        gridView[coor.x, coor.y].RemovePiece();
    }

    public void SelectSquare(ref int2 gridpos)
    {
        controller.SelectSquare(gridpos);
    }

    public void UpdateCementery(Team team, PieceType piecetype, int count)
    {
       if(team == Team.White) whiteCementery.UpdtaeCellView(piecetype, count);
       else blackCementery.UpdtaeCellView(piecetype,count);
    }

    public void EnableTeamCementery(Team team) { 
        if(team == Team.White)
        {
            whiteCementery.SetEnableButtons();
            blackCementery.SetEnableButtons(false);
        }
        else
        {
            whiteCementery.SetEnableButtons(false);
            blackCementery.SetEnableButtons();
        }
    }

    public void SelectCementaryPiece(PieceType _pieceType)
    {
        controller.SelectCementarySquare(_pieceType);
    }
}
