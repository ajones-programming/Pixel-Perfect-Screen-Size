using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Project.Camera
{
#if UNIVERSAL_RENDER_PIPELINE
    using PixelPerf =  UnityEngine.Experimental.Rendering.Universal.PixelPerfectCamera;
#else
    using PixelPerf = UnityEngine.U2D.PixelPerfectCamera; 
#endif

    using PixelPerfectSize = System.PixelPerfectScreenSize;
   

    [RequireComponent(typeof(UnityEngine.Camera))]
    public class PixelPerfectCamera : MonoBehaviour
    {
        [SerializeField] bool crop = false;
        void Awake()
        {
            PixelPerf pxpc = gameObject.AddComponent<PixelPerf>();
            pxpc.stretchFill = false;
            pxpc.cropFrameY = true;
            pxpc.cropFrameX = true;
            pxpc.refResolutionX = PixelPerfectSize.PixelScreenWidth;
            pxpc.refResolutionY = PixelPerfectSize.PixelScreenHeight;
            pxpc.pixelSnapping = true;
            pxpc.upscaleRT = true;
            pxpc.assetsPPU = PixelPerfectSize.PixelsPerUnit;
            pxpc.cropFrameX = crop;
            pxpc.cropFrameY = crop;

        }
    }

}

