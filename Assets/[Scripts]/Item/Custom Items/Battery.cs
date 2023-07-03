public class Battery : ItemObject
{
    public override void Collect()
    {
        // eldeki fenerin durabilitysini arttirir.
        Destroy(gameObject);
    }
}