using UnityEngine;

public class DeadLn : MonoBehaviour
{
    public GameObject player;
    public GameObject telPoint;
    private GameManager gameManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager = FindFirstObjectByType<GameManager>();
            gameManager.Heart -= 1;
            player.transform.position = telPoint.transform.position;
        }
    }
}
