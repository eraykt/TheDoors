using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI slotId;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Slider durability;
    [SerializeField] private Image frame;
    

    public void Set(InventoryItem item, int index)
    {
        slotId.SetText(index.ToString());

        icon.sprite = item.data.icon;
        itemName.SetText(item.itemName);
        durability.gameObject.SetActive(item.data.hasDurability);
    }
    
    public void Select()
    {
        frame.gameObject.SetActive(true);
    }
    
    public void Deselect()
    {
        frame.gameObject.SetActive(false);
    }
}