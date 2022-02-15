using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreens : Singleton<UIScreens>
{
    public T GetScreenElement<T>() where T : IScreenElement
    {
        IScreenElement[] elements = GetComponentsInChildren<IScreenElement>(true);
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].GetType() == typeof(T)) return (T)elements[i];
        }
        return default;
    }

    public void HideAll()
    {
        foreach (var screenElement in GetComponentsInChildren<IScreenElement>())
        {
            screenElement.Hide(true);
        }
    }

    protected override void Setup()
    {
        HideAll();
    }
}
