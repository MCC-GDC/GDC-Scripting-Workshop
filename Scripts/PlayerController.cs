using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevelPhysics2D;
public class PlayerController : MonoBehaviour
{
    private InputAction moveAction; // Standard map is WASD
    private InputAction jumpAction; // Standard map is Spacebar
    private Animator Animator;
    private SpriteRenderer Sprite;
    private Rigidbody2D rb;

    public float moveSpeed = 6f;    // Adding a value to a public member sets the default value
    public float maxSpeed = 6f;     // It can still be accessed/changed in the Editor
    public float jumpForce = 150f;  // If you do change it in the editor, it will override the default value

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        Animator = GetComponent<Animator>(); // Animator controller is pre-provided in the Animation folder
        rb = GetComponent<Rigidbody2D>(); // Enables the physics system for the object
        Sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        var moveValue = moveAction.ReadValue<Vector2>(); // Listener for any Move input action

        if (jumpAction.WasPressedThisFrame()) // Listener for any Jump input action
        {                                       // Using this specific function means the jump listener won't repeat if held
            if (!Animator.GetBool("IsJumping"))
            {
                Animator.SetBool("IsJumping", true);
            }
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Terrain"))
        {
            if (Animator.GetBool("IsJumping"))
                Animator.SetBool("IsJumping", false);
        }
    }
}
