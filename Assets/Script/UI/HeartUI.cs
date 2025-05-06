using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    private GameManager gameManager; // GameManager 인스턴스
    private int health; // 플레이어의 체력
    private int maxHealth;
    public GameObject[] hearts;
    
    void Start() {
        // GameManager 인스턴스 가져오기
        gameManager = FindFirstObjectByType<GameManager>();
        
        // 플레이어의 체력 초기화
        health = gameManager.Heart;
        maxHealth = gameManager.MaxHeart;
    }

    void Update() {
        UpdateHeartImages();
    }

    void UpdateHeartImages() {
        // 모든 하트 이미지를 순회하며 체력에 따라 활성화/비활성화
        for (int i = 0; i < hearts.Length; i++) {
            // i가 현재 체력보다 작으면 하트 활성화, 아니면 비활성화
            hearts[i].GetComponent<Image>().enabled = (i < health);
        }
    }

    public void AddHeart(int amount) {
        // 체력 증가 (최대치 이상으로 증가하지 않도록)
        health = Mathf.Min(health + amount, maxHealth);
        
        // 하트 이미지 상태 갱신
        UpdateHeartImages();
    }

    
}
