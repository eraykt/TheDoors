using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private Camera cam;
    private Ray ray;
    private RaycastHit hit;

    public float interactDistance = 5f;

    public Transform targetedObject;

    private InputMaster input;

    private void Awake()
    {
        cam = Camera.main;
        input = new InputMaster();

        input.Interaction.Interact.performed += _ => InteractWithCollectable();
    }

    private void Update()
    {
        InteractWithInteractable();
    }

    private void InteractWithInteractable()
    {
        ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (!Physics.Raycast(ray, out hit, interactDistance)) return;
        if (targetedObject == hit.transform) return;

        if (targetedObject != null)
        {
            // we are looking at a new object and we need to de-interact with the old one
            if (targetedObject.TryGetComponent<IInteractable>(out var oldInteractable))
                oldInteractable.DeInteraction();
        }

        targetedObject = hit.transform;

        if (targetedObject.TryGetComponent<IInteractable>(out var interactable))
        {
            // we are looking at an interactable object
            interactable.Interaction();
        }
    }

    private void InteractWithCollectable()
    {
        if (!targetedObject.TryGetComponent<ICollectable>(out var collectable)) return;

        collectable.Collect();

        Debug.Log($"You added {targetedObject.name} to your inventory");
    }

    private void OnEnable()
    {
        input.Interaction.Enable();
    }

    private void OnDisable()
    {
        input.Interaction.Disable();
    }
}