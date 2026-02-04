using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    public float Horizontal;
    public float speed;
    public float jumpForce;
    public bool isFacingRight = true;

    private bool canDash = true;
    public bool isDashing = false;
    public bool invincible = false;
    public float dashPower;
    public float dashTime;
    public float dashCooldown;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    AudioManager audioManager;

    public LayerMask allEnemyLayers;

    public Animator animator;
    public Stats stats;

    public bool grounded;
    public bool wasGrounded;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        //animator = GetComponent<Animator>();
        stats = GetComponent<Stats>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

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


               
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            StartCoroutine(Dash());
        
        Flip();
        Invinsibility();

        if (isDashing)
            animator.SetBool("Dashing", true);
        else
            animator.SetBool("Dashing", false);

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
        yield return new WaitForSeconds(dashTime);
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
            Physics2D.IgnoreLayerCollision(7, 6, true);
            
            
        }

        else
        {
            invincible = false;
            Physics2D.IgnoreLayerCollision(7, 6, false);
        }
    }

    

}
