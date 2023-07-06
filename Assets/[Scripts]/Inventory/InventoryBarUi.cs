using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryBarUi : MonoBehaviour
{
    [SerializeField] private InventorySlotUi slotPrefab;
    private InputMaster input;

    private List<InventorySlotUi> slots = new List<InventorySlotUi>();
    private int selectedSlot = -1;

    private void Awake()
    {
        input = new InputMaster();
        SetKeys();
    }

    private void OnEnable()
    {
        InventorySystem.Instance.OnInventoryUpdated += InventoryUpdate;
        input.Inventory.Enable();
    }

    private void OnDisable()
    {
        InventorySystem.Instance.OnInventoryUpdated -= InventoryUpdate;
        input.Inventory.Disable();
    }

    private void InventoryUpdate()
    {
        DrawInventory();
        SetSlotIds();
    }

    private void DrawInventory()
    {
        var inventory = InventorySystem.Instance.inventory;

        foreach (var item in inventory)
        {
            AddInventorySlot(item);
        }

        if (selectedSlot != -1 && selectedSlot < slots.Count)
        {
            SelectSlot(selectedSlot);
        }
        else if (slots.Count > 0)
        {
            SelectSlot(0);
        }
    }

    private void SetSlotIds()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].SetId(i + 1);
        }
    }

    private void AddInventorySlot(InventoryItem item)
    {
        var addedItem = InventorySystem.Instance.Get(item);
        if(addedItem == null) return;
        if (addedItem.Slot == null) return;

        var slot = Instantiate(slotPrefab, transform);
        slot.Set(item);

        slots.Add(slot);
        InventorySystem.Instance.UpdateInventory(item, slot);
    }

    private void SelectSlot(int index)
    {
        if (index >= slots.Count) return;

        if (selectedSlot >= 0 && selectedSlot < slots.Count)
        {
            slots[selectedSlot].Deselect();
        }

        slots[index].Select();
        selectedSlot = index;
    }

    private void SetKeys()
    {
        input.Inventory.Inventory1.performed += _ => SelectSlot(0);
        input.Inventory.Inventory2.performed += _ => SelectSlot(1);
        input.Inventory.Inventory3.performed += _ => SelectSlot(2);
        input.Inventory.Inventory4.performed += _ => SelectSlot(3);
        input.Inventory.Inventory5.performed += _ => SelectSlot(4);
    }
}