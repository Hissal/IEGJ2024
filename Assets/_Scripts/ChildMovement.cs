using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMovement : MonoBehaviour
{
    [Header("Jump Variables")]
    public Rigidbody rb;
    public float buttonTime = 0.3f;
    public float jumpAmount;
    float jumpTime;
    bool jumping;

    [Header("Ground Check")]
    public Vector3 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    [Header("Move Variables")]
    [SerializeField] private float Move;
    [SerializeField] private float speed;
    [SerializeField] private float flipSpeed = 0.01f;

    public bool active;
    bool facingRight = true;

    private float XScale;

    private void Awake()
    {
        XScale = transform.localScale.x;
    }

    // Player Movement
    private void Update()
    {
        if (!active) return;

        // Horizontal Movement
        Move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(Move * speed, rb.velocity.y, 0);
        // Vertical Movement
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            jumping = true;
            jumpTime = 0;
        }

        if(jumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpAmount, 0);
            jumpTime += Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }

        if (Move < 0 && facingRight)
        {
            Flip();
        }
        else if (Move > 0 && !facingRight)
        {
            Flip();
        }
    }

    // Ground Check
    public bool isGrounded()
    {
        if(Physics.BoxCast(transform.position, boxSize, -transform.up, Quaternion.identity, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Flip()
    {
        float goalScale = XScale;
        if (facingRight) goalScale = -XScale;

        Vector3 currentScale = gameObject.transform.localScale;
        facingRight = !facingRight;

        StartCoroutine(FlipRoutine(goalScale));

        IEnumerator FlipRoutine(float goalScale)
        {
            float flipDelta = XScale * flipSpeed;

            while (transform.localScale.x > goalScale && !facingRight || transform.localScale.x < goalScale && facingRight)
            {
                if (goalScale > currentScale.x)
                {
                    currentScale.x += flipDelta;
                }
                else
                {
                    currentScale.x -= flipDelta;
                }

                gameObject.transform.localScale = currentScale;
                yield return null;
            }
            currentScale.x = goalScale;
            gameObject.transform.localScale = currentScale;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
}
