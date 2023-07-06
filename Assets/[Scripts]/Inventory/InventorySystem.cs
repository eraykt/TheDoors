using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystem : Singleton<InventorySystem>
{
    public List<InventoryItem> inventory;
    public System.Action OnInventoryUpdated;

    [SerializeField] private Transform handTransform;
    public Transform HandTransform => handTransform;

    protected override void Awake()
    {
        base.Awake();
    }

    public HandItem Get(InventoryItem refItem)
    {
        return inventory.Find(i => i.item == refItem.item).item;
    }

    public InventoryItem Get(HandItem refItem)
    {
        return inventory.Find(i => i.item == refItem);
    }

    public void Add(InventoryItemData referenceData, HandItem onHand)
    {
        var newItem = new InventoryItem(referenceData)
        {
            item = onHand
        };
        inventory.Add(newItem);
        OnInventoryUpdated?.Invoke();
    }

    public void UpdateInventory(InventoryItem referenceData, InventorySlotUi slot)
    {
        referenceData.item.SetSlot(slot);
        // OnInventoryUpdated?.Invoke();
    }

    public void Remove(HandItem refItem)
    {
        var item = Get(refItem);
        
        if (item != null)
        {
            inventory.Remove(item);
        }

        OnInventoryUpdated?.Invoke();
    }
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public InventoryItemData data;
    public HandItem item;

    public InventoryItem(InventoryItemData data)
    {
        this.data = data;
        itemName = data.itemName;
    }
}