using UnityEngine;
using Unity.Mathematics;
using NUnit.Framework;
using System.Collections.Generic;

public enum PieceType
{
    Pawn,
    Spear,
    Horse,
    Silver,
    Gold,
    Tower,
    Bishop,
    King
}

public enum Team
{
    White,
    Black
}
public abstract class Pieces
{
    public int2 coor;
    public PieceType type;
    public Team team;
    public  List<int2> moves;

    public abstract List<int2> GetMoves();

    public Pieces(int2 _coor, PieceType _type, Team _team) { 
        this.coor = _coor;
        this.type = _type;
        this.team = _team;
    }
}

public abstract class SingleMovePiece : Pieces
{
    public SingleMovePiece(int2 coor, PieceType type, Team team) : base (coor, type, team) { }

    public override List<int2> GetMoves()
    {
        return moves;
    }
}
public abstract class DirectionalMovePiece : Pieces
{
    protected List<int2> directions;
    public DirectionalMovePiece(int2 coor, PieceType type, Team team) : base(coor, type, team) { }

    public override List<int2> GetMoves() { return directions; }
}
public class Pawn : SingleMovePiece
{
    public Pawn(int2 _coor, Team _team) : base (_coor, PieceType.Pawn,  _team) {
        moves = new List<int2>()
        {
            new int2 (0,-1)
        }; 
    }
}
public class Spear : DirectionalMovePiece
{
    public Spear(int2 _coor, Team _team) : base (_coor, PieceType.Spear, _team) {
        directions = new List<int2>()
        {
            new int2 (-1,0)
        };
    }

}
public class Horse : SingleMovePiece
{
    public Horse(int2 _coor, Team _team) : base (_coor, PieceType.Horse, _team) {
        moves = new List<int2>()
        {
            new int2 (-1,-2),
            new int2 (1,-2)
        };
    }
}
public class Silver : SingleMovePiece
{
    public Silver(int2 _coor, Team _team) : base (_coor, PieceType.Silver, _team) {
        moves = new List<int2>()
        {
            new int2 (-1,-1),
            new int2 (0,-1),
            new int2 (1,-1),
            new int2 (1,1),
            new int2 (-1,1),
        };
    }
}
public class Gold : SingleMovePiece
{
    public Gold(int2 _coor, Team _team) : base (_coor, PieceType.Gold, _team) {
        moves = new List<int2>()
        {
            new int2 (-1,-1),
            new int2 (0,-1),
            new int2 (1,-1),
            new int2 (-1,0),
            new int2 (1,0),
            new int2 (0,-1)
        };
    }
}
public class Bishop : DirectionalMovePiece
{
    public Bishop(int2 _coor, Team _team) : base(_coor, PieceType.Bishop, _team) {
        directions = new List<int2>()
        {
            new int2(-1, 1),
            new int2(-1, -1),
            new int2(1, -1),
            new int2(1, 1)
        };
    }

}
public class Tower : DirectionalMovePiece
{
    public Tower(int2 _coor, Team _team) : base (_coor, PieceType.Tower, _team) {
        directions = new List<int2>()
        {
            new int2(-1, 0),
            new int2(0, -1),
            new int2(1, 0),
            new int2(0, 1)
        };
    }

}
public class King : SingleMovePiece
{
    public King(int2 _coor, Team _team) : base (_coor, PieceType.King, _team) {
        moves = new List<int2>()
        {
            new int2 (-1,-1),
            new int2 (0,-1),
            new int2 (1,-1),
            new int2 (-1,0),
            new int2 (1,0),
            new int2 (-1,1),
            new int2 (0,1),
            new int2 (1,1),
        };
    }
}