using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction = 0;
    public Rigidbody2D playerRB;
    public float speed = 400, jumpForce = 5, crouchSpeed;
    bool isGrounded;
    int numberOfJumps = 0;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Animator animator;

    bool isFacingRight;
    bool isCrouching=false;

    public void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction =  ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx =>Jump();
        controls.Land.Crouch.performed += ctx => Crouch();
    }
  

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (isCrouching)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = true;
            playerRB.linearVelocity = new Vector2(direction * (speed / 2) * Time.fixedDeltaTime, playerRB.linearVelocity.y);
        }
        else
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = false;
            playerRB.linearVelocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.linearVelocity.y);
        }
        animator.SetFloat("speed", Mathf.Abs(direction));
        animator.SetBool("IsCrouching", isCrouching);


        if (!isFacingRight && direction < 0 || isFacingRight && direction > 0)
            Flip();

        animator.SetBool("isJumping", isGrounded);

    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    void Jump()
    {
        if (isGrounded)
        playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jumpForce);
    }
    void Crouch()
    {   

        if (isGrounded)
        {

            if (isCrouching)
            {
                isCrouching = false;
            }
            else
            {
                isCrouching = true;
            }

        }
        else
        {
            if (isCrouching)
            {
                isCrouching = false;
            }
            else
            {
                isCrouching = true;
            }
        }

      
    }




}


