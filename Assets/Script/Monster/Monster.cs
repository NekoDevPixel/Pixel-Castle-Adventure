using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2.2f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool playerInRange = false;
    private Animator animator;
    
    private bool isStunned = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
            
        // 감지용 콜라이더 추가 (코드로 추가하거나 Unity 에디터에서 추가)
        CircleCollider2D detectionCollider = gameObject.AddComponent<CircleCollider2D>();
        detectionCollider.radius = 2f;
        detectionCollider.isTrigger = true;
    }
    
    void Update()
    {
        if (isStunned)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetFloat("run", 0f); // 멈추는 애니메이션 처리
            return;
        }

        if (playerInRange)
        {
            // 플레이어의 X 위치만 추적 (Y는 무시)
            float xDirection = player.position.x - transform.position.x;
            float directionSign = Mathf.Sign(xDirection);
            
            // 스프라이트 플립 (왼쪽/오른쪽 방향)
            if (directionSign > 0)
                spriteRenderer.flipX = true;
            else if (directionSign < 0)
                spriteRenderer.flipX = false;
            
            // X축으로만 이동 (Y축 이동은 0으로 설정)
            rb.linearVelocity = new Vector2(directionSign * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // 플레이어가 범위 내에 없으면 정지
        }
        animator.SetFloat("run", Mathf.Abs(rb.linearVelocity.magnitude)); // 애니메이션 속도 설정
    }
    
    // 플레이어 감지
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            
        }
    }
    
    // 플레이어가 범위를 벗어남
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            
        }
    }

    public void Stun(float duration)
    {
        StartCoroutine(StunCoroutine(duration));
    }

    private IEnumerator StunCoroutine(float duration)
    {
        isStunned = true;
        yield return new WaitForSeconds(duration);
        isStunned = false;
    }

    public bool IsStunned()
    {
        return isStunned;
    }
}
