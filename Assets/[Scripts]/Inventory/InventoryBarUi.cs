using System.Collections.Generic;
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
        ClearInventory();
        DrawInventory();
    }

    private void ClearInventory()
    {
        foreach (var slot in slots)
        {
            Destroy(slot.gameObject);
        }

        slots.Clear();
    }

    private void DrawInventory()
    {
        var inventory = InventorySystem.Instance.inventory;

        for (int i = 0; i < inventory.Count; i++)
        {
            AddInventorySlot(inventory[i], i + 1);
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

    private void AddInventorySlot(InventoryItem item, int index)
    {
        var slot = Instantiate(slotPrefab, transform);
        slot.Set(item, index);

        slots.Add(slot);
    }

    private void SelectSlot(int index)
    {
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