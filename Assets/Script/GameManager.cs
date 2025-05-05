using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("현재 코인 수")]
    public int Coin = 0; // 코인 수
    [Header("최대 생명 수")]
    public int MaxHeart = 3; // 최대대 생명 수
    [Header("현재 생명 수")]
    public int Heart = 2; // 생명 수

    public bool EatHeart = false; // 생명 수를 먹었는지 여부

    void Update()
    {
        EHeart();
    }

    void EHeart()
    {
        if (Heart < MaxHeart)
        {
            EatHeart = true; // 생명 수가 최대 생명수보다 적으면 하트를 먹을수 있음
        }
        else
        {
            EatHeart = false; // 생명 수가 최대 생명수보다 많으면 하트를 먹을수 없음
        }
    }

}
