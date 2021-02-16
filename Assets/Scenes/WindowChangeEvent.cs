using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WindowChangeEvent : MonoBehaviour
{
    public event Action<int, int> ScreenResizeEvent;

    protected virtual void OnScreenResize(int width, int height)
    {
        if (ScreenResizeEvent != null) ScreenResizeEvent(width, height);
    }

    private Vector2 lastScreenSize;
    public static WindowChangeEvent instance = null;

    private void Awake()
    {
        lastScreenSize = new Vector2(Screen.width, Screen.height);
        instance = this;

    }

    private void Update()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        if (lastScreenSize != screenSize)
        {
            lastScreenSize = screenSize;
            OnScreenResize(Screen.width, Screen.height);
        }

        //SetPosition(0,0);
    }
}
