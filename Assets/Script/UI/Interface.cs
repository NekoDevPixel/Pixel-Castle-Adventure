using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public TextMeshProUGUI CoinNumberText; // 코인 수를 표시할 TextMeshProUGUI 컴포넌트
    private GameManager gameManager; // GameManager 인스턴스

    void Start()
    {
        // GameManager 인스턴스 가져오기
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        // 코인 수를 업데이트
        CoinNumberText.text = gameManager.Coin.ToString();
    }
}
