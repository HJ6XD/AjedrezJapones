using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CementeryCellView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;

    View view;
    Button buttonComponent;

    PieceType pieceType;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
    }
    public void SetCementeryView(View _view, PieceType _pieceType)
    {
        this.view = _view;
        this.pieceType = _pieceType;
    }


    private void Start()
    {
        countText.text = "0";
    }

    private void OnEnable()
    {
        buttonComponent.onClick.AddListener(SelectCementeryCell);
    }

    private void OnDisable()
    {
        buttonComponent.onClick.RemoveListener(SelectCementeryCell);

    }

    public void CountText(int count)
    {
        countText.text = count.ToString();
    }
    public void EnableButton(bool _enable = true)
    {
        buttonComponent.enabled = _enable;
    }

    public void SelectCementeryCell()
    {
        view?.SelectCementaryPiece(pieceType);
    }
}
