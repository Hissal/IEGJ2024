using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Jump Variables")]
    public Rigidbody2D rb;
    public float buttonTime = 0.3f;
    public float jumpAmount;
    float jumpTime;
    bool jumping;

    [Header("Ground Check")]
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    [Header("Move Variables")]
    [SerializeField] private float Move;
    [SerializeField] private float speed;
    
    // Player Movement
    private void Update()
    {
        // Horizontal Movement
        Move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);
        // Vertical Movement
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            jumping = true;
            jumpTime = 0;
        }

        if(jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }
    }

    // Ground Check
    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
}
