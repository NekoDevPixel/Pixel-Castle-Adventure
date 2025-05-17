using UnityEngine;

public class ItemSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip coinSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (coinSound != null)
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position); // 이 위치에서 사운드 재생
        }
    }
}
