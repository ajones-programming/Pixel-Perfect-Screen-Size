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
        [SerializeField]
        List<ExampleTextStruct> allText =
            new List<ExampleTextStruct>();

        // Start is called before the first frame update

        private void Awake()
        {
            ScreenSizeChange.onScreenSizeChange += ChooseText;
        }

        void Start()
        {
            ChooseText();
        }

        private void OnDestroy()
        {
            ScreenSizeChange.onScreenSizeChange -= ChooseText;
        }

        void ChooseText()
        {
            string exampleString = "";
            foreach (var a in allText)
            {
                if (a.size == PixelPerfectScreenSize.size)
                {
                    
                    exampleString = a.text;
                    break;
                }
            }
            text.text = $"Width: {PixelPerfectScreenSize.PixelScreenWidth}\nHeight: {PixelPerfectScreenSize.PixelScreenHeight}\n{exampleString}";
        }

    }

}

