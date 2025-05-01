using UnityEngine;
using Unity.Mathematics;

public class Controller
{
    View view;
    Board board;

    const int ROWS = 9;
    const int COLS = 9;

    public Board BOARD => board;
    public Controller(View view)
    {
        this.view = view;
        board = new Board(ROWS,COLS);
        view.CreateGrid(ref board, ROWS, COLS);
        SetBoard();
    }
    ~Controller() { }

    void SetBoard()
    {
        // Set Pawns
        for(int i =0; i < ROWS; i++)
        {
            CreatePiece(new int2(i,6), PieceType.Pawn, Team.White);
            CreatePiece(new int2(i,2), PieceType.Pawn, Team.Black);
        }

        // Set Spears
        CreatePiece(new int2(0,8), PieceType.Spear, Team.White);
        CreatePiece(new int2(8,8), PieceType.Spear, Team.White);
        CreatePiece(new int2(0,0), PieceType.Spear, Team.Black);
        CreatePiece(new int2(8,0), PieceType.Spear, Team.Black);

        // Set Horses
        CreatePiece(new int2(1, 8), PieceType.Horse, Team.White);
        CreatePiece(new int2(7, 8), PieceType.Horse, Team.White);
        CreatePiece(new int2(1, 0), PieceType.Horse, Team.Black);
        CreatePiece(new int2(7, 0), PieceType.Horse, Team.Black);
        
        // Set SilverS
        CreatePiece(new int2(2, 8), PieceType.Silver, Team.White);
        CreatePiece(new int2(6, 8), PieceType.Silver, Team.White);
        CreatePiece(new int2(2, 0), PieceType.Silver, Team.Black);
        CreatePiece(new int2(6, 0), PieceType.Silver, Team.Black);
        
        // Set GoldS
        CreatePiece(new int2(3, 8), PieceType.Gold, Team.White);
        CreatePiece(new int2(5, 8), PieceType.Gold, Team.White);
        CreatePiece(new int2(3, 0), PieceType.Gold, Team.Black);
        CreatePiece(new int2(5, 0), PieceType.Gold, Team.Black);

        // Set Kings
        CreatePiece(new int2(4, 8), PieceType.King, Team.White);
        CreatePiece(new int2(4, 0), PieceType.King, Team.Black);

        //Set Bishops
        CreatePiece(new int2(1, 7), PieceType.Bishop, Team.White);
        CreatePiece(new int2(7, 1), PieceType.Bishop, Team.Black);
        
        //Set Towers
        CreatePiece(new int2(7, 7), PieceType.Tower, Team.White);
        CreatePiece(new int2(1, 1), PieceType.Tower, Team.Black);

    }

    void CreatePiece(int2 _coor, PieceType _type, Team _team)
    {
        Pieces piece = null;

        switch(_type)
        {
            case PieceType.Pawn:
                piece = new Pawn(_coor, _team);
                break;
            case PieceType.Spear:
                piece = new Spear(_coor, _team);
                break;
            case PieceType.Horse:
                piece = new Horse(_coor, _team);
                break;
            case PieceType.Silver:
                piece = new Silver(_coor, _team);
                break;
            case PieceType.Gold:
                piece = new Gold(_coor, _team);
                break;
            case PieceType.Bishop:
                piece = new Bishop(_coor, _team);
                break;
            case PieceType.Tower:
                piece = new Tower(_coor, _team);
                break;
            case PieceType.King:
                piece = new King(_coor, _team);
                break;
        }
        if (piece == null) return;

        board.GetSquare(_coor.x, _coor.y).piece = piece;
        view.AddPiece(ref piece, _coor);
    }
}
