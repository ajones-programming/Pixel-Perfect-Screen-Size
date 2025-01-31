
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace PixelPerfect
{

    [RequireComponent(typeof(UnityEngine.Camera))]
    public class PixelPerfectCamera : MonoBehaviour
    {
        [SerializeField] bool crop = false;
        [SerializeField] PixelPerfectScreenSize screenSize;
        PixelPerfectCameraFixed pxpc = null;


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
                pxpc = gameObject.AddComponent<PixelPerfectCameraFixed>();
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

