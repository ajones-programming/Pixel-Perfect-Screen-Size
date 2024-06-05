using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.System
{

    //compares the window screen size to a set of predefined 
    public class PixelPerfectScreenSize
    {
        List<Vector2Int> allSizes = new List<Vector2Int>()
        {
            new Vector2Int( 0,0),
            new Vector2Int(180 ,100),
            new Vector2Int(180  ,120),
            new Vector2Int( 180,150),
            new Vector2Int(180, 160),
            new Vector2Int(180, 180),
            new Vector2Int( 100,200),
            new Vector2Int(150,150)
        };

        //this will initialise if any instance variables are requested
        static PixelPerfectScreenSize instance = new PixelPerfectScreenSize();

        int _pixelScreenHeight = 0;
        int _pixelScreenWidth = 544;
        int _factor = 0;
        public const int PixelsPerUnit = 32;

        //how many units high is the screen???
        
        

        public static int PixelScreenHeight => instance._pixelScreenHeight;
        public static int PixelScreenWidth => instance._pixelScreenWidth;

        public static float UnitScreenWidth => (PixelsPerUnit > 0) ? PixelScreenWidth / (float)PixelsPerUnit : 0;
        public static float UnitScreenHeight => (PixelsPerUnit > 0) ? PixelScreenHeight / (float)PixelsPerUnit : 0;

        public static Vector2 PixelScreenSize => new Vector2(PixelScreenWidth, PixelScreenHeight);

        public static int UnitFactor => instance._factor;

        PixelPerfectScreenSize()
        {
            cycleThroughAllSizes();
        }

        void cycleThroughAllSizes()
        {
            Vector2Int currentIteratedSize = Vector2Int.zero;
            for(int i = 0; i < allSizes.Count; ++i)
            {

                if (greaterScreenArea(allSizes[i],currentIteratedSize))
                {
                    currentIteratedSize = allSizes[i];
                }
            }
            if (currentIteratedSize == Vector2Int.zero)
            {
                Debug.LogError("HAS A RATIO OF ZERO! THIS IS BAD!");
            }
            _pixelScreenHeight = currentIteratedSize.y;
            _pixelScreenWidth = currentIteratedSize.x;
            _factor = Mathf.Min(Screen.width/_pixelScreenWidth, Screen.height/_pixelScreenHeight);
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
            int sizeRatio = Mathf.Min(Screen.height / size.y, Screen.width/size.x);
            if (sizeRatio == 0)
            {
                return 0f;
            }
            float ratio = (float)(sizeRatio * size.x) / Screen.height * (sizeRatio * size.y) / Screen.width;
            return ratio;
        }
    }

}