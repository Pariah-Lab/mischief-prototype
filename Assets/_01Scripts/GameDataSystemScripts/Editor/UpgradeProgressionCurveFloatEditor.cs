using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UpgradeProgressionCurveFloat))]
public class UpgradeProgressionCurveFloatEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        UpgradeProgressionCurveFloat scriptTarget = (UpgradeProgressionCurveFloat)target;

        if (GUILayout.Button("SetLevels"))
        {
            scriptTarget.SetLevelPoints();
        }

    }
}
