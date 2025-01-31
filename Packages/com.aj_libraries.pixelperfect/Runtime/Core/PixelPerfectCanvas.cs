using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PixelPerfect
{
    public class PixelPerfectCanvas : MonoBehaviour
    {
        [SerializeField] PixelPerfectScreenSize screenSize;

        private void Start()
        {
            if (screenSize == null)
            {
                screenSize = FindObjectOfType<PixelPerfectScreenSize>();
                Debug.LogWarning($"Did you mean to forget the Screensize ({screenSize.name}) on this Object? ({name})");
            }
            screenSize.AddAction(onScreenSizeChange);
        }

        private void OnDestroy()
        {
            screenSize.RemoveAction(onScreenSizeChange);

        }
        public void onScreenSizeChange(PixelPerfectScreenSize.Information screensize)
        {
            GetComponent<RectTransform>().sizeDelta =
                new Vector2(screensize.PixelScreenWidth, screensize.PixelScreenHeight);
        }
    }
}

