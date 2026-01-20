using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevelPhysics2D;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private Animator Animator;
    private SpriteRenderer Sprite;
    private Rigidbody2D rb;

    public float moveSpeed = 1;
    public float maxSpeed = 5;
    public float jumpForce = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //Bind Animator isJumping and isRunning to movement;

        moveSpeed *= 100;
        
        jumpForce *= 100;
    }

    // Update is called once per frame
    void Update()
    {
        var moveValue = moveAction.ReadValue<Vector2>();

        if ( jumpAction.WasPressedThisFrame() || (moveAction.WasPressedThisFrame() && moveValue.y > 0) )
        {
            Animator.SetBool("IsJumping", true);
            rb.AddForceY(jumpForce);
            Debug.Log("Jump");
        }

        

        if(moveValue.x < 0)
        {
            if(rb.totalForce.x + (moveValue.x * moveSpeed) < maxSpeed)
                rb.AddForceX(moveValue.x * moveSpeed);
            else if(rb.totalForce.x > maxSpeed)
                rb.AddForceX(maxSpeed - rb.totalForce.x);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            if (Animator.GetBool("IsJumping"))
                Animator.SetBool("IsJumping", false);
        }
    }
}
