using UnityEngine;

public class Heart : MonoBehaviour
{
    private GameManager gameManager; // GameManager 스크립트의 인스턴스

    void Start()
    {
        // GameManager 스크립트의 인스턴스를 찾습니다.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(gameManager.EatHeart == true) // 생명 수를 먹을 수 있는지 확인합니다.
            {
                gameManager.Heart += 1; // 생명 수를 증가시킵니다.
                Destroy(this.gameObject);
            }
        }
    }
}
