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
    private Animator _animator;
    [SerializeField] private AudioSource _jumpSound;
    private AudioSource _audioSource;
    private void Awake()
    {
        inputManager.inputMaster.Movement.Jump.started += _ => Jump();
        _animator = this.GetComponent<Animator>();
        _audioSource = this.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float forward = inputManager.inputMaster.Movement.Forward.ReadValue<float>() * speed;
        float right = inputManager.inputMaster.Movement.Right.ReadValue<float>() * speed;
        Vector3 move = transform.right * right + transform.forward * forward;
        transform.localScale = new Vector3(x:.6f,
            y:inputManager.inputMaster.Movement.Crouch.ReadValue<float>() == 0 ? .6f: 0.4f, z:.6f);    

        rb.velocity =  new Vector3 (move.x, rb.velocity.y, move.z);
        if (forward != 0 || right != 0)
        {
            if (_isGrounded)
            {
                _audioSource.mute = false;
            }
            else
            {
                _audioSource.mute = true;
            }
        }
        else
        {
            _audioSource.mute = true;
            Debug.Log("artýk");
        }
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
            _animator.SetTrigger("isJump");
            rb.AddForce(Vector3.up * jumpForce);
            _jumpSound.Play();
        }
    }
}
