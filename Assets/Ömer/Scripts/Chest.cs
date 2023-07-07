using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject empty;
    [SerializeField] GameObject full;
    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if(Input.anyKeyDown)
            Open();
    }

    void Start()
    {
        int x = Random.Range(0,2);

        if(x == 0)
            empty.SetActive(true);
        else
            full.SetActive(true);
    }

    public void Open()
    {
        animator.SetBool("Opened" , true);
    }
}
