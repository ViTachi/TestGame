using UnityEngine;

public class Runtime : Singleton<Runtime>
{
    [SerializeField] private Player player;

    protected override void Setup()
    {
        RunGame();
    }

    private void RunGame()
    {
        player.Initialize();
        player.Launch();
    }
}
