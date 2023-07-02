using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable, ICollectable
{
    public InventoryItemData data;

    private ItemOutline outline;
    private ItemCanvas canvas;

    private void Awake()
    {
        outline = GetComponent<ItemOutline>();
        canvas = GetComponent<ItemCanvas>();
    }

    private void Start()
    {
        SetItemName();
    }

    public void Collect()
    {
        InventorySystem.Instance.Add(data);
        Destroy(gameObject);
    }

    public void Interaction()
    {
        outline.SetOutline(true);
        canvas.SetActiveCanvas(true);
    }

    public void DeInteraction()
    {
        outline.SetOutline(false);
        canvas.SetActiveCanvas(false);
    }

    public void SetItemName()
    {
        canvas.SetItemName(data.itemName);
    }
}