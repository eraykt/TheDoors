using UnityEngine;

public abstract class HandItem : MonoBehaviour
{
    public InventoryItemData Data { get; private set; }
    public InventorySlotUi Slot { get; private set; }
    public float Durability { get; private set; }
    public float CurrentDurability { get; set; }
    public InputMaster Input { get; private set; }

    public bool Selected { get; set; }
    public bool IsUsing { get; set; }

    protected virtual void Awake()
    {
        Input = new InputMaster();
        Input.Interaction.Click.performed += _ => Use();
    }

    protected virtual void Start()
    {
        CurrentDurability = Durability;
    }

    protected virtual void Update()
    {
        DecreaseDurability();
    }

    protected abstract void Use();

    protected virtual void DecreaseDurability()
    {
        if (!Data.hasDurability) return;
        if (!IsUsing) return;

        CurrentDurability -= Time.deltaTime * Data.durabilityMultiplier;
        Slot.UpdateDurability(CurrentDurability / Durability);

        if (CurrentDurability <= 0)
        {
            OnItemBreak();
        }
    }

    protected virtual void OnItemBreak()
    {
        InventorySystem.Instance.Remove(this);
        Destroy(gameObject);
    }

    public void AddDurability()
    {
        CurrentDurability = Durability;
        Slot.UpdateDurability(CurrentDurability / Durability);
    }

    public void SetItem(InventoryItemData itemData)
    {
        Data = itemData;
        Durability = Data.hasDurability ? Data.maxDurability : 1;
    }

    public void SetSlot(InventorySlotUi slot)
    {
        this.Slot = slot;
    }

    private void OnEnable()
    {
        Input.Interaction.Enable();
    }

    private void OnDisable()
    {
        Input.Interaction.Disable();
    }
}