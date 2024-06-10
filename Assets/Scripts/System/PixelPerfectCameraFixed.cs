using UnityEngine;

using System;
#if UNIVERSAL_RENDER_PIPELINE
    using PixelPerf =  UnityEngine.Experimental.Rendering.Universal.PixelPerfectCamera;
#else
using PixelPerf = UnityEngine.U2D.PixelPerfectCamera;
using UnityEngine.U2D;
#endif

namespace Project.System
{
    public class PixelPerfectCameraFixed : PixelPerf
    {
        UnityEngine.Camera m_Camera;

        private void Start()
        {
            m_Camera = GetComponent<UnityEngine.Camera>();
        }

        private void OnPostRender()
        {
            PixelPerfectRendering.pixelSnapSpacing = 0f;

            RenderTexture activeTexture = m_Camera.activeTexture;
            if (activeTexture != null)
            {
                activeTexture.filterMode = FilterMode.Point;
            }

            Rect result = default;
            result.height = PixelPerfectScreenSize.UnitFactor * PixelPerfectScreenSize.PixelScreenHeight;
            result.width = PixelPerfectScreenSize.UnitFactor * PixelPerfectScreenSize.PixelScreenWidth;
            result.x = (Screen.width - (int)result.width) / 2;
            result.y = (Screen.height - (int)result.height) / 2;

            m_Camera.pixelRect = result;
        }

    }
}