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
    [SerializeField] private Image sliderFill;
    private HandItem item;

    private Gradient gradient;

    public void Set(InventoryItem item)
    {
        icon.sprite = item.data.icon;
        itemName.SetText(item.itemName);
        durability.gameObject.SetActive(item.data.hasDurability);
        SetGradient();
        this.item = item.item;
    }

    public void SetId(int index)
    {
        slotId.SetText(index.ToString());
    }

    public void Select()
    {
        frame.gameObject.SetActive(true);
        item.Selected = true;
    }

    public void Deselect()
    {
        frame.gameObject.SetActive(false);
        item.Selected = false;
    }

    private void SetGradient()
    {
        if (!durability.gameObject.activeSelf) return;
        gradient = new Gradient();
        var colors = new GradientColorKey[3];
        colors[0].color = Color.red;
        colors[0].time = 0.0f;
        colors[1].color = Color.yellow;
        colors[1].time = 0.5f;
        colors[2].color = Color.green;
        colors[2].time = 1.0f;
        gradient.colorKeys = colors;
    }

    public void UpdateDurability(float value)
    {
        durability.value = value;
        sliderFill.color = gradient.Evaluate(value);
        // sliderFill.color = Color.Lerp(Color.red, Color.green, value);
    }
}