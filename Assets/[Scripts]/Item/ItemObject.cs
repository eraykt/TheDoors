using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable, ICollectable
{
    public InventoryItemData data;

    private ItemOutline outline;
    private ItemCanvas canvas;

    public GameObject handObject;

    protected void Awake()
    {
        outline = GetComponent<ItemOutline>();
        canvas = GetComponent<ItemCanvas>();
    }

    protected void Start()
    {
        SetItemName();
    }

    public virtual void Collect()
    {
        var item = Instantiate(handObject, InventorySystem.Instance.HandTransform).GetComponent<HandItem>();
        item.SetItem(data);
        item.SetItemGfx(false);
        InventorySystem.Instance.Add(data, item);
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