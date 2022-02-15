using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    [SerializeField] private Image realAimRect;
    [SerializeField] private Image progressImage;

    public void SetAimProgress(float progress)
    {
        progressImage.fillAmount = progress;     
    }

    public bool IsPointInAim(Vector3 point)
    {
        Vector2 screenPoint = Eye.Instance.Camera.WorldToScreenPoint(point);        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent as RectTransform, screenPoint, transform.GetComponentInParent<Canvas>().worldCamera, out Vector2 localPoint);
        return (realAimRect.rectTransform.rect.center - localPoint).magnitude < realAimRect.rectTransform.rect.size.x * 0.5f;
        //return realAimRect.rectTransform.rect.Contains(localPoint);
    }
}
