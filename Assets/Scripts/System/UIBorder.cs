using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Camera
{
    using PixelPerfectScreenSize = System.PixelPerfectScreenSize;
    public class UIBorder : MonoBehaviour
    {
        //because inverted masking is apparently not possible??? have to do them individually are you joking???
        [SerializeField] Image borderTop;
        [SerializeField] Image borderBottom;
        [SerializeField] Image borderLeft;
        [SerializeField] Image borderRight;

        [SerializeField] RawImage renderTexture;
        // Start is called before the first frame update
        void Start()
        {
            SizeImages();
        }

        void SizeImages()
        {
            Vector2 size = new Vector2(PixelPerfectScreenSize.PixelScreenWidth * PixelPerfectScreenSize.UnitFactor,
                 PixelPerfectScreenSize.PixelScreenHeight * PixelPerfectScreenSize.UnitFactor);

            renderTexture.rectTransform.sizeDelta = size;

            borderLeft.rectTransform.sizeDelta = new Vector2((Screen.width - size.x) / 2f, Screen.height);
            borderLeft.rectTransform.transform.position = new Vector2(0,0);
            borderRight.rectTransform.sizeDelta = new Vector2((Screen.width - size.x) / 2f, Screen.height);
            borderRight.rectTransform.transform.position = new Vector2(Screen.width, Screen.height) -
                borderRight.rectTransform.sizeDelta;
            borderBottom.rectTransform.sizeDelta = new Vector2(size.x, (Screen.height - size.y) / 2f);
            borderBottom.rectTransform.position = new Vector2((Screen.width - size.x) / 2f, 0);
            borderTop.rectTransform.sizeDelta = new Vector2(size.x, (Screen.height - size.y) / 2f);
            borderTop.rectTransform.position = new Vector2((Screen.width - size.x) / 2f, Screen.height - (Screen.height - size.y) / 2f);
        }
    }

}
