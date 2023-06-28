using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInput;
    private CharCont playerInputActions;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new CharCont();
        playerInputActions.Enable();
        playerInputActions.Player.Jump.performed += Jump;


    }

    private void FixedUpdate()
    {
        
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        float speed = 15f;

        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
        if (context.performed && isGrounded)
        {
            Debug.Log("Jump!" + context.phase);
            rb.AddForce(Vector3.up * 3f, ForceMode.Impulse);
        }

        /*if(isGrounded)
        {
            Debug.Log("Jump!");
            rb.AddForce(Vector3.up * 2f, ForceMode.Impulse);
        }*/
    }

    public void Movement(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 5f;

        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
