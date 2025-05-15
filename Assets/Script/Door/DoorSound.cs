using UnityEngine;

public class DoorSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip open;
    public AudioClip close;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OpenDoor()
    {
        audioSource.PlayOneShot(open);
    }

    public void CloseDoor()
    {
        audioSource.PlayOneShot(close);
    }
}
