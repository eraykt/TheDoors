using UnityEngine;

public class LightObjects : HandItem
{
    public Light lightRef;
    public bool IsDead => CurrentDurability <= 0;
    public bool IsOn => lightRef.enabled;

    
    protected override void Use()
    {
        if (!Selected) return;
        
        IsUsing = !IsUsing;
        lightRef.enabled = IsUsing && !IsDead;
    }

    public override void DeSelect(bool value)
    {
        lightRef.enabled = value;
        IsUsing = value;
        Selected = value;
        SetItemGfx(value);
    }
    protected override void OnItemBreak()
    {
        lightRef.enabled = false;
        IsUsing = false;
    }
}