using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.System
{

    //compares the window screen size to a set of predefined 
    public class PixelPerfectScreenSize
    {
        
        public enum SIZES
        {
            ERROR,
            _360X250,
            _360X350,
            _200X400,
            _300X300
        };

        List<Vector2Int> allSizes = new List<Vector2Int>()
        {
            new Vector2Int( 0,0), //error size
            new Vector2Int(360,250),
            new Vector2Int(360,350),
            new Vector2Int(200,400),
            new Vector2Int(300,300)
        };

        //this will initialise if any instance variables are requested
        static PixelPerfectScreenSize instance = new PixelPerfectScreenSize();

        SIZES _size;
        int _factor = 0;
        public const int PixelsPerUnit = 32;

        //how many units high is the screen???


        public static SIZES size => instance._size;
        public static int PixelScreenHeight => instance.allSizes[(int)instance._size].y;
        public static int PixelScreenWidth => instance.allSizes[(int)instance._size].x;

        public static float UnitScreenWidth => (PixelsPerUnit > 0) ? PixelScreenWidth / (float)PixelsPerUnit : 0;
        public static float UnitScreenHeight => (PixelsPerUnit > 0) ? PixelScreenHeight / (float)PixelsPerUnit : 0;

        public static Vector2 PixelScreenSize => new Vector2(PixelScreenWidth, PixelScreenHeight);

        public static int UnitFactor => instance._factor;

        PixelPerfectScreenSize()
        {
            cycleThroughAllSizes();
        }

        public static void ChooseSize() => instance.cycleThroughAllSizes();

        void cycleThroughAllSizes()
        {
            int currentIteratedSize = 0;

            for(int i = 1; i < allSizes.Count; ++i)
            {

                if (greaterScreenArea(allSizes[i],allSizes[currentIteratedSize]))
                {
                    currentIteratedSize = i;

                }
            }
            if (currentIteratedSize == 0)
            {
                Debug.LogError("HAS A RATIO OF ZERO! THIS IS BAD!");
            }
            _size = (SIZES)currentIteratedSize;
            _factor = Mathf.Min(Screen.width / allSizes[currentIteratedSize].x, Screen.height/ allSizes[currentIteratedSize].y);
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