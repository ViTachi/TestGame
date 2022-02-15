using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Aimer aimer;
    [SerializeField] private List<PlateThrower> plateThrowers;

    private GameScreen gameScreen;
    private bool isLaunched = false;


    private void Update()
    {
        if (!isLaunched) return;
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
        gameScreen.SetIsThrowButtonActive(false);
        aimer.AddTarget(plateThrowers[Random.Range(0, plateThrowers.Count)].ThrowPlate());
        StartCoroutine(WaitForShootTime());
    }

    private IEnumerator WaitForShootTime()
    {
        yield return new WaitWhile(() => aimer.IsTargetsExist);
        gameScreen.SetIsThrowButtonActive(true);
    }
}
