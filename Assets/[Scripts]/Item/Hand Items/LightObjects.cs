using UnityEngine;

public class LightObjects : HandItem
{
    public Light lightRef;
    public bool IsDead => CurrentDurability <= 0;
    public bool IsOn => lightRef.enabled;

    protected override void Use()
    {
        IsUsing = !IsUsing;
        lightRef.enabled = !lightRef.enabled && !IsDead;
    }

    protected override void OnItemBreak()
    {
        lightRef.enabled = false;
        IsUsing = false;
    }
}