using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DEMOONLY
{
    public class DEMOONLY_QuitGame : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}

