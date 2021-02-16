using System;
using UnityEngine;


public class StretchButton: MonoBehaviour
{
    public void Start()
    {
        WindowChangeEvent.instance.ScreenResizeEvent += OnWindowResize;
    }

    private void OnWindowResize(int width, int height)
    {
        Debug.Log("width: "+width+"; height: "+height);   
    }
}