using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOutline : MonoBehaviour
{
    [SerializeField] Outline outline;
    [SerializeField] bool x;
    private void Update() 
    {
        SetOutline(x);
    }
    public void SetOutline(bool active)
    {
        outline.enabled = active;
    }
}
