using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project.Camera
{
    using System;
    public class PixelPerfectCanvas : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<RectTransform>().sizeDelta =
                new Vector2(PixelPerfectScreenSize.PixelScreenWidth, PixelPerfectScreenSize.PixelScreenHeight);
        }
    }
}

