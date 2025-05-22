using UnityEngine;
using Unity.Mathematics;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Controller
{
    View view;
    Board board;

    const int ROWS = 9;
    const int COLS = 9;

    Team currentTurn = Team.White;

    Pieces selectedPiece = null;

    Player whitePlayer;
    Player blackPlayer;

    List<int2> validMoves = new List<int2>();
    public Board BOARD => board;
    public Controller(View view)
    {
        this.view = view;
        board = new Board(ROWS, COLS);
        view.CreateGrid(ref board, ROWS, COLS);
        whitePlayer = new Player(Team.White);
        blackPlayer = new Player(Team.Black);
        SetBoard();
        view.EnableTeamCementery(currentTurn);
    }
    ~Controller() { }

    void SetBoard()
    {
        // Set Pawns
        for (int i = 0; i < ROWS; i++)
        {
            CreatePiece(new int2(i, 6), PieceType.Pawn, Team.White);
            CreatePiece(new int2(i, 2), PieceType.Pawn, Team.Black);
        }

        // Set Spears
        CreatePiece(new int2(0, 8), PieceType.Spear, Team.White);
        CreatePiece(new int2(8, 8), PieceType.Spear, Team.White);
        CreatePiece(new int2(0, 0), PieceType.Spear, Team.Black);
        CreatePiece(new int2(8, 0), PieceType.Spear, Team.Black);

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

        switch (_type)
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

    void RemovePiece(int2 coor)
    {
        board.GetSquare(coor.x, coor.y).piece = null;
        view.RemovePiece(coor);
    }

    void AddPiece(ref Pieces piece, int2 coor)
    {
        board.GetSquare(coor.x, coor.y).piece = piece;
        piece.coor = coor;
        view.AddPiece(ref piece, coor);
    }

    void EatPiece(ref Pieces eatenPiece)
    {
        eatenPiece.coor = new int2(-1, -1);
        eatenPiece.team = currentTurn;
        Player currentPlayer = currentTurn == Team.White ? whitePlayer : blackPlayer;


        switch (eatenPiece.type) { 

            case PieceType.Pawn:
                currentPlayer.sideBoard.pawnQ.Enqueue((Pawn)eatenPiece);
                view.UpdateCementery(currentTurn, eatenPiece.type, currentPlayer.sideBoard.pawnQ.Count);
                break;

            case PieceType.Spear:
                currentPlayer.sideBoard.spearQ.Enqueue((Spear)eatenPiece);
                view.UpdateCementery(currentTurn, eatenPiece.type, currentPlayer.sideBoard.spearQ.Count);
                break;

            case PieceType.Horse:
                currentPlayer.sideBoard.horseQ.Enqueue((Horse)eatenPiece);
                view.UpdateCementery(currentTurn, eatenPiece.type, currentPlayer.sideBoard.horseQ.Count);
                break;

            case PieceType.Silver:
                currentPlayer.sideBoard.SilverQ.Enqueue((Silver)eatenPiece);
                view.UpdateCementery(currentTurn, eatenPiece.type, currentPlayer.sideBoard.SilverQ.Count);
                break;

            case PieceType.Gold:
                currentPlayer.sideBoard.goldQ.Enqueue((Gold)eatenPiece);
                view.UpdateCementery(currentTurn, eatenPiece.type, currentPlayer.sideBoard.goldQ.Count);
                break;

            case PieceType.Tower:
                currentPlayer.sideBoard.towerQ.Enqueue((Tower)eatenPiece);
                view.UpdateCementery(currentTurn, eatenPiece.type, currentPlayer.sideBoard.towerQ.Count);
                break;

            case PieceType.Bishop:
                currentPlayer.sideBoard.bishopQ.Enqueue((Bishop)eatenPiece);
                view.UpdateCementery(currentTurn, eatenPiece.type, currentPlayer.sideBoard.bishopQ.Count);
                break;
        }
    }

    public void SelectSquare(int2 gridPos)
    {
        ref Square selectedSquare = ref board.GetSquare(gridPos.x, gridPos.y);
        if (selectedPiece != null) {
            if (selectedSquare.piece == null) { // Move Piece
                if (!IsValidMove(selectedSquare.GetCoord) && selectedPiece.coor.x >0) return;
                if (selectedPiece.coor.x < 0)
                    UpdateCementeryCount(selectedPiece.type);
                MoveSelectedPiece(selectedSquare);
                currentTurn = currentTurn == Team.White ? Team.Black : Team.White;
                    
            }
            else if (selectedSquare.piece.team == currentTurn)   // Cambiar Seleccion
            {
                if (selectedPiece.coor.x < 0)
                    EatPiece(ref selectedPiece);
                selectedPiece = selectedSquare.piece;
                SelectNewPiece(selectedSquare.piece);
            }
            else if(selectedPiece.coor.x >= 0) //Eat Piece
            {
                if (!IsValidMove(selectedSquare.GetCoord)) return;
                EatPiece(ref selectedSquare.piece);
                MoveSelectedPiece(selectedSquare);
                currentTurn = currentTurn == Team.White ? Team.Black : Team.White;
                
            }
        }

        else
        {
            if (selectedSquare.piece == null) return;
            if (selectedSquare.piece.team != currentTurn) return;
            SelectNewPiece(selectedSquare.piece);
        }
    }
    bool IsValidMove(int2 move)
    {
        foreach (int2 validMove in validMoves) {
            if (move.x != validMove.x) continue;
            if (move.y == validMove.y) return true;
        }
        return false;
    }
    void SelectNewPiece(Pieces piece)
    {
        selectedPiece = piece;
        validMoves.Clear();
        List<int2>pieceMoves = selectedPiece.GetMoves();
        int2 pieceCoor = selectedPiece.coor;

        if (selectedPiece.GetType().IsSubclassOf(typeof(SingleMovePiece))) {
            foreach (int2 move in pieceMoves) { 
                int2 newCoor;
                newCoor.x = move.x;
                newCoor.y = currentTurn == Team.White ? move.y : -move.y;
                newCoor += pieceCoor;
                if (newCoor.x < 0 || newCoor.x >= ROWS) continue;
                if (newCoor.y < 0 || newCoor.y >= COLS) continue;
                if(board.GetSquare(newCoor.x, newCoor.y).piece != null)
                {
                    if (board.GetSquare(newCoor.x, newCoor.y).piece.team == currentTurn) continue;
                }
                validMoves.Add(newCoor);
            }
        }
        else if(selectedPiece.GetType().IsSubclassOf(typeof(DirectionalMovePiece))){
            foreach (int2 direction in pieceMoves) { 
                for(int i = 1; i <=8; i++) {
                    int2 newCoor = pieceCoor + direction * i;
                    if (newCoor.x < 0 || newCoor.x >= ROWS) break;
                    if (newCoor.y < 0 || newCoor.y >= COLS) break;
                    if(board.GetSquare(newCoor.x, newCoor.y).piece != null)
                    {
                        if (board.GetSquare(newCoor.x, newCoor.y).piece.team == currentTurn) break;
                        validMoves.Add(newCoor);
                        break;
                    }
                    validMoves.Add(newCoor);
                }
            }
        }
    }

    void MoveSelectedPiece(Square selectedSquare)
    {
        if (selectedPiece.coor.x >= 0)
            RemovePiece(selectedPiece.coor); 

        AddPiece(ref selectedPiece, selectedSquare.GetCoord);
        selectedPiece = null;
    }

    void UpdateCementeryCount(PieceType pieceType)
    {
        Player currentPlayer = currentTurn == Team.White ? whitePlayer : blackPlayer;

        switch (pieceType)
        {

            case PieceType.Pawn:
                view.UpdateCementery(currentTurn, pieceType, currentPlayer.sideBoard.pawnQ.Count);
                break;

            case PieceType.Spear:
                view.UpdateCementery(currentTurn, pieceType, currentPlayer.sideBoard.spearQ.Count);
                break;

            case PieceType.Horse:
                view.UpdateCementery(currentTurn, pieceType, currentPlayer.sideBoard.horseQ.Count);
                break;

            case PieceType.Silver:
                view.UpdateCementery(currentTurn, pieceType, currentPlayer.sideBoard.SilverQ.Count);
                break;

            case PieceType.Gold:
                view.UpdateCementery(currentTurn, pieceType, currentPlayer.sideBoard.goldQ.Count);
                break;

            case PieceType.Tower:
                view.UpdateCementery(currentTurn, pieceType, currentPlayer.sideBoard.towerQ.Count);
                break;

            case PieceType.Bishop:
                view.UpdateCementery(currentTurn, pieceType, currentPlayer.sideBoard.bishopQ.Count);
                break;
        }
    }

    public void SelectCementarySquare(PieceType _pieceType)
    {
        Player currentPlayer = currentTurn == Team.White? whitePlayer : blackPlayer;
        selectedPiece = _pieceType switch
        {
            PieceType.Pawn => currentPlayer.sideBoard.pawnQ.Dequeue(),
            PieceType.Spear => currentPlayer.sideBoard.spearQ.Dequeue(),
            PieceType.Horse => currentPlayer.sideBoard.horseQ.Dequeue(),
            PieceType.Silver => currentPlayer.sideBoard.SilverQ.Dequeue(),
            PieceType.Gold => currentPlayer.sideBoard.goldQ.Dequeue(),
            PieceType.Tower => currentPlayer.sideBoard.towerQ.Dequeue(),
            PieceType.Bishop => currentPlayer.sideBoard.bishopQ.Dequeue(),
            _ => null
        };
    }
}
