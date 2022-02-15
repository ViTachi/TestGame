using DG.Tweening;
using UnityEngine;

public class Plate : MonoBehaviour, IShootTarget
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject explosionFx;

    public Vector3 WorldPosition => transform.position;

    public float FlyTime => flyTrajectory != null ? flyTrajectory.MoveProgress * fullFlyTime : 0;

    public bool IsActive => gameObject.activeSelf;

    private Trajectory flyTrajectory = null;
    private Tweener flyTweener = null;
    private float fullFlyTime = 0;

    private void Update()
    {
        transform.localRotation = Quaternion.Euler(transform.eulerAngles.x,
            transform.eulerAngles.y + rotationSpeed * Time.deltaTime, transform.eulerAngles.z);
    }

    public void LaunchFly(Trajectory trajectory, float flyTime)
    {
        fullFlyTime = flyTime;
        flyTrajectory = trajectory;
        flyTweener = DOTween.To(() => flyTrajectory.MoveProgress,
            (x) =>
            {
                flyTrajectory.Move(x - flyTrajectory.MoveProgress);
                transform.position = flyTrajectory.GetPoint(flyTrajectory.MoveProgress);
            }, 1f, flyTime)
           .SetEase(Ease.Linear).OnComplete(() =>
           {
               gameObject.SetActive(false);
           });
        
    }

    public void Explode()
    {
        flyTweener?.Kill();
        Instantiate(explosionFx, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void OnHit()
    {
        Explode();
    }
}
