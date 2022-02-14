using UnityEngine.EventSystems;

public class InputHandler : Singleton<InputHandler>, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public delegate void InputDelegate(PointerEventData eventData);

    public static event InputDelegate OnPointerBeginDrag;
    public static event InputDelegate OnPointerDrag;
    public static event InputDelegate OnPointerEndDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnPointerBeginDrag?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnPointerDrag?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnPointerEndDrag?.Invoke(eventData);
    }

    protected override void Setup()
    {
        
    }
}
