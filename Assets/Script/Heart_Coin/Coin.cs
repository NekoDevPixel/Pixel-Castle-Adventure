using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    private ItemSound itemSound;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        itemSound = GetComponent<ItemSound>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.Coin += 1;
            itemSound.PlaySound(); // 코인 사운드 재생
            Destroy(gameObject);   // 바로 삭제해도 소리는 남음
        }
    }
}
