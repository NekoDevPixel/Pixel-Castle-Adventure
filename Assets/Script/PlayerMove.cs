using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject spwnPoint; // 스폰 포인트
    public float speed = 5f; 
    public float jumpForce = 5f; 
    Animator animator; 
    Vector2 move;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    private bool isGrounded;

    
    void Start()
    {
        transform.position = spwnPoint.transform.position; // Set the player's position to the spawn point
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position, 
            groundRadius, 
            groundLayer
        );
        animator.SetBool("jump",!isGrounded); // Set the jump animation based on whether the player is grounded
        rb.linearVelocity = new Vector2(move.x * speed, rb.linearVelocity.y);
        animator.SetFloat("run", Mathf.Abs(move.x));
        CheckLR();
    }

    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>(); 
    }

    void OnJump(InputValue value)
    {
        if(isGrounded){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetBool("jump",true);
        }
    }

    void CheckLR()
    {
        if(move.x > 0)
        {
            rb.transform.localScale = new Vector3(1, 1, 1); // Face right
        }
        else if(move.x < 0)
        {
            rb.transform.localScale = new Vector3(-1, 1, 1); // Face left
        }
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground")) // 지면에 닿았을 때
    //     {
    //         animator.SetBool("jump", false);
    //     }
    // }
}
