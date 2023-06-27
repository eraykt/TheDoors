using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCanvas : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] bool x;
    private void Update() 
    {
        SetActiveCanvas(x);
    }
    public void SetActiveCanvas(bool active)
    {
        canvas.gameObject.SetActive(active);
    }
}
