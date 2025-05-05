using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

/// <summary>
/// 문을 통해 플레이어가 다른 맵으로 이동하는 기능을 관리하는 클래스
/// </summary>
public class MoveDoor : MonoBehaviour
{
    [Header("플레이어 관련")]
    public GameObject player;                 // 플레이어 오브젝트
    public Animator playerAnimator;           // 플레이어 애니메이터
    public PlayerMove playerController;       // 플레이어 이동 제어 스크립트

    [Header("현재 맵 설정")]
    public GameObject currentMap;             // 현재 맵 오브젝트
    public Transform currentDoorExitPoint;    // 현재 문의 출구 위치
    public Animator doorAnimator;             // 현재 문의 애니메이터

    [Header("다음 맵 설정")]
    public GameObject nextMap;                // 다음 맵 오브젝트
    public Transform nextDoorExitPoint;       // 다음 맵 문의 출구 위치

    // 상태 변수
    private bool isPlayerInTrigger = false;   // 플레이어가 트리거 영역 안에 있는지 여부
    private bool isProcessing = false;        // 맵 이동 처리 중인지 여부

    /// <summary>
    /// 초기화
    /// </summary>
    void Start()
    {
        // 상태 초기화
        isPlayerInTrigger = false;
        isProcessing = false;
        
        // 현재 문의 애니메이터 컴포넌트 가져오기
        doorAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// 매 프레임 업데이트
    /// </summary>
    void Update()
    {
        // 플레이어가 트리거 영역 안에 있고, 현재 처리 중이 아니며, W 키를 눌렀을 때
        if (isPlayerInTrigger && !isProcessing && Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("문 이동 시작!");
            StartCoroutine(EnterDoorRoutine());
        }
    }

    /// <summary>
    /// 문 진입 및 맵 이동 프로세스를 처리하는 코루틴
    /// </summary>
    IEnumerator EnterDoorRoutine()
    {
        // 필요한 컴포넌트 유효성 검사
        if (doorAnimator == null || playerController == null || nextMap == null)
        {
            Debug.LogError("문 이동에 필요한 컴포넌트가 누락되었습니다!");
            isProcessing = false;
            yield break;
        }

        // 처리 시작 및 플레이어 컨트롤 비활성화
        isProcessing = true;
        playerController.enabled = false;

        // ===== 1단계: 현재 맵의 문 열기 및 플레이어 진입 =====
        doorAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(0.5f);  // 문이 절반 정도 열릴 때까지 대기

        // 플레이어 문 진입 애니메이션 재생
        playerAnimator.SetTrigger("EnterDoor");
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);
        
        // 플레이어가 문 안으로 들어가는 효과
        player.GetComponent<Renderer>().enabled = false;
        
        // 현재 맵의 문 닫기
        doorAnimator.SetTrigger("lockdoor");
        yield return new WaitForSeconds(0.8f);

        // ===== 2단계: 맵 전환 =====
        // 현재 맵 비활성화 및 다음 맵 활성화
        currentMap.SetActive(false);
        nextMap.SetActive(true);
    
        // 플레이어 위치를 다음 맵의 출구 지점으로 이동
        playerController.transform.position = nextDoorExitPoint.position;

        // 카메라 위치 조정
        AdjustCamera();

        // ===== 3단계: 다음 맵에서 플레이어 퇴장 =====
        yield return new WaitForSeconds(0.3f);  // 맵 전환 후 잠시 대기
        
        // 다음 맵의 문 열기
        Animator nextDoorAnimator = nextDoorExitPoint.GetComponentInChildren<Animator>();
        nextDoorAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(0.5f);  // 문이 절반 정도 열릴 때까지 대기
        
        // 플레이어 렌더러 다시 활성화
        player.GetComponent<Renderer>().enabled = true;
        
        // 플레이어 문 퇴장 애니메이션 재생
        playerAnimator.SetTrigger("isdoor");
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);
        playerAnimator.SetTrigger("ExitDoor");

        // 다음 맵의 문 닫기
        nextDoorAnimator.SetTrigger("lockdoor");
        yield return new WaitForSeconds(0.8f);
        
        // ===== 4단계: 정리 및 완료 =====
        // 플레이어 컨트롤 다시 활성화
        playerController.enabled = true;
        isProcessing = false;
    }

    /// <summary>
    /// 맵 전환 시 카메라 위치 조정
    /// </summary>
    private void AdjustCamera()
    {
        CinemachineCamera vCam = Object.FindFirstObjectByType<CinemachineCamera>();
        if (vCam != null)
        {
            vCam.transform.position = new Vector3(42f, 0.64f, -10f);
        }
        else
        {
            Debug.LogWarning("Cinemachine 카메라를 찾을 수 없습니다!");
        }
    }

    /// <summary>
    /// 플레이어가 트리거 영역에 들어왔을 때 호출
    /// </summary>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isPlayerInTrigger = true;
    }

    /// <summary>
    /// 플레이어가 트리거 영역에서 나갔을 때 호출
    /// </summary>
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isPlayerInTrigger = false;
    }
}
