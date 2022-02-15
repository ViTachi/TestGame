using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;


    private void Update()
    {
        transform.localRotation = Quaternion.Euler(transform.eulerAngles.x,
            transform.eulerAngles.y + rotationSpeed * Time.deltaTime, transform.eulerAngles.z);
    }

    

    public void Explode()
    {

    }
}
