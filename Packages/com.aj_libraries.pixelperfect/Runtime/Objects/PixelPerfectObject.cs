
using UnityEngine;
using UnityEngine.Events;


namespace PixelPerfect {

    public abstract class PixelPerfectObject : MonoBehaviour
    {
        public PixelPerfectScreenSize screenSizeChange;
        public abstract void onScreenSizeChange(PixelPerfectScreenSize.Information info);



        private void Start()
        {
            if (screenSizeChange == null)
            {
                screenSizeChange = FindObjectOfType<PixelPerfectScreenSize>();
                Debug.LogWarning($"Did you mean to forget the Screensize ({screenSizeChange.name}) on this Object? ({name})");
            }
            if (screenSizeChange != null)
            {
                FindObjectOfType<PixelPerfectScreenSize>().AddAction(onScreenSizeChange);
            }
        }

        private void OnDestroy()
        {
            if (screenSizeChange != null)
            {
                screenSizeChange.RemoveAction(onScreenSizeChange);
            }

        }

    }
}

