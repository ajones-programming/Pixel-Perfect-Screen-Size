using Project.System;
using UnityEngine;
using UnityEngine.Events;

public class PixelPerfectObject : MonoBehaviour
{
    [SerializeField] PixelPerfectScreenSize screenSizeChange;
    public UnityEvent<PixelPerfectScreenSize.Information> onScreenSizeChange = null;



    private void Start()
    {
        if (screenSizeChange == null)
        {
            screenSizeChange = FindObjectOfType<PixelPerfectScreenSize>();
            Debug.LogWarning($"Did you mean to forget the Screensize ({screenSizeChange.name}) on this Object? ({name})");
        }
        if (onScreenSizeChange != null && screenSizeChange != null)
        {
            FindObjectOfType<PixelPerfectScreenSize>().AddAction(onScreenSizeChange);
        }
    }

    private void OnDestroy()
    {
        if (onScreenSizeChange != null && screenSizeChange != null)
        {
            screenSizeChange.RemoveAction(onScreenSizeChange);
        }
        
    }

}
