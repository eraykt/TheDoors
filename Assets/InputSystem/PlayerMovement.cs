using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public InputManager inputManager;   
    public Rigidbody rb;
    public float speed = 10f;
    public float jumpForce = 200f;
    private bool _isGrounded;

    private void Awake()
    {
        inputManager.inputMaster.Movement.Jump.started += _ => Jump();
    }

    void FixedUpdate()
    {
        float forward = inputManager.inputMaster.Movement.Forward.ReadValue<float>() * speed;
        float right = inputManager.inputMaster.Movement.Right.ReadValue<float>() * speed;
        Vector3 move = transform.right * right + transform.forward * forward;
        transform.localScale = new Vector3(x:1,
            y:inputManager.inputMaster.Movement.Crouch.ReadValue<float>() == 0 ? 1f: 0.72618f, z:1);    

        rb.velocity =  new Vector3 (move.x, rb.velocity.y, move.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
    void Jump()
    {
        if(_isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
