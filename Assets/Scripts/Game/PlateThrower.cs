using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlateThrower : MonoBehaviour
{
    [SerializeField] private float flyTime = 5f;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float trajectorygHeight;
    [SerializeField] private float endPointRandomization;
    [Space(10)]
    [SerializeField] private GameObject platePrefab;

    public void ThrowPlate()
    {
        Plate plate = Instantiate(platePrefab).GetComponent<Plate>();
        Vector3 anchorPosition = Vector3.Lerp(startPoint.position, endPoint.position, 0.5f) + Vector3.up * trajectorygHeight;
        BezierTrajectory trajectory = new BezierTrajectory(plate.transform, startPoint.position, anchorPosition, endPoint.position);


        DOTween.To(() => trajectory.MoveProgress, (x) => trajectory.Move(x-trajectory.MoveProgress), 1f, flyTime)
            .SetEase(Ease.Linear).OnComplete(() =>
            {

            });
    }

    private void OnDrawGizmos()
    {
        Color c = Gizmos.color;
        Gizmos.color = Color.blue;

        if (startPoint != null && endPoint != null)
        {
            Vector3 anchorPosition = Vector3.Lerp(startPoint.position, endPoint.position, 0.5f) + Vector3.up * trajectorygHeight;
            BezierTrajectory trajectory = new BezierTrajectory(null, startPoint.position, anchorPosition, endPoint.position);

            for (int i = 0; i < 51; i++)
            {
                Gizmos.DrawLine(trajectory.GetPoint(i / 50f), trajectory.GetPoint((i + 1) / 50f));
            }

            Gizmos.DrawWireSphere(endPoint.position, endPointRandomization);
        }

        Gizmos.color = c;
    }
}
