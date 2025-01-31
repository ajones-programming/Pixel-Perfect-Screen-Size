using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using PixelPerfect;

namespace DEMOONLY
{
    public class DEMOONLY_UI : PixelPerfectObject
    {
        [System.Serializable]
        public struct ExampleTextStruct
        {
            public Vector2Int sizeVec;
            public string text;
        }

        [SerializeField] Text text;
        [SerializeField] List<ExampleTextStruct> allText = new List<ExampleTextStruct>();

        public override void onScreenSizeChange(PixelPerfectScreenSize.Information info) => ChooseText(info);
        public void ChooseText(PixelPerfectScreenSize.Information size)
        {
            string exampleString = "";
            foreach (var a in allText)
            {
                if (a.sizeVec.Equals(size.PixelScreenSize))
                {
                    exampleString = a.text;
                    break;
                }
            }
            text.text = $"Width: {size.PixelScreenWidth}\nHeight: {size.PixelScreenHeight}\n{exampleString}";
        }

    }

}

