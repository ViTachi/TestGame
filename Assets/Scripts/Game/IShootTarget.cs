using UnityEngine;

public interface IShootTarget
{
    bool IsActive { get; }
    Vector3 WorldPosition { get; }
    void OnHit();
    float FlyTime { get; }
}
