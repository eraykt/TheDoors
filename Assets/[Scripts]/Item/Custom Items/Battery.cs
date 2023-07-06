public class Battery : ItemObject
{
    public override void Collect()
    {
        var flashlight = InventorySystem.Instance.inventory.Find(i => i.data.id == 1.ToString()).item;
        flashlight.AddDurability();
        Destroy(gameObject);
    }
}