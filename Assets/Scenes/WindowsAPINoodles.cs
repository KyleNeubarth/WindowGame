using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowsAPINoodles : MonoBehaviour
{
    public TextMeshProUGUI varA;
    public TextMeshProUGUI varB;
    private IntPtr windowHandle;
    
    //there must be some way that I can automate this
    private int defaultWindowW = 1024;
    private int defaultWindowH = 768;
    
    //location of the game space origin on the monitor
    private Vector2Int origin;
    //
    private float gameToScreen;
    
    private int oldWindowX = -1;
    private int oldWindowY = -1;

    public Camera camera;
    public void Awake()
    {
        windowHandle = FindWindow(null, "Direwolf Noodling");
        Rect returnRect = new Rect();
        GetWindowRect(windowHandle, ref returnRect);
        origin = new Vector2Int(returnRect.Left+returnRect.Right/2,returnRect.Top+returnRect.Bottom/2);
        gameToScreen = ((float)(returnRect.Top - returnRect.Bottom))/(camera.orthographicSize*2);
    }

    public void Update()
    {
        Rect returnRect = new Rect();
        GetWindowRect(windowHandle, ref returnRect);
        int cameraOffsetX = 0;
        if (oldWindowX != -1)
            cameraOffsetX = oldWindowX - returnRect.Left;
        oldWindowX = returnRect.Left;
        camera.transform.position += new Vector3(cameraOffsetX*(1f/gameToScreen),0,0);
        
        varA.text = gameToScreen.ToString();
        varB.text = camera.transform.position.x.ToString();
    }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    private static extern bool SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

    public void SetPosition(int x, int y, int resX = 0, int resY = 0)
    {
        SetWindowPos(FindWindow(null, "Direwolf Noodling"), 0, x, y, resX, resY, resX * resY == 0 ? 1 : 0);
    }
    
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr FindWindow(string strClassName, string strWindowName);

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

    public struct Rect {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }
#endif
}
