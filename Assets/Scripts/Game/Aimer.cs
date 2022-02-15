using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    [SerializeField] private float startAimingTime = 0.25f;
    [SerializeField] private Gun gun;

    private List<IShootTarget> shootTargets = new List<IShootTarget>();

    private IShootTarget currentShootTarget;
    private float currentAimingTime = 0f;
    private Aim aim;

    private float aimingTime;

    private void Awake()
    {
        aim = UIScreens.Instance.GetScreenElement<GameScreen>().Aim;
    }

    public void AddTarget(IShootTarget shootTarget)
    {
        shootTargets.Add(shootTarget);
    }

    public bool IsTargetsExist => shootTargets.Count > 0;

    private void Update()
    {
        shootTargets.RemoveAll(x => !x.IsActive);
        CheckTargetInAim();        
        
        if(currentShootTarget != null)
        {
            currentAimingTime += Time.deltaTime;
            if (currentAimingTime >= aimingTime)
            {
                ShootTarget();
            }
        }
        UpdateAimProgress();
    }

    private void CheckTargetInAim()
    {
        if (currentShootTarget != null && !currentShootTarget.IsActive)
        {
            LuckyShoot();
        }

        IShootTarget shootTarget = shootTargets.Find(x => aim.IsPointInAim(x.WorldPosition));
        if (shootTarget != null)
        {
            if (currentShootTarget == null) OnTargetInAim(shootTarget);
        }
        else OnLostTarget();
    }

    private void OnTargetInAim(IShootTarget shootTarget)
    {
        currentShootTarget = shootTarget;
        aimingTime = Mathf.CeilToInt(shootTarget.FlyTime) * startAimingTime;
    }

    private void OnLostTarget()
    {
        currentAimingTime = 0;
        currentShootTarget = null;
    }

    private void LuckyShoot()
    {
        if(Random.Range(0f, 1f) <= GetAimingProgress())
        {
            ShootTarget();
        }
        else
        {
            gun.OnShoot();
            OnLostTarget();
        }
    }

    private void ShootTarget()
    {
        gun.OnShoot();
        currentShootTarget.OnHit();
        currentShootTarget = null;
        currentAimingTime = 0;
    }

    private void UpdateAimProgress()
    {       
        aim.SetAimProgress(GetAimingProgress());
    }

    private float GetAimingProgress()
    {
        float progress = 0f;
        if (currentShootTarget != null && aimingTime > 0)
            progress = currentAimingTime / aimingTime;
        return progress;
    }
}
