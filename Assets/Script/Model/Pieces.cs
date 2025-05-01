using UnityEngine;
using Unity.Mathematics;

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
    protected int2 coor;
    public PieceType type;
    public Team team;

    public Pieces(int2 _coor, PieceType _type, Team _team) { 
        this.coor = _coor;
        this.type = _type;
        this.team = _team;
    }
}

public class Pawn : Pieces
{
    public Pawn(int2 _coor, Team _team) : base (_coor, PieceType.Pawn, _team) {}
}
public class Spear : Pieces
{
    public Spear(int2 _coor, Team _team) : base (_coor, PieceType.Spear, _team) {}
}
public class Horse : Pieces
{
    public Horse(int2 _coor, Team _team) : base (_coor, PieceType.Horse, _team) {}
}
public class Silver : Pieces
{
    public Silver(int2 _coor, Team _team) : base (_coor, PieceType.Silver, _team) {}
}
public class Gold : Pieces
{
    public Gold(int2 _coor, Team _team) : base (_coor, PieceType.Gold, _team) {}
}
public class Bishop : Pieces
{
    public Bishop(int2 _coor, Team _team) : base (_coor, PieceType.Bishop, _team) {}
}
public class Tower : Pieces
{
    public Tower(int2 _coor, Team _team) : base (_coor, PieceType.Tower, _team) {}
}
public class King : Pieces
{
    public King(int2 _coor, Team _team) : base(_coor, PieceType.King, _team) {}
}