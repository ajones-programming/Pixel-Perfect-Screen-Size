
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace PixelPerfect.Editor
{

    [CustomEditor(typeof(PixelPerfectObject), true)]
    public class PixelPerfectObjectEditor : UnityEditor.Editor
    {
        PixelPerfectObject obj => target as PixelPerfectObject;

        public override void OnInspectorGUI()
        {

            if (obj.screenSizeChange)
            {
                GUILayout.Label("All sizes from base");
                EditorGUI.indentLevel++;
                foreach (Vector2 v in obj.screenSizeChange.allSizes)
                {
                    if (v.x == 0 && v.y == 0)
                    {
                        GUILayout.Label($"\t(error size)");
                    }
                    else
                    {
                        GUILayout.Label($"\t{v}");
                    }

                }
                GUILayout.Label("Pixels per unit: " + obj.screenSizeChange.PixelsPerUnit);
                EditorGUI.indentLevel--;
            }
            else
            {
                if (GUILayout.Button("Add Pixel Perfect Screen Size"))
                {
                    obj.screenSizeChange = FindObjectOfType<PixelPerfectScreenSize>();
                    if (obj.screenSizeChange != null)
                    {
                        EditorUtility.SetDirty(obj);
                    }
                }
            }
            base.OnInspectorGUI();
        }
    }
}
