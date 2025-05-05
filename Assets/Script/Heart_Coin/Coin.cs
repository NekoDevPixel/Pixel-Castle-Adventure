using UnityEngine;

public class Coin : MonoBehaviour
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
            
            gameManager.Coin += 1; // 코인 수를 증가시킵니다.
            Destroy(this.gameObject);
        }
    }
}
