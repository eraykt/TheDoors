using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rbody;
    public float maxSpeed = 5f;

    private void Awake()
    {
        
    }
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speedd", rbody.velocity.magnitude / maxSpeed);
    }
}
