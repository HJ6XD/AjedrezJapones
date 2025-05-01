using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Net.NetworkInformation;

public class SquareView : MonoBehaviour
{
    TextMeshProUGUI pieceText;

    [SerializeField] Image imageComponent;

    [Header("Sprites")]
    [SerializeField] Sprite pawnSprite;
    [SerializeField] Sprite spearSprite;
    [SerializeField] Sprite horseSprite;
    [SerializeField] Sprite silverSprite;
    [SerializeField] Sprite goldSprite;
    [SerializeField] Sprite bishopSprite;
    [SerializeField] Sprite towerSprite;
    [SerializeField] Sprite whiteKingSprite;
    [SerializeField] Sprite blackKingSprite;

    private void Awake()
    {
        pieceText = GetComponentInChildren<TextMeshProUGUI>();
        imageComponent.enabled = false;
    }
    public void SetSquare(int x, int y)
    {
        pieceText.text = $"{x}, {y}";
    }

    public void AddPiece(ref Pieces piece)
    {
        pieceText.enabled = false;
        imageComponent.enabled = true;

        switch (piece.type)
        {
            case PieceType.Pawn:
                imageComponent.sprite = pawnSprite; 
                break;
            case PieceType.Spear:
                imageComponent.sprite = spearSprite; 
                break;
            case PieceType.Horse:
                imageComponent.sprite = horseSprite; 
                break;
            case PieceType.Silver:
                imageComponent.sprite = silverSprite; 
                break;
            case PieceType.Gold:
                imageComponent.sprite = goldSprite; 
                break;
            case PieceType.Bishop:
                imageComponent.sprite = bishopSprite; 
                break;
            case PieceType.Tower:
                imageComponent.sprite = towerSprite; 
                break;
            case PieceType.King:
                if (piece.team == Team.White) imageComponent.sprite = whiteKingSprite;
                else imageComponent.sprite = blackKingSprite;
                break;
        }

        switch (piece.team) 
        {
            case Team.White:
                imageComponent.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                break;
            
            case Team.Black:
                imageComponent.gameObject.transform.rotation = Quaternion.Euler(0,0,180);
                break;
        }
    }

    public void RemovePiece()
    {
        pieceText.enabled = true;
        imageComponent.enabled = false;
    }
}
