using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public �nputMaster inputMaster;
    void Awake()
    {
        inputMaster = new �nputMaster();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        inputMaster.Enable();   
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }
}
