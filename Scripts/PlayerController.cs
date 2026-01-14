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

        //Bind Animator isJumping and isRunning to movement;


    }

    // Update is called once per frame
    void Update()
    {
        if ( jumpAction.WasPressedThisFrame() )
        {
            Animator.SetBool("IsJumping", true);
        }

        var moveValue = moveAction.ReadValue<Vector2>();

        if(moveValue.x < 0)
        {
            if(rb.totalForce.x + (moveValue.x * moveSpeed) < maxSpeed)
                rb.AddForceX(moveValue.x * moveSpeed);
            else if(rb.totalForce.x > maxSpeed)
                rb.AddForceX(maxSpeed - rb.totalForce.x);
        }
    }

}
