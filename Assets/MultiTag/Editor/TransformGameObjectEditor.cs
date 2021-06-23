//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//[CustomEditor(typeof(Transform))]
//public class TransformGameObjectEditor : Editor
//{
//    int index = 0;

//    public override void OnInspectorGUI()
//    {
//        Transform trgt = target as Transform;
//        //base.OnInspectorGUI();
//        DrawDefaultInspector();
//        serializedObject.Update();

//        string[] SelectedItems = new string[5];
//        for (int i = 0; i < SelectedItems.Length; i++)
//        {
//            SelectedItems[i] = i + " test ";
//        }
//        index = EditorGUILayout.Popup(index, SelectedItems);

//        serializedObject.Update();
//        EditorUtility.SetDirty(trgt);
//    }

    
//}
