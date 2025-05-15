using UnityEngine;
using System.Collections.Generic;

public class Player
{
    public Team team { get; private set; }
    public SideBoard sideBoard {  get; private set; }

    public Player(Team team)
    {
        this.team = team;
        sideBoard = new SideBoard();
    }
}

public class SideBoard
{
    public Queue<Pawn> pawnQ = new Queue<Pawn>();
    public Queue<Spear> spearQ = new Queue<Spear>();
    public Queue<Horse> horseQ = new Queue<Horse>();
    public Queue<Silver> SilverQ = new Queue<Silver>();
    public Queue<Gold> goldQ = new Queue<Gold>();
    public Queue<Tower> towerQ = new Queue<Tower>();
    public Queue<Bishop> bishopQ = new Queue<Bishop>();
}
