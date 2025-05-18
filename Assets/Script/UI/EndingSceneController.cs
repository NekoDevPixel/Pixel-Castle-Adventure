using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class EndingSceneController : MonoBehaviour
{
    public TextMeshProUGUI endText;
    public TextMeshProUGUI thankYouText;
    public TextMeshProUGUI countdownText;
    public GameObject inter;

    private void Start()
    {
        
        thankYouText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
    }

    public void StartEndingSequence()
    {
        StartCoroutine(PlayEndingSequence());
    }

    IEnumerator PlayEndingSequence()
    {
        inter.gameObject.SetActive(false);
        string endWord = "END";
        endText.text = "";
        yield return new WaitForSeconds(1f);
        foreach (char c in endWord)
        {
            endText.text += c + " ";
            yield return new WaitForSeconds(1f); // 글자 간 딜레이
        }
        endText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f); // END 표시 후 잠깐 대기

        thankYouText.gameObject.SetActive(true);
        thankYouText.DOFade(0, 0); // 처음엔 투명
        thankYouText.DOFade(1, 1f); // 1초간 페이드인

        yield return new WaitForSeconds(2f); // 메시지를 잠깐 보여줌
        thankYouText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        countdownText.gameObject.SetActive(true);
        for (int i = 5; i >= 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        countdownText.gameObject.SetActive(false);
        // 메인 메뉴 씬으로 이동 (씬 이름은 원하는 걸로 바꾸세요)
        SceneManager.LoadScene("MenuScreen");
    }
}
