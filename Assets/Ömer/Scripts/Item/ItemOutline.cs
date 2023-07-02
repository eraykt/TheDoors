using UnityEngine;

public class ItemOutline : MonoBehaviour
{
    [SerializeField] Outline outline;

    private void Start()
    {
        SetOutline(false);
    }

    public void SetOutline(bool active)
    {
        outline.enabled = active;
    }
}
