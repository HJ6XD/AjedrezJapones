using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class CementeryView : MonoBehaviour
{
    [SerializeField] CementeryCellView pawnView;
    [SerializeField] CementeryCellView spearView;
    [SerializeField] CementeryCellView horseView;
    [SerializeField] CementeryCellView silverView;
    [SerializeField] CementeryCellView goldView;
    [SerializeField] CementeryCellView towerView;
    [SerializeField] CementeryCellView bishopView;

    
    
    public void SetCementeryCellsView( View view)
    {
        pawnView.SetCementeryView(view, PieceType.Pawn);
        spearView.SetCementeryView(view, PieceType.Spear);
        horseView.SetCementeryView(view, PieceType.Horse);
        silverView.SetCementeryView(view, PieceType.Silver);
        goldView.SetCementeryView(view, PieceType.Gold);
        towerView.SetCementeryView(view, PieceType.Tower);
        bishopView.SetCementeryView(view, PieceType.Bishop);
    }

    public void SetEnableButtons( bool enable = true)
    {
        pawnView.EnableButton(enable); 
        spearView.EnableButton( enable); 
        horseView.EnableButton( enable ); 
        silverView.EnableButton( enable ); 
        goldView.EnableButton( enable ); 
        towerView.EnableButton( enable );
        bishopView.EnableButton( enable );    
    }
    public void UpdtaeCellView(PieceType pieceType, int count)
    {
        switch (pieceType)
        {
            case PieceType.Pawn:
                pawnView.CountText(count);
                break;

            case PieceType.Spear:
                spearView.CountText(count);
                break;

            case PieceType.Horse:
                horseView.CountText(count);
                break;

            case PieceType.Silver:
                silverView.CountText(count);
                break;

            case PieceType.Gold:
                goldView.CountText(count); ;
                break;

            case PieceType.Tower:
                towerView.CountText(count);
                break;

            case PieceType.Bishop:
                bishopView.CountText(count);
                break;
        }
    }

    
}