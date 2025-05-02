using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f; 
    public float jumpForce = 5f; 
    Animator animator; 
    Vector2 move;
    private bool jumpCheck = true; // Flag to check if the player can jump

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
    }

    void Update()
    {
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
        if(jumpCheck){
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 지면에 닿았을 때
        {
            jumpCheck = true; // 지면에 닿았다고 설정
            animator.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 지면에 닿았을 때
        {
            jumpCheck = false; // 지면과 멀어졌을떄떄
        }
    }
}
