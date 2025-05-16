using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeCanvas : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime = 0.5f;

    public void FadeOut(System.Action onComplete = null)
    {
        fadeImage.raycastTarget = true;
        fadeImage.DOFade(1f, fadeTime).OnComplete(() => onComplete?.Invoke());
    }

    public void FadeIn(System.Action onComplete = null)
    {
        fadeImage.DOFade(0f, fadeTime).OnComplete(() =>
        {
            fadeImage.raycastTarget = false;
            onComplete?.Invoke();
        });
    }
}
