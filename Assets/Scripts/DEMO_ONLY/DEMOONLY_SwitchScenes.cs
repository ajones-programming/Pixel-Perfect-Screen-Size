using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DEMOONLY
{
    public class DEMOONLY_SwitchScenes : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int currentScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadSceneAsync((currentScene + 1)%SceneManager.sceneCountInBuildSettings);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}

