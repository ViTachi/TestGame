using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem shootFx;

    public void OnShoot()
    {
        shootFx?.Play();
    }
}
