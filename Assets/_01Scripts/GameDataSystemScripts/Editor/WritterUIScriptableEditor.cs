using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;


[CustomEditor(typeof(WriteUIScriptable))]
public class WritterUIScriptableEditor : Editor
{
    SerializedProperty m_myTextField;
    SerializedProperty m_useSlider;
    SerializedProperty m_useDefault;
    SerializedProperty m_defaultSlider;
    SerializedProperty m_fillImage;
    SerializedProperty m_useInt;
    SerializedProperty m_useCurve;
    SerializedProperty m_usePrefix;
    SerializedProperty m_useSuffix;
    SerializedProperty m_progressionCurveInt;
    SerializedProperty m_progressionCurveFloat;
    SerializedProperty m_intCurve;
    SerializedProperty m_prefix;
    SerializedProperty m_suFix;
    SerializedProperty m_autoSubscribe;

    SerializedProperty m_animateValueChage;
    SerializedProperty m_floatValue;
    SerializedProperty m_intValue;
    SerializedProperty m_mainValue;
    SerializedProperty m_OnValueUpdated;

    void OnEnable()
    {
        m_myTextField = serializedObject.FindProperty("myTextField");
        m_useSlider = serializedObject.FindProperty("useSlider");
        m_useDefault = serializedObject.FindProperty("useDefault");
        m_defaultSlider = serializedObject.FindProperty("defaultSlider");
        m_fillImage = serializedObject.FindProperty("fillImage");

        m_useInt = serializedObject.FindProperty("useInt");
        m_animateValueChage = serializedObject.FindProperty("animateValueChage");
        m_floatValue = serializedObject.FindProperty("floatValue");
        m_intValue = serializedObject.FindProperty("intValue");
        m_useCurve = serializedObject.FindProperty("useCurve");
        m_usePrefix = serializedObject.FindProperty("usePrefix");
        m_useSuffix = serializedObject.FindProperty("useSufix");
        m_prefix = serializedObject.FindProperty("prefix");
        m_suFix = serializedObject.FindProperty("suFix");
        m_progressionCurveInt = serializedObject.FindProperty("progressionCurveInt");
        m_progressionCurveFloat = serializedObject.FindProperty("progressionCurveFloat");
        m_intCurve = serializedObject.FindProperty("intCurve");
        m_mainValue = serializedObject.FindProperty("mainValue");
        m_autoSubscribe = serializedObject.FindProperty("autSubscribe");
        m_OnValueUpdated = serializedObject.FindProperty("OnValueUpdated");
    }

    public override void OnInspectorGUI()
    {
        WriteUIScriptable tmp = target as WriteUIScriptable;
        //The variables and GameObject from the MyGameObject script are displayed in the Inspector with appropriate labels
        EditorGUILayout.PropertyField(m_useSlider, new GUIContent("Use slider"));
        EditorGUILayout.PropertyField(m_autoSubscribe, new GUIContent("Auto Subscribe"));
        EditorGUILayout.PropertyField(m_OnValueUpdated, new GUIContent("OnValueUpdated"));

        if (!tmp.useSlider)
        {
            EditorGUILayout.PropertyField(m_myTextField, new GUIContent("My Text"), GUILayout.Height(20));
            EditorGUILayout.PropertyField(m_useInt, new GUIContent("Use Int"));
            EditorGUILayout.PropertyField(m_animateValueChage, new GUIContent("Animate value"));
            EditorGUILayout.PropertyField(m_usePrefix, new GUIContent("Use prefix"));
            EditorGUILayout.PropertyField(m_useSuffix, new GUIContent("Use sufix"));
            // EditorGUILayout.PropertyField(m_mainValue, new GUIContent("Asset refMainValue"));


            //strings to be enabled

            Rect texPos = new Rect(250, 40, 25, 25);
            if (!tmp.useInt)
            {
                GUI.DrawTexture(texPos, GetTexture(tmp.useInt));
                EditorGUILayout.PropertyField(m_floatValue, new GUIContent("Float value"));
            }
            else
            {
                EditorGUILayout.PropertyField(m_useCurve, new GUIContent("Use Curve"));
                GUI.DrawTexture(texPos, GetTexture(tmp.useInt));
                EditorGUILayout.PropertyField(m_intValue, new GUIContent("Int value"));
            }
            if (tmp.usePrefix)
            {
                EditorGUILayout.PropertyField(m_prefix, new GUIContent("Prefix"));
            }
            if (tmp.useSufix)
            {
                EditorGUILayout.PropertyField(m_suFix, new GUIContent("Sufix"));
            }
            if (tmp.useCurve)
            {

                EditorGUILayout.PropertyField(m_intCurve, new GUIContent("int curve"));
                if (tmp.intCurve)
                {
                    EditorGUILayout.PropertyField(m_progressionCurveInt, new GUIContent("Curve"));
                }
                else
                {
                    EditorGUILayout.PropertyField(m_progressionCurveFloat, new GUIContent("Curve"));

                }
            }
        }
        else
        {

            EditorGUILayout.PropertyField(m_useDefault, new GUIContent("use default slider"));
            if (tmp.useDefault)
            {
                EditorGUILayout.PropertyField(m_defaultSlider, new GUIContent("Default slider"));
            }
            else
            {
                EditorGUILayout.PropertyField(m_fillImage, new GUIContent("Fill Image"));

            }
            EditorGUILayout.PropertyField(m_floatValue, new GUIContent("Float value"));
        }
        // Apply changes to the serializedProperty - always do this at the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }
    public Texture GetTexture(bool messages)
    {
        Texture2D floatVlue = Resources.Load("FloatValue") as Texture2D;
        Texture2D intVlue = Resources.Load("IntValue") as Texture2D;

        if (!messages)
        {
            return floatVlue;
        }
        else
        {
            return intVlue;
        }
    }
}



