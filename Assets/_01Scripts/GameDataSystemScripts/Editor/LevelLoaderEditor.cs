using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(LevleLoader))]
public class LevelLoaderEditor : Editor
{
    SerializedProperty m_LevelsGameObjects;
    SerializedProperty m_PinyataLevel;
    SerializedProperty m_pinyataLevelPending_bool;
    SerializedProperty m_playerLevel;
    SerializedProperty m_OnLoadLevelCompleted;
    SerializedProperty m_circleLevelValue;
    SerializedProperty m_manualLevelLoad;
    SerializedProperty m_levelValue;
    SerializedProperty m_minLevelToRepeat;
    SerializedProperty m_maxLevelToRepeat;
    SerializedProperty m_repeatMinMax;
    SerializedProperty m_loopStartLevel;
    SerializedProperty m_levelLoaded;



    void OnEnable()
    {
        m_LevelsGameObjects = serializedObject.FindProperty("LevelsGameObjects");
        m_PinyataLevel = serializedObject.FindProperty("PinyataLevel");
        m_pinyataLevelPending_bool = serializedObject.FindProperty("pinyataLevelPending_bool");
        m_playerLevel = serializedObject.FindProperty("playerLevel");
        m_OnLoadLevelCompleted = serializedObject.FindProperty("OnLoadLevelCompleted");
        m_circleLevelValue = serializedObject.FindProperty("circleLevelValue");
        m_manualLevelLoad = serializedObject.FindProperty("manualLevelLoad");
        m_levelValue = serializedObject.FindProperty("levelValue");
        m_minLevelToRepeat = serializedObject.FindProperty("minLevelToRepeat");
        m_maxLevelToRepeat = serializedObject.FindProperty("maxLevelToRepeat");
        m_repeatMinMax = serializedObject.FindProperty("repeatMinMax");
        m_loopStartLevel = serializedObject.FindProperty("loopStartLevel");
        m_levelLoaded = serializedObject.FindProperty("levelLoaded");


    }


    public override void OnInspectorGUI()
    {
        LevleLoader tmp = target as LevleLoader;
        //The variables and GameObject from the MyGameObject script are displayed in the Inspector with appropriate labels
        EditorGUILayout.PropertyField(m_LevelsGameObjects, new GUIContent("Levels"));
        EditorGUILayout.PropertyField(m_manualLevelLoad, new GUIContent("Manual level load"));
        EditorGUILayout.PropertyField(m_PinyataLevel, new GUIContent("PinyataLevel"));
        EditorGUILayout.PropertyField(m_pinyataLevelPending_bool, new GUIContent("Pending pinyata load"));
        EditorGUILayout.PropertyField(m_playerLevel, new GUIContent("Player level"));
        EditorGUILayout.PropertyField(m_levelLoaded, new GUIContent("Level loaded bool"));

        //EditorGUILayout.PropertyField(m_worldCounter, new GUIContent("WorldCounter"));


        if (tmp.manualLevelLoad)
        {
            EditorGUILayout.PropertyField(m_repeatMinMax, new GUIContent("Repeat Min MaxLevels"));
            EditorGUILayout.PropertyField(m_circleLevelValue, new GUIContent("Current Level"));
            EditorGUILayout.PropertyField(m_minLevelToRepeat, new GUIContent("Min repeat level"));

            //tmp.circleLevelValue.Value = tmp.minLevelToRepeat;
            //tmp.playerLevel.Value = 0;

            if (!tmp.repeatMinMax)
            {
                if (GUILayout.Button("Load min level"))
                {
                    //if (tmp.minLevelToRepeat > tmp.LevelsGameObjects.Count - 1)
                    //{
                    //    tmp.LoadThisLevel(tmp.LevelsGameObjects.Count - 1);
                    //}
                    //else
                    //{
                    //    tmp.LoadThisLevel(tmp.minLevelToRepeat);
                    //}
                    tmp.circleLevelValue.Value = tmp.minLevelToRepeat;
                    EditorApplication.EnterPlaymode();
                }
                if (GUILayout.Button("Load Next level"))
                {
                    tmp.circleLevelValue.Value++;
                    EditorApplication.EnterPlaymode();
                }
            }
            else
            {
                EditorGUILayout.PropertyField(m_maxLevelToRepeat, new GUIContent("Max repeat level"));
                if (tmp.maxLevelToRepeat > tmp.LevelsGameObjects.Count - 1)
                {
                    tmp.maxLevelToRepeat = tmp.LevelsGameObjects.Count - 1;
                }
                tmp.circleLevelValue.Value = tmp.minLevelToRepeat;
            }

            //EditorGUILayout.PropertyField(m_myTextField, new GUIContent("My Text"), GUILayout.Height(20));
            //EditorGUILayout.PropertyField(m_useInt, new GUIContent("Use Int"));
            //EditorGUILayout.PropertyField(m_animateValueChage, new GUIContent("Animate value"));
            //EditorGUILayout.PropertyField(m_usePrefix, new GUIContent("Use prefix"));
            //EditorGUILayout.PropertyField(m_useSuffix, new GUIContent("Use sufix"));
            // EditorGUILayout.PropertyField(m_mainValue, new GUIContent("Asset refMainValue"));


            //strings to be enabled

            //    if (!tmp.useInt)
            //    {
            //        GUI.DrawTexture(texPos, GetTexture(tmp.useInt));
            //        EditorGUILayout.PropertyField(m_floatValue, new GUIContent("Float value"));
            //    }
            //    else
            //    {
            //        EditorGUILayout.PropertyField(m_useCurve, new GUIContent("Use Curve"));
            //        GUI.DrawTexture(texPos, GetTexture(tmp.useInt));
            //        EditorGUILayout.PropertyField(m_intValue, new GUIContent("Int value"));
            //    }
            //    if (tmp.usePrefix)
            //    {
            //        EditorGUILayout.PropertyField(m_prefix, new GUIContent("Prefix"));
            //    }
            //    if (tmp.useSufix)
            //    {
            //        EditorGUILayout.PropertyField(m_suFix, new GUIContent("Sufix"));
            //    }
            //    if (tmp.useCurve)
            //    {

            //        EditorGUILayout.PropertyField(m_intCurve, new GUIContent("int curve"));
            //        if (tmp.intCurve)
            //        {
            //            EditorGUILayout.PropertyField(m_progressionCurveInt, new GUIContent("Curve"));
            //        }
            //        else
            //        {
            //            EditorGUILayout.PropertyField(m_progressionCurveFloat, new GUIContent("Curve"));

            //        }
            //    }
            //}
            //else
            //{

            //    EditorGUILayout.PropertyField(m_useDefault, new GUIContent("use default slider"));
            //    if (tmp.useDefault)
            //    {
            //        EditorGUILayout.PropertyField(m_defaultSlider, new GUIContent("Default slider"));
            //    }
            //    else
            //    {
            //        EditorGUILayout.PropertyField(m_fillImage, new GUIContent("Fill Image"));

            //    }
            //    EditorGUILayout.PropertyField(m_floatValue, new GUIContent("Float value"));
            //}
            // Apply changes to the serializedProperty - always do this at the end of OnInspectorGUI.
        }
        else
        {
            EditorGUILayout.PropertyField(m_loopStartLevel, new GUIContent("LoopFromLevel"));
            if (tmp.loopStartLevel > tmp.LevelsGameObjects.Count - 1 || tmp.loopStartLevel < 0)
            {
                tmp.loopStartLevel = 0;
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}
