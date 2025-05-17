using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public EndingSceneController endingController; // END 연출 담당 스크립트

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            endingController.StartEndingSequence();
        }
    }
}
