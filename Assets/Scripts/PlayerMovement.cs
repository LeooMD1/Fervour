using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{    
    private float Horizontal;
    public float speed;
    public float jumpForce;
    private bool isFacingRight = true;

    private bool canDash = true;
    public bool isDashing = false;
    public float dashPower;
    public float dashTime;
    public float dashCooldown;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;


    // Update is called once per frame
    void Update()
    {
        if (isDashing)
            return;
        
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

               
        if (Input.GetKeyDown(KeyCode.LeftControl) && canDash)
            StartCoroutine(Dash());
        
        Flip();
    }

    private void FixedUpdate()
    {
       if (isDashing)
            return;
        
        rb.linearVelocity = new Vector2(Horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && Horizontal < 0f || !isFacingRight && Horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }


}
