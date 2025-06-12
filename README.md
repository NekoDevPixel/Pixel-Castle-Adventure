# 💎 Pixel Castle Adventure

다이아몬드를 모으며 스테이지를 클리어하는 액션 어드벤처 게임

---

## 🕹️ 소개

**Diamond Run**은 플레이어가 주인공이 되어  
다양한 스테이지에서 다이아몬드를 수집하고,  
장애물을 극복하며 목표를 달성하는 액션 어드벤처 게임입니다.

각 스테이지마다 독특한 도전과 퍼즐이 준비되어 있어  
**수집**과 **클리어**의 재미를 동시에 느낄 수 있습니다.

---

## 🌟 주요 특징

- 💎 **다이아몬드 수집**  
  각 스테이지마다 숨겨진 다이아몬드를 찾아 모으세요.

- 🚩 **스테이지 클리어**  
  장애물을 피하고 퍼즐을 풀며 스테이지를 완수하세요.

- 🎯 **점점 어려워지는 난이도**  
  스테이지가 진행될수록 난이도와 퍼즐이 다양해집니다.

- 🛠️ **C# 기반 개발**  
  Unity 엔진을 활용한 C# 프로젝트입니다.

---


## 🔧 주요 코드
## 🚪 문을 통한 맵 전환 시스템

플레이어가 문에 접근해 `W` 키를 누르면, 애니메이션 및 페이드 효과와 함께  
현재 맵에서 다음 맵으로 부드럽게 전환되는 기능을 담당하는 시스템입니다.

### 🧠 동작 흐름 요약

- 문 근처에서 `W` 키 입력 → 문 열림 + 진입 애니메이션
- 화면 페이드 아웃 후 맵 교체
- 다음 맵 문에서 등장 애니메이션 → 문 닫힘
- 컨트롤 복구

### 🧩 주요 코드 요약

```csharp
// Update()
if (isPlayerInTrigger && !isProcessing && Input.GetKeyDown(KeyCode.W))
{
    StartCoroutine(EnterDoorRoutine());
}

IEnumerator EnterDoorRoutine()
{
    isProcessing = true;
    playerController.enabled = false;

    // 문 열기 및 플레이어 진입
    doorAnimator.SetTrigger("Open");
    playerAnimator.SetTrigger("EnterDoor");
    yield return new WaitForSeconds(...);

    // 페이드 아웃 → 맵 전환
    fadeCanvas.FadeOut(...);
    currentMap.SetActive(false);
    nextMap.SetActive(true);
    player.transform.position = nextDoorExitPoint.position;

    // 카메라 위치 조정
    AdjustCamera();

    // 다음 맵 문 애니메이션 및 등장 처리
    playerAnimator.SetTrigger("ExitDoor");
    fadeCanvas.FadeIn(...);

    playerController.enabled = true;
    isProcessing = false;
}
```

## 🎮 지금 플레이하기

완성된 **Pixel Castle Adventure**를 지금 바로 브라우저에서 플레이해보세요!  
👉 [게임 플레이하러 가기](https://play.unity.com/en/games/d065d92d-699c-4235-b8db-600a5359a29b/pixel-castle-adventure)

---

## 📦 사용한 에셋

- [Kings and Pigs by Pixel Frog](https://pixelfrog-assets.itch.io/kings-and-pigs)  
  (게임 내 그래픽 및 스프라이트)

- [m6x11 Bitmap Font by managore](https://managore.itch.io/m6x11)  
  (픽셀 폰트)

- [DOTween Pro (Unity Asset Store)](https://assetstore.unity.com/packages/tools/visual-scripting/dotween-pro-32416?locale=ko-KR)  
  (애니메이션 및 트윈 효과)

- [Hints Stars Points & Rewards Sound Effects - Lite Pack(Unity Asset Store)](https://assetstore.unity.com/packages/audio/sound-fx/hints-stars-points-rewards-sound-effects-lite-pack-295538)
  <br>(사운드)
- [8Bit Music - 062022 (Unity Asset Store)](https://assetstore.unity.com/packages/audio/music/8bit-music-062022-225623)
  <br>(사운드)
- [Footsteps - Essentials (Unity Asset Store)](https://assetstore.unity.com/packages/audio/sound-fx/foley/footsteps-essentials-189879)
  <br>(사운드)

## 🎬 게임플레이 미리보기

![Diamond Run Gameplay](./explay/Ex_play.gif)

---

## ✍ 개발 소감

짧은 시간 내에 정말 간단하게 어드벤처 게임을 개발해보며 **기획**, 그에 맞는 **에셋 선정**, 그리고 앞에서 소개된 **코루틴 기반의 로직**에 대해 실제로 적용하고 이해할 수 있는 의미 있는 경험이었습니다.

아쉬웠던 점은 다음과 같습니다:

- 스테이지의 개수가 적었던 점
- 전체적인 디자인의 단조로움
- 스테이지 내 몬스터의 다양한 공격 방식 구현 부족

하지만 이번 프로젝트를 통해 얻은 경험을 바탕으로, **향후 어드벤처 게임 장르를 개발할 때**는 다음과 같은 개선점을 도입해 더 재미있는 게임을 만들어보고자 합니다:

- 다양한 스테이지 구성
- 몬스터 AI의 공격 패턴 다양화
- 스토리 라인을 추가하여 몰입감 있는 게임 플레이 제공

이번 프로젝트는 단순한 구현을 넘어 게임 개발의 전체적인 흐름을 직접 경험해볼 수 있었던 소중한 기회였습니다.<br>
또한 **바이브코딩을 통해 실시간 피드백과 코드 리뷰를 받으며**  
개발 중 막히는 부분을 빠르게 해결하고, 구조적인 코드 작성법을 익힐 수 있었습니다.



