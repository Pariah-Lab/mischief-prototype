using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DataSystem;



[CustomEditor(typeof(DataCenter))]
public class DataCenterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DataCenter scriptTarget = (DataCenter)target;

        if (GUILayout.Button("SaveData"))
        {
            scriptTarget.SaveUsingSaveDataHolder();
        }
        if (GUILayout.Button("LoadData"))
        {
            scriptTarget.LoadUsingSaveDataHolder();
        }       
        if (GUILayout.Button("Reset Stats"))
        {
            scriptTarget.ResetData();
        }
    }
}
