using System.Collections;
using UnityEngine;

public class DoorEntrySequence : MonoBehaviour
{
    public Animator doorAnimator;
    public Animator playerAnimator;
    public PlayerMove playerController;

    private bool hasExecuted = false;

    void Start()
    {
        
    }

    public void TriggerExitSequence()
    {
        if (!hasExecuted)
        {
            hasExecuted = true;
            StartCoroutine(ExitDoorRoutine());
        }
    }

    IEnumerator ExitDoorRoutine()
    {
        playerController.enabled = false;

        // 문 열기
        doorAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(1f);

        // 플레이어 나오는 애니메이션
        playerAnimator.SetTrigger("ExitDoor");
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);

        doorAnimator.SetTrigger("Close");
        yield return new WaitForSeconds(1f);

        playerController.enabled = true;
    }
}
