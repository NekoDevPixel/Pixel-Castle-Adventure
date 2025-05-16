using System.Collections;
using UnityEngine;

public class TouchAttack : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackDuration = 1f;
    private GameManager gameManager;
    public Animator playeranim;
    private Monster monster;
    public Rigidbody2D playerRb;

    [Header("넉백 사운드")]
    public AudioClip knockbackSound;
    private AudioSource audioSource;

    private bool isattack = false;
    

    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        monster = GetComponent<Monster>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (isattack == true)
        {
            touchAttack();
            
            isattack = false;
        }
    }

    void touchAttack()
    {
        if (monster != null && monster.IsStunned())
            {
                return;
            }
            if (playerRb != null)
            {
                
                Vector2 direction = (playerRb.transform.position - transform.position).normalized;

                // y 성분을 줄이고 x 성분 강조
                direction = new Vector2(Mathf.Sign(direction.x), 0.3f);
                direction.Normalize();
                
                playerRb.linearVelocity = Vector2.zero;
                playerRb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
                StartCoroutine(hitPlayer());
            }
            if (monster != null)
            {
                monster.Stun(knockbackDuration);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(knockbackSound);
            isattack = true;   
        }
    }  

    private IEnumerator hitPlayer()
    {
        playeranim.SetTrigger("hit");
        
        gameManager.Heart -= 1; // 플레이어의 체력 감소
        yield return new WaitForSeconds(playeranim.GetCurrentAnimatorStateInfo(0).length);
        playeranim.SetTrigger("Idle");
    }
    
}
