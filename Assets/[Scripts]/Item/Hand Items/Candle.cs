public class Candle : LightObjects
{
    protected override void OnItemBreak()
    {
        InventorySystem.Instance.Remove(this);
        Destroy(gameObject);
    }
    
}