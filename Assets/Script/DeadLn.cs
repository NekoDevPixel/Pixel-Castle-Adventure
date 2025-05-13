using UnityEngine;

public class DeadLn : MonoBehaviour
{
    public GameObject player;
    public GameObject telPoint;
    private GameManager gameManager;

    private bool isdeadzone = false;
    private int present_Heart = 0;

    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
            
    }

    void FixedUpdate()
    {
        present_Heart = gameManager.Heart;
        deadzone();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isdeadzone = true;
        }
    }

    void deadzone()
    {
        if(isdeadzone == true && present_Heart >= 1)
        {
            gameManager.Heart -= 1;
            player.transform.position = telPoint.transform.position;
            isdeadzone = false;
        }
    }
}
