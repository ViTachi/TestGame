using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform aim;
    [SerializeField] private List<PlateThrower> plateThrowers;

    private GameScreen gameScreen;
    private bool isLaunched = false;


    private void Update()
    {
        if (!isLaunched) return;

        if (gameScreen.Aim.IsPointInAim(aim.position)) gameScreen.Aim.SetAimProgress(1);
        else gameScreen.Aim.SetAimProgress(0);
    }

    public void Initialize()
    {
        gameScreen = UIScreens.Instance.GetScreenElement<GameScreen>();
        gameScreen.ThrowButton.onClick.AddListener(OnThrowButtonClick);
    }

    public void Launch()
    {
        isLaunched = true;
        
        gameScreen.Show();
        gameScreen.SetIsThrowButtonActive(true);        
    }

    private void OnThrowButtonClick()
    {
        plateThrowers[Random.Range(0, plateThrowers.Count)].ThrowPlate();
        gameScreen.SetIsThrowButtonActive(false);
    }
}
