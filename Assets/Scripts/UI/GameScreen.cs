using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour, IScreenElement
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Aim aim;
    public Aim Aim => aim;
    [SerializeField] private Button throwButton;
    public Button ThrowButton => throwButton;

    private Tweener fadeTweener = null;

    public void Hide(bool immediately = false)
    {
        if (immediately)
        {
            gameObject.SetActive(false);
        }
        else
        {
            fadeTweener?.Kill();
            fadeTweener = canvasGroup.DOFade(0, 0.3f).OnComplete(() => gameObject.SetActive(false));
        }
    }

    public void Show(bool immediately = false)
    {
        gameObject.SetActive(true);
        if (immediately)
        {
            canvasGroup.alpha = 1;
        }
        else
        {
            fadeTweener?.Kill();
            fadeTweener = canvasGroup.DOFade(1, 0.3f);
        }
    }

    public void SetIsThrowButtonActive(bool isActive)
    {
        throwButton.interactable = isActive;
        throwButton.transform.DOScale(isActive ? 1 : 0, 0.3f);
    }
}
