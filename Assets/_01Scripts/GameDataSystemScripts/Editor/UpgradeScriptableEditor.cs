// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using System.Linq;

// [CustomEditor(typeof(UpgradeScriptable))]
// public class UpgradeScriptableEditor : Editor
// {
//     // SerializedProperty m_useIncrement;
//     // SerializedProperty m_usePriceCurve;
//     // SerializedProperty m_useInt;
//     // SerializedProperty m_ValueToUpgradeFloat;
//     // SerializedProperty m_ValueToUpgradeInt;
//     // SerializedProperty m_currencyInt;
//     // SerializedProperty m_priceInt;
//     // SerializedProperty m_incrementInt;
//     // SerializedProperty m_incrementFloat;


//     // SerializedProperty m_level;
//     // SerializedProperty m_priceCurveUpgradeInt;
//     // SerializedProperty m_priceCurveUpgradeFloat;

//     // void OnEnable()
//     // {
//     //     m_useIncrement = serializedObject.FindProperty("useIncrement");
//     //     m_usePriceCurve = serializedObject.FindProperty("usePriceCurve");
//     //     m_useInt = serializedObject.FindProperty("useInt");
//     //     m_ValueToUpgradeFloat = serializedObject.FindProperty("ValueToUpgradeFloat");
//     //     m_ValueToUpgradeInt = serializedObject.FindProperty("ValueToUpgradeInt");
//     //     m_currencyInt = serializedObject.FindProperty("currencyInt");
//     //     m_priceInt = serializedObject.FindProperty("priceInt");
//     //     m_incrementInt = serializedObject.FindProperty("incrementInt");
//     //     m_incrementFloat = serializedObject.FindProperty("incrementFloat");
//     //     m_level = serializedObject.FindProperty("level");
//     //     m_priceCurveUpgradeInt = serializedObject.FindProperty("priceCurveUpgradeInt");
//     //     m_priceCurveUpgradeFloat = serializedObject.FindProperty("priceCurveUpgradeFloat");
//     // }

//     // public override void OnInspectorGUI()
//     // {
//     //     WriteUIScriptable tmp = target as WriteUIScriptable;
//     //     //The variables and GameObject from the MyGameObject script are displayed in the Inspector with appropriate labels
//     //     EditorGUILayout.PropertyField(m_useIncrement, new GUIContent("useIncrement"), GUILayout.Height(20));
//     //     EditorGUILayout.PropertyField(m_usePriceCurve, new GUIContent("Price curve"));
//     //     EditorGUILayout.PropertyField(m_useInt, new GUIContent("Use Int"));
//     //     EditorGUILayout.PropertyField(m_ValueToUpgradeInt, new GUIContent("Value to upgrade int"));
//     //     EditorGUILayout.PropertyField(m_level, new GUIContent("Value Level"));
//     //     EditorGUILayout.PropertyField(m_currencyInt, new GUIContent("Currency int"));
//     //     EditorGUILayout.PropertyField(m_priceInt, new GUIContent("Price int"));
//     //     EditorGUILayout.PropertyField(m_incrementInt, new GUIContent("increment int"));
//     //     EditorGUILayout.PropertyField(m_incrementFloat, new GUIContent("increment float"));
//     //     EditorGUILayout.PropertyField(m_level, new GUIContent("Upgrade level"));
//     //     EditorGUILayout.PropertyField(m_priceCurveUpgradeInt, new GUIContent("Price curve int"));
//     //     EditorGUILayout.PropertyField(m_priceCurveUpgradeFloat, new GUIContent("Price curve Float"));



//     //     //strings to be enabled

//     //     Rect texPos = new Rect(250, 40, 25, 25);
//     //     // if (!tmp.useInt)
//     //     // {
//     //     //     GUI.DrawTexture(texPos, GetTexture(tmp.useInt));
//     //     //     EditorGUILayout.PropertyField(m_priceCurveUpgradeInt, new GUIContent("Float value"));
//     //     // }
//     //     // else
//     //     // {
//     //     //     EditorGUILayout.PropertyField(m_ValueToUpgradeFloat, new GUIContent("Use Curve"));
//     //     //     GUI.DrawTexture(texPos, GetTexture(tmp.useInt));
//     //     //     EditorGUILayout.PropertyField(m_intValue, new GUIContent("Int value"));
//     //     // }
//     //     // if (tmp.useincrementInt)
//     //     // {
//     //     //     EditorGUILayout.PropertyField(m_incrementInt, new GUIContent("incrementInt"));
//     //     // }
//     //     // if (tmp.useincrementFloat)
//     //     // {
//     //     //     EditorGUILayout.PropertyField(m_incrementFloat, new GUIContent("incrementFloat"));
//     //     // }
//     //     // if (tmp.useCurve)
//     //     // {
//     //     //     EditorGUILayout.PropertyField(m_priceInt, new GUIContent("Curve"));
//     //     // }
//     //     // Apply changes to the serializedProperty - always do this at the end of OnInspectorGUI.
//     //     serializedObject.ApplyModifiedProperties();
//     // }
//     // public Texture GetTexture(bool messages)
//     // {
//     //     Texture2D floatVlue = Resources.Load("priceCurveUpgradeInt") as Texture2D;
//     //     Texture2D intVlue = Resources.Load("IntValue") as Texture2D;

//     //     if (!messages)
//     //     {
//     //         return floatVlue;
//     //     }
//     //     else
//     //     {
//     //         return intVlue;
//     //     }
//     // }
// }
