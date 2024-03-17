using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerMovement : MonoBehaviour
{


    private float horizontal;
    private Vector2 MovementDirection;
    private float vertical;
    private float speed;
    public float jumpingPower = 5f;
    public bool isMovingX = false;
    public bool isMovingY = false;
    public float baseSpeed;
 

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");






        Animate();
    }

    private void FixedUpdate()
    {
        if (horizontal > 0 || horizontal < 0)
        {
            isMovingX = true;
        }
        else
        {
            isMovingX = false;
        }
        if (vertical > 0 || vertical < 0)
        {
            isMovingY = true;
        }
        else
        {
            isMovingY = false;
        }

        MovementDirection = new Vector2(horizontal* Time.deltaTime, vertical* Time.deltaTime);
        speed = Mathf.Clamp(MovementDirection.magnitude, 0.0f, 1.0f);
        MovementDirection.Normalize();
        rb.velocity = MovementDirection * speed * baseSpeed;

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Animate()
    {

        if (rb.velocity != Vector2.zero) 
        {
            animator.SetFloat("Horizontal", rb.velocity.x);
            animator.SetFloat("Vertical", rb.velocity.y);
        }
        animator.SetFloat("Speed", speed);

    }
}