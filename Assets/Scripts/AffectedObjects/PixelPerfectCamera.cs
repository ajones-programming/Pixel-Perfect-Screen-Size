using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Project.Camera
{
//    using System;
//#if UNIVERSAL_RENDER_PIPELINE
//    using PixelPerf =  UnityEngine.Experimental.Rendering.Universal.PixelPerfectCamera;
//#else
//    using PixelPerf = UnityEngine.U2D.PixelPerfectCamera; 
//#endif

    using PixelPerfectSize = System.PixelPerfectScreenSize;
   

    [RequireComponent(typeof(UnityEngine.Camera))]
    public class PixelPerfectCamera : MonoBehaviour
    {
        [SerializeField] bool crop = false;
        System.PixelPerfectCameraFixed pxpc = null;

        void Awake()
        {
            ScreenSizeChange();
            System.ScreenSizeChange.onScreenSizeChange += ScreenSizeChange;
        }

        private void OnDestroy()
        {
            System.ScreenSizeChange.onScreenSizeChange -= ScreenSizeChange;
        }

        void ScreenSizeChange()
        {
            if (pxpc == null)
            {
                pxpc = gameObject.AddComponent<System.PixelPerfectCameraFixed>();
            }
            pxpc.stretchFill = false;
            pxpc.refResolutionX = PixelPerfectSize.PixelScreenWidth;
            pxpc.refResolutionY = PixelPerfectSize.PixelScreenHeight;
            pxpc.pixelSnapping = true;
            pxpc.upscaleRT = true;
            pxpc.assetsPPU = PixelPerfectSize.PixelsPerUnit;
            pxpc.cropFrameX = crop;
            pxpc.cropFrameY = crop;

            GetComponent<UnityEngine.Camera>().pixelRect= new Rect(0, 0, 200, 200);

        }
    }

}

