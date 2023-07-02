using System.Collections.Generic;

public class InventorySystem : Singleton<InventorySystem>
{
    public List<InventoryItem> inventory;

    protected override void Awake()
    {
        base.Awake();
        
        inventory = new List<InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        var item = inventory.Find(value => value.Data == referenceData);
        return item;
    }

    public void Add(InventoryItemData referenceData)
    {
        var newItem = new InventoryItem(referenceData);
        inventory.Add(newItem);
    }

    public void Remove(InventoryItemData referenceData)
    {
        var item = Get(referenceData);

        if (item != null)
            inventory.Remove(item);
    }
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public InventoryItemData Data { get; private set; }

    public InventoryItem(InventoryItemData data)
    {
        Data = data;
        itemName = data.itemName;
    }
}