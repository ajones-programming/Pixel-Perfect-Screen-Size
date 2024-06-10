using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.System
{
    public class ScreenSizeChange : MonoBehaviour
    {
        public static event Action onScreenSizeChange;

        Vector2Int screenSizes;

        private void Start()
        {
            screenSizes = new Vector2Int(Screen.width, Screen.height);   
        }
        private void Update()
        {
            if (!screenSizes.Equals(new Vector2Int(Screen.width, Screen.height)))
            {
                PixelPerfectScreenSize.ChooseSize();
                onScreenSizeChange();
                screenSizes = new Vector2Int(Screen.width, Screen.height);
            }
        }
    }



}

