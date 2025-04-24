using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class View : MonoBehaviour
{
    Controller controller;

    [SerializeField] GameObject tilePrefab;
    [SerializeField] Transform gridParent;

    private void Awake()
    {
        controller = new Controller(this);
    }

    public void CreateGrid(ref Board board, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject _tile = Instantiate(tilePrefab, gridParent);
                int2 coords = board.GetSquare(i, j).GetCoord;
                _tile.GetComponentInChildren<TextMeshProUGUI>().text = $"({coords.x},{coords.y})";
            }
        }
    }
}
