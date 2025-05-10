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
        if (Heart <= 0)
        {
            GameOver();
        }
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

    // public void TakeDamage(int amount)
    // {
    //     Heart -= amount;
    //     Debug.Log("현재 체력: " + Heart);

    //     if (Heart <= 0)
    //     {
    //         GameOver();
    //     }
    // }

    void GameOver()
    {
        Debug.Log("게임 오버!");
        // 게임 오버 화면으로 전환하거나 다시 시작 가능
        // SceneManager.LoadScene("GameOverScene");
        Time.timeScale = 0f;
    }

}
