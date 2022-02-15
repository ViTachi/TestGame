using UnityEngine;

public class Eye : Singleton<Eye>
{
    public Camera Camera => GetComponent<Camera>();

    protected override void Setup()
    {
        
    }
}
