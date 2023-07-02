using System.Collections.Generic;

public class InventorySystem : Singleton<InventorySystem>
{
    public List<InventoryItem> inventory;
    public System.Action OnInventoryUpdated;

    protected override void Awake()
    {
        base.Awake();

        inventory = new List<InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        var item = inventory.Find(value => value.data == referenceData);
        return item;
    }

    public void Add(InventoryItemData referenceData)
    {
        var newItem = new InventoryItem(referenceData);
        inventory.Add(newItem);
        OnInventoryUpdated?.Invoke();
    }

    public void Remove(InventoryItemData referenceData)
    {
        var item = Get(referenceData);

        if (item != null)
            inventory.Remove(item);

        OnInventoryUpdated?.Invoke();
    }
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public InventoryItemData data;

    public InventoryItem(InventoryItemData data)
    {
        this.data = data;
        itemName = data.itemName;
    }
}