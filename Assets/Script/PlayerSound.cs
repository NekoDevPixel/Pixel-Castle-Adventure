using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [Header("Player Sound")]
    AudioSource audioSource;
    public AudioClip runsound;
    public AudioClip jumpsound;
    private PlayerMove playerMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMove = GetComponent<PlayerMove>();
    }

    public void PlayFootstepSound()
    {
        // if (playerMove.isGrounded)
        // {

        // }
        audioSource.PlayOneShot(runsound);
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpsound);
    }
}
