using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable, ICollectable
{
    public InventoryItemData data;

    public void Collect()
    {
        InventorySystem.Instance.Add(data);
        Destroy(gameObject);
    }

    public void Interaction()
    {
        // open item canvas
        Debug.Log(data.itemName);
    }
}