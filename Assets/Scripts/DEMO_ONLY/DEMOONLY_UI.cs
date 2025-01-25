using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Project.System;
using UnityEngine.UI;

namespace DEMOONLY
{
    public class DEMOONLY_UI : MonoBehaviour
    {
        [System.Serializable]
        public struct ExampleTextStruct
        {
            public PixelPerfectScreenSize.SIZES size;
            public string text;
        }

        [SerializeField] Text text;
        [SerializeField] List<ExampleTextStruct> allText = new List<ExampleTextStruct>();

        public void ChooseText(PixelPerfectScreenSize.Information size)
        {
            string exampleString = "";
            foreach (var a in allText)
            {
                if (a.size == size.size)
                {
                    
                    exampleString = a.text;
                    break;
                }
            }
            text.text = $"Width: {size.PixelScreenWidth}\nHeight: {size.PixelScreenHeight}\n{exampleString}";
        }

    }

}

