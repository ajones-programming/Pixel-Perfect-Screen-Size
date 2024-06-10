using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DEMOONLY
{
    public class DEMOONLY_TintBackgroundImage : MonoBehaviour
    {
        float time = 0;
        [SerializeField] Image m_Image;
        [SerializeField] Color color = Color.white;
        [SerializeField] float speed = 5;

        // Update is called once per frame
        void Update()
        {
            m_Image.color = Color.Lerp(Color.white, color, Mathf.Sin(time));
            time += speed * Time.deltaTime;
        }
    }
}

