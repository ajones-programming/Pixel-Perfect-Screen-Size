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
        public PixelPerfectScreenSize size;
        public PixelPerfectScreenSize.Information info;

        private void Start()
        {
            m_Camera = GetComponent<UnityEngine.Camera>();   
        }

        public void AddSize(PixelPerfectScreenSize size)
        {
            this.size = size;
            size.AddAction(SetThisInfo);
        }


        private void OnDestroy()
        {
            size.RemoveAction(SetThisInfo);
        }

        private void SetThisInfo(PixelPerfectScreenSize.Information info)
        {
            this.info = info;
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
            result.height = info.UnitFactor * info.PixelScreenHeight;
            result.width = info.UnitFactor * info.PixelScreenWidth;
            result.x = (Screen.width - (int)result.width) / 2;
            result.y = (Screen.height - (int)result.height) / 2;

            m_Camera.pixelRect = result;
        }

    }
}