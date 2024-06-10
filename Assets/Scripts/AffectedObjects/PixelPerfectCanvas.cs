using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project.Camera
{
    using System;
    public class PixelPerfectCanvas : MonoBehaviour
    {
        private void Awake()
        {
            ChangeSize();
            System.ScreenSizeChange.onScreenSizeChange += ChangeSize;
        }

        private void OnDestroy()
        {
            System.ScreenSizeChange.onScreenSizeChange -= ChangeSize;
        }

        void ChangeSize()
        {
            GetComponent<RectTransform>().sizeDelta =
                new Vector2(PixelPerfectScreenSize.PixelScreenWidth, PixelPerfectScreenSize.PixelScreenHeight);
        }
    }
}

