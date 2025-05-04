using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public class MoveDoor : MonoBehaviour
{
    [Header("플레이어")]
    public GameObject player; // 플레이어 오브젝트

    [Header("현재 맵")]
    public GameObject currentMap; // 현재 맵 오브젝트
    public Transform currentDoorExitPoint; // 현재 문의 "출구" 위치

    [Header("다음 맵")]
    public GameObject nextMap; // 다음 맵 오브젝트
    public Transform nextDoorExitPoint; // 다음 맵 문의 "출구" 위치

    public Animator doorAnimator;
    public Animator playerAnimator;
    public PlayerMove playerController; // 플레이어 이동 스크립트

    private bool isPlayerInTrigger = false;
    private bool isProcessing = false;

    void Start()
    {
        isPlayerInTrigger = false; // 명시적으로 false로 설정
        isProcessing = false;
        doorAnimator = GetComponent<Animator>();

        
    }

    void Update()
    {
    
        if (isPlayerInTrigger && !isProcessing && Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("코루틴 시작!");
            StartCoroutine(EnterDoorRoutine());
        }
        
    }

    IEnumerator EnterDoorRoutine()
    {
        if (doorAnimator == null || playerController == null || nextMap == null)
        {
            Debug.LogError("필요한 컴포넌트가 null입니다!");
            isProcessing = false;
            yield break;
        }

        isProcessing = true;
        playerController.enabled = false;

        // 문이 열리는 애니메이션에 약간의 시간차 추가
        doorAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(0.5f); // 문이 절반 정도 열릴 때까지 대기

        // 플레이어 들어가는 애니메이션 (문이 완전히 열리기 전에 시작하여 자연스럽게)
        playerAnimator.SetTrigger("EnterDoor");
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length); // 플레이어가 문에 들어가는 시간
        player.SetActive(false); // 플레이어 비활성화 (문에 들어가는 애니메이션이 끝난 후)
        // 문 닫기 (플레이어가 완전히 들어가기 전에 살짝 시작)
        doorAnimator.SetTrigger("lockdoor");
        yield return new WaitForSeconds(0.8f);
        // doorAnimator.SetTrigger("Close");
        // 맵 전환
        currentMap.SetActive(false);
        nextMap.SetActive(true);
    
        // 플레이어 위치 이동
        playerController.transform.position = nextDoorExitPoint.position;

        // 카메라 이동
        CinemachineCamera vCam = Object.FindFirstObjectByType<CinemachineCamera>();
        if (vCam != null)
        {
            vCam.transform.position = new Vector3(42f, 0.64f, -10f);
        }

        // 다음 맵 문 열기 (살짝 대기 후)
        yield return new WaitForSeconds(0.3f); // 맵 전환 후 잠시 대기
        Animator nextDoorAnimator = nextDoorExitPoint.GetComponentInChildren<Animator>();
        nextDoorAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(0.5f); // 문이 절반 정도 열릴 때까지 대기
        player.SetActive(true);
        // 플레이어 나오는 애니메이션
        playerAnimator.SetTrigger("isdoor");
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);

        playerAnimator.SetTrigger("ExitDoor");

        doorAnimator.SetTrigger("lockdoor");
        yield return new WaitForSeconds(0.8f);
        // 문 닫기 (플레이어가 완전히 나올 때까지 대기)
        // doorAnimator.SetTrigger("Close");
        // yield return new WaitForSeconds(0.8f);
        playerController.enabled = true;
        isProcessing = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isPlayerInTrigger = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isPlayerInTrigger = false;
    }
}