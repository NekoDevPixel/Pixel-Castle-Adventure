using TMPro;
using UnityEngine;

public class shadowCoin : MonoBehaviour
{
    public GameObject[] hidensize = new GameObject[3];
    public GameObject[] hidenCoin = new GameObject[3];

    private bool isTag = false;
    private int Tag_p = 0;

    void Awake()
    {
        for (int i = 0; i < hidensize.Length; i++)
        {
            hidenCoin[i].SetActive(false);
        }
    }

    void Update()
    {
        CheckTag();
        Appearance();
    }

    void Appearance()
    {
        if(Tag_p == 1)
        {
            hidenCoin[0].SetActive(true);
        }
        if (Tag_p == 2)
        {
            hidenCoin[1].SetActive(true);
        }
        if (Tag_p == 3)
        {
            hidenCoin[2].SetActive(true);
        }
    }

    void CheckTag()
    {
        if (isTag == true)
        {
            Tag_p += 1;
            isTag = false;
        }
    }   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            isTag = true;
        }
    }

}
