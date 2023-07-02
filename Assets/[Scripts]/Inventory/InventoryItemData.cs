using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Inventory Item")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string itemName;
    public Sprite icon;
    public bool hasDurability;
    public int maxDurability;
    public GameObject prefab;

    private void OnValidate()
    {
        if (!hasDurability && maxDurability > 0)
            maxDurability = 0;
    }
}