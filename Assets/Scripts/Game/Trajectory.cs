using UnityEngine;

public abstract class Trajectory
{
    protected float moveProgress = 0;
    public float MoveProgress => moveProgress;
    //protected Transform transform;
    //public Transform Transform => transform;
    protected Vector3 startPoint;
    protected Vector3 endPoint;
    public abstract Vector3 GetPoint(float normilizedDistance);

    public void SetMoveProgress(float moveProgress) { this.moveProgress = moveProgress; }

    //public Trajectory(Transform transform)
    //{
    //    this.transform = transform;
    //}

    public void Move(float amount)
    {
        moveProgress += amount;
        moveProgress = Mathf.Clamp01(moveProgress);
        //transform.position = GetPoint(moveProgress);
    }

    //public void MoveLocal(float amount)
    //{
    //    moveProgress += amount;
    //    moveProgress = Mathf.Clamp01(moveProgress);
    //    transform.localPosition = GetPoint(moveProgress);
    //}
}

public class BezierTrajectory : Trajectory
{
    private Vector3 anchor;

    public BezierTrajectory(Vector3 startPoint, Vector3 anchor, Vector3 endPoint)
    {
        this.startPoint = startPoint;
        this.anchor = anchor;
        this.endPoint = endPoint;
    }

    public override Vector3 GetPoint(float normilizedDistance)
    {
        Vector3 point1 = Vector3.Lerp(startPoint, anchor, normilizedDistance);
        Vector3 point2 = Vector3.Lerp(anchor, endPoint, normilizedDistance);
        return Vector3.Lerp(point1, point2, normilizedDistance);
    }
}

public class LinearTrajectory : Trajectory
{
    public LinearTrajectory(Vector3 startPoint, Vector3 endPoint)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }

    public override Vector3 GetPoint(float normilizedDistance)
    {
        return Vector3.Lerp(startPoint, endPoint, normilizedDistance);
    }
}
