using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class LoadingCurtain : MonoBehaviour
{
    [Range(0.001f, 1f)]
    [SerializeField] private float _fadeStep = 2f;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.alpha = 1f;
    }

    public void Hide()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        while (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= _fadeStep * Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}