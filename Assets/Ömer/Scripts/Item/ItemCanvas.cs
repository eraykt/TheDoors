using TMPro;
using UnityEngine;

public class ItemCanvas : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    [SerializeField] private TextMeshProUGUI itemName;

    private void Start()
    {
        SetActiveCanvas(false);
    }
    
    public void SetActiveCanvas(bool active)
    {
        canvas.gameObject.SetActive(active);
    }

    public void SetItemName(string item)
    {
        itemName.SetText(item);
    }
}