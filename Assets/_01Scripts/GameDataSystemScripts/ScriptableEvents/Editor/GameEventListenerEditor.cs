using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Reflection;
using System;
using DataSystem;

[CustomEditor(typeof(GameEventListeners))]
public class GameEventListenerEditor: Editor
{
    SerializedProperty p_GameEvent;
    SerializedProperty p_delay;
    
    SerializedProperty p_matchedEvent;
    static string[] methods;
    static string[] ignoreMethods = new string[] { "Start", "Update" };
    private void OnEnable()
    {
        p_GameEvent = serializedObject.FindProperty("Event");
        p_delay = serializedObject.FindProperty("delay");
        p_matchedEvent = serializedObject.FindProperty("OnRaise");
    }
    public override void OnInspectorGUI()
    {
        GameEventListeners listeners = target as GameEventListeners;

        EditorGUILayout.PropertyField(p_GameEvent, new GUIContent("Event"));
        EditorGUILayout.PropertyField(p_delay, new GUIContent("Exec Delay"));

        if (listeners != null)
        {
            if (listeners.Event != null)
            {
                //int index;

                //try
                //{
                //    index = methods
                //        .Select((v, i) => new { Name = v, Index = i })
                //        .First(x => x.Name == listeners.MethodToCall)
                //        .Index;
                //}
                //catch
                //{
                //    index = 0;
                //}
                //methods =
                //listeners.Event.GetType()
                //.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) // Instance methods, both public and private/protected
                //.Where(x => x.DeclaringType == typeof(GameEvent)) // Only list methods defined in our own class
                //.Where(x => x.GetParameters().Length == 0 || x.GetParameters().Length == 1 || x.GetParameters().Length == 2 || x.GetParameters().Length == 3) // Make sure we only get methods with zero argumenrts
                //.Where(x => !ignoreMethods.Any(n => n == x.Name)) // Don't list methods in the ignoreMethods array (so we can exclude Unity specific methods, etc.)
                //.Select(x => x.Name)
                //.ToArray();
                //listeners.MethodToCall = methods[EditorGUILayout.Popup(index, methods)];

                FieldInfo[] fields = listeners.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                for (int i = 0; i < fields.Length; i++)
                {
                    //string tmp = methods[EditorGUILayout.Popup(index, methods)];
                    //string tmpListenerMethodTOCall = listeners.MethodToCall;
                    if (fields[i].Name.Contains(listeners.Event.GetMethodToCall))
                    {
                        p_matchedEvent = serializedObject.FindProperty(fields[i].Name);

                        //Debug.LogError($"field name { fields[i].Name}, property found by name { p_matchedEvent.name }");
                        EditorGUILayout.PropertyField(p_matchedEvent, new GUIContent(fields[i].Name), GUILayout.ExpandHeight(true));
                    }
                }
            }
        }

        if (listeners.Event != null)
        {
            //first find the correct method property based on name
            //m_myTextField = serializedObject.FindProperty("myTextField");
            //make that unity event visible;
            //EditorGUILayout.PropertyField(m_myTextField, new GUIContent("My Text"), GUILayout.Height(20));

            

        }
        serializedObject.ApplyModifiedProperties();
    }
}