using UnityEngine;
using UnityEngine.SceneManagement;

public class StageDead : MonoBehaviour
{
    private GameManager gameManager;
    private int present_Heart = 0;
    private bool isPlayerInZone = false;

    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void FixedUpdate()
    {
        present_Heart = gameManager.Heart;
        if (isPlayerInZone && present_Heart <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInZone = true;
        }
    }
}
