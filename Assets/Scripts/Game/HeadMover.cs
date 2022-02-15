using UnityEngine;
using UnityEngine.EventSystems;

public class HeadMover : MonoBehaviour
{
    [SerializeField] private float yRotationRange;
    [SerializeField] private float xRotationRange;
    [SerializeField] private float horizontalSensitivity;
    [SerializeField] private float verticalSensitivity;
    [SerializeField] private float smooth = 10f;

    [SerializeField] private Transform aim;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private Quaternion targetRotation;

    private void OnEnable()
    {
        InputHandler.OnPointerDrag += OnPointerDrag;
    }

    private void OnDisable()
    {
        InputHandler.OnPointerDrag -= OnPointerDrag;
    }

    private void Awake()
    {
        targetRotation = transform.localRotation;
    }

    private void OnPointerDrag(PointerEventData eventData)
    {
        xRotation -= eventData.delta.y * verticalSensitivity;
        xRotation = Mathf.Clamp(xRotation, -xRotationRange * 0.5f, xRotationRange * 0.5f);
        yRotation += eventData.delta.x * horizontalSensitivity;
        yRotation = Mathf.Clamp(yRotation, -yRotationRange * 0.5f, yRotationRange * 0.5f);
        targetRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

        //Ray ray = new Ray(transform.position, aim.position - transform.position);
    }
}
