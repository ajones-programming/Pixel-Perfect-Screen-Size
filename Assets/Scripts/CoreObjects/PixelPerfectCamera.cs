using Project.System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Camera
{
//    using System;
//#if UNIVERSAL_RENDER_PIPELINE
//    using PixelPerf =  UnityEngine.Experimental.Rendering.Universal.PixelPerfectCamera;
//#else
//    using PixelPerf = UnityEngine.U2D.PixelPerfectCamera; 
//#endif

   

    [RequireComponent(typeof(UnityEngine.Camera))]
    public class PixelPerfectCamera : MonoBehaviour
    {
        [SerializeField] bool crop = false;
        [SerializeField] PixelPerfectScreenSize screenSize;
        System.PixelPerfectCameraFixed pxpc = null;


        private void Start()
        {
            screenSize.AddAction(onScreenSizeChange);
        }

        private void OnDestroy()
        {
            screenSize.RemoveAction(onScreenSizeChange);

        }


        void onScreenSizeChange(PixelPerfectScreenSize.Information screensize)
        {
            if (pxpc == null)
            {
                pxpc = gameObject.AddComponent<System.PixelPerfectCameraFixed>();
                pxpc.AddSize(screenSize);
            }
            pxpc.stretchFill = false;
            pxpc.refResolutionX = screensize.PixelScreenWidth;
            pxpc.refResolutionY = screensize.PixelScreenHeight;
            pxpc.pixelSnapping = true;
            pxpc.upscaleRT = true;
            pxpc.assetsPPU = screensize.PixelsPerUnit;
            pxpc.cropFrameX = crop;
            pxpc.cropFrameY = crop;

            GetComponent<UnityEngine.Camera>().pixelRect= new Rect(0, 0, 200, 200);

        }
    }

}

