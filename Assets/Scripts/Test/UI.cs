using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUI = UnityEngine.UI;

using Project.System;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = $"Width: {PixelPerfectScreenSize.PixelScreenWidth}\nHeight: {PixelPerfectScreenSize.PixelScreenHeight}";
    }

}
