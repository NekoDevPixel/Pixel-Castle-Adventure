using UnityEngine;
using DG.Tweening;

public class DoorWkey : MonoBehaviour
{
    public GameObject doorkey;
    private DOTweenAnimation dooranim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dooranim = doorkey.GetComponent<DOTweenAnimation>();
        doorkey.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorkey.SetActive(true);
            dooranim.DORestart();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dooranim.DOPlayBackwards();
            doorkey.SetActive(false);
        }
        
    }
}
