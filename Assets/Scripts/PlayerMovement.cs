using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;

public class NewMonoBehaviourScript : MonoBehaviour
{    
    private float Horizontal;
    public float speed;
    public float jumpForce;
    private bool isFacingRight = true;

    private bool canDash = true;
    public bool isDashing = false;
    public bool invincible = false;
    public float dashPower;
    public float dashTime;
    public float dashCooldown;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    public LayerMask allEnemyLayers;

    public Animator animator;
    public Stats stats;

    public bool grounded;
    public bool wasGrounded;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        stats = GetComponent<Stats>();
        
    }


    void Update()
    {
        if (isDashing)
            return;
        
        Horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));

        if (Input.GetButtonDown("Jump") && grounded)
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
        Invinsibility();
        
    }



    private void FixedUpdate()
    {
       if (isDashing)
            return;
        
        rb.linearVelocity = new Vector2(Horizontal * speed, rb.linearVelocity.y);

        wasGrounded = grounded;
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if(wasGrounded && !grounded)
        {
            animator.SetBool("isJumping", true);
        }

        if(grounded) animator.SetBool("isJumping", false);
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

    private void Invinsibility()
    {
        if (isDashing)
        {
            invincible = true;
            
            
        }

        else return;
    }

}
