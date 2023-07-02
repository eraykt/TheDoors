using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Inventory Item")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string itemName;
    public bool isStackable;
    public Sprite icon;
    public GameObject prefab;
}