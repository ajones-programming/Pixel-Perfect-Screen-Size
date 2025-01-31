using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelPerfect
{
    public class PixelPerfectScreenSize : MonoBehaviour
    {
        
        Vector2Int screenSizes;

        public List<Vector2Int> allSizes = new List<Vector2Int>()
        {
            new Vector2Int( 0,0), //error size
            new Vector2Int(360,250),
            new Vector2Int(360,350),
            new Vector2Int(200,400),
            new Vector2Int(300,300)
        };

        public int PixelsPerUnit = 32;


        #region VALUES



        int size;
        int factor = 0;


        //how many units high is the screen???
        int PixelScreenHeight => allSizes[(int)size].y;
        int PixelScreenWidth => allSizes[(int)size].x;

        float UnitScreenWidth => (PixelsPerUnit > 0) ? PixelScreenWidth / (float)PixelsPerUnit : 0;
        float UnitScreenHeight => (PixelsPerUnit > 0) ? PixelScreenHeight / (float)PixelsPerUnit : 0;

        Vector2Int PixelScreenSize => allSizes[(int)size];


        public struct Information {

            public int size;
            public int PixelsPerUnit;
            public int PixelScreenHeight;
            public int PixelScreenWidth;
            public float UnitScreenWidth;
            public float UnitScreenHeight;
            public Vector2 PixelScreenSize;
            public int UnitFactor;

            public bool isEqual(int size, int UnitFactor) => this.size == size && this.UnitFactor == UnitFactor;
        }

        private Information info =>
            new Information()
            {
                size = size,
                PixelsPerUnit = PixelsPerUnit,
                PixelScreenHeight = PixelScreenHeight,
                PixelScreenWidth = PixelScreenWidth,

                UnitScreenWidth = UnitScreenWidth,
                UnitScreenHeight = UnitScreenHeight,

                PixelScreenSize = PixelScreenSize,
                UnitFactor = factor

            };

        UnityAction<Information> onScreenSizeChange;

        #endregion

        #region CALCULATION
        void CheckScreenSize()
        {
            int currentIteratedSize = 0;
            for (int i = 1; i < allSizes.Count; ++i)
            {
                if (greaterScreenArea(allSizes[i], allSizes[currentIteratedSize]))
                {
                    currentIteratedSize = i;

                }
            }
            if (currentIteratedSize == 0)
            {
                Debug.LogError("HAS A RATIO OF ZERO! THIS IS BAD!");
            }
            size = currentIteratedSize;
            factor = Mathf.Min(Screen.width / allSizes[currentIteratedSize].x, Screen.height / allSizes[currentIteratedSize].y);
        }

        bool greaterScreenArea(Vector2Int thisSize, Vector2Int currentSize)
        {
            float currentRatio = RatioOfScreenArea(currentSize);
            float newRatio = RatioOfScreenArea(thisSize);
            if (newRatio > currentRatio)
            {
                return true;
            }
            else if (newRatio == currentRatio)
            {
                return thisSize.sqrMagnitude > currentSize.sqrMagnitude;
            }

            return false;
        }

        float RatioOfScreenArea(Vector2Int size)
        {
            if (size.x == 0 || size.y == 0)
            {
                return 0f;
            }
            int sizeRatio = Mathf.Min(Screen.height / size.y, Screen.width / size.x);
            if (sizeRatio == 0)
            {
                return 0f;
            }
            float ratio = (float)(sizeRatio * size.x) / Screen.height * (sizeRatio * size.y) / Screen.width;
            return ratio;
        }

        #endregion

        #region ACTIONS

        public void AddAction(UnityEvent<Information> unityEvent)
        {
            onScreenSizeChange += unityEvent.Invoke;
            unityEvent.Invoke(info);
        }
        public void AddAction(Action<Information> unityEvent)
        {
            onScreenSizeChange += unityEvent.Invoke;
            unityEvent.Invoke(info);
        }

        public void RemoveAction(UnityEvent<Information> unityEvent)
        {
            onScreenSizeChange -= unityEvent.Invoke;
        }

        public void RemoveAction(Action<Information> unityEvent)
        {
            onScreenSizeChange -= unityEvent.Invoke;
        }

        #endregion

        private void Awake()
        {
            screenSizes = new Vector2Int(Screen.width, Screen.height);
            CheckScreenSize();
        }

        private void Update()
        {
            if (!screenSizes.Equals(new Vector2Int(Screen.width, Screen.height)))
            {
                int previousScreenSize = size;
                int previousUnitFactor = factor;
                CheckScreenSize();

                if (previousScreenSize != size || previousUnitFactor != factor)
                {
                    onScreenSizeChange?.Invoke(info);
                    screenSizes = new Vector2Int(Screen.width, Screen.height);
                }
                
            }
        }
    }



}

