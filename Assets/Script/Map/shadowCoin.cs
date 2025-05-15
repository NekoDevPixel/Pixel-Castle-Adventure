using TMPro;
using UnityEngine;

public class shadowCoin : MonoBehaviour
{
    public GameObject hidenCoin;

    private bool isTag = false;

    void Start()
    {
        hidenCoin.SetActive(false);
    }

    void Update()
    {
        CheckTag();
    }

    void CheckTag()
    {
        if(isTag)
        {
            hidenCoin.SetActive(true);
            isTag = false; // 태그가 감지되면 true로 설정
        }
    }   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log("충돌 감지: " + collision.gameObject.name + ", 태그: " + collision.tag);
            isTag = true;
        }
    }
}
