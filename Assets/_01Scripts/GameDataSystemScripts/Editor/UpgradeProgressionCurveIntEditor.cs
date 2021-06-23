using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(UpgradeProgressionCurveInt))]
public class UpgradeProgressionCurveIntEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        UpgradeProgressionCurveInt scriptTarget = (UpgradeProgressionCurveInt)target;

        if (GUILayout.Button("SetLevels"))
        {
            scriptTarget.SetLevelPoints();
        }

    }
}
