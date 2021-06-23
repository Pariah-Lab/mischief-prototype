using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Reflection;
using System;
using DataSystem;


[CustomEditor(typeof(GameEvent))]
public class GameEventEditor: Editor
{
	static string[] methods;
	static string[] ignoreMethods = new string[] { "Start", "Update" };
    SerializedProperty m_lockedMethod;
    SerializedProperty m_methodSet;
    SerializedProperty m_DefaultGameEventTOCall;
    SerializedProperty m_registeredListeners;
    SerializedProperty m_references;
    static GameEventEditor()
	{
		Debug.Log("Assigning method");
		methods =
			typeof(GameEvent)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) // Instance methods, both public and private/protected
			.Where(x => x.DeclaringType == typeof(GameEvent)) // Only list methods defined in our own class
            .Where(x => x.GetParameters().Length == 1 || x.GetParameters().Length == 0 || x.GetParameters().Length == 2 || x.GetParameters().Length == 3 || x.GetParameters().Length == 4 || x.GetParameters().Length == 5) // Make sure we only get methods with zero argumenrts
            .Where(x => !ignoreMethods.Any(n => n == x.Name)) // Don't list methods in the ignoreMethods array (so we can exclude Unity specific methods, etc.)
			.Select(x => x.Name)
			.ToArray();
	}



	public void AssignMethod()
    {

		methods =
			typeof(GameEvent)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) // Instance methods, both public and private/protected
			.Where(x => x.DeclaringType == typeof(GameEvent)) // Only list methods defined in our own class
			.Where(x => x.GetParameters().Length == 1 || x.GetParameters().Length == 0 || x.GetParameters().Length == 2 || x.GetParameters().Length == 3 || x.GetParameters().Length == 4 || x.GetParameters().Length == 5) // Make sure we only get methods with zero argumenrts
			.Where(x => !ignoreMethods.Any(n => n == x.Name)) // Don't list methods in the ignoreMethods array (so we can exclude Unity specific methods, etc.)
			.Select(x => x.Name)
			.ToArray();
	}

    public override void OnInspectorGUI()
    {

        m_lockedMethod = serializedObject.FindProperty("lockedMethod");
        m_methodSet = serializedObject.FindProperty("methodSet");
        m_DefaultGameEventTOCall = serializedObject.FindProperty("DefaultGameEventTOCall");
        m_registeredListeners = serializedObject.FindProperty("registeredListeners");
        m_references = serializedObject.FindProperty("references");
        EditorGUILayout.PropertyField(m_lockedMethod, new GUIContent("SavedMethod"), GUILayout.Height(20), GUILayout.ExpandHeight(true));
        EditorGUILayout.PropertyField(m_methodSet, new GUIContent("method lock"), GUILayout.ExpandHeight(true));
        EditorGUILayout.PropertyField(m_DefaultGameEventTOCall, new GUIContent("AlwaysRaise"), GUILayout.ExpandHeight(true));
        EditorGUILayout.PropertyField(m_registeredListeners, new GUIContent("Listeners"), GUILayout.ExpandHeight(true));
        EditorGUILayout.PropertyField(m_references, new GUIContent("AllReferences"), GUILayout.ExpandHeight(true));


        GameEvent obj = target as GameEvent;

        //UnityEngine.Object[] rootes = new UnityEngine.Object[1];
        //rootes[0] = obj as UnityEngine.Object;
        //UnityEngine.Object[] dependencies = EditorUtility.CollectDependencies(rootes);
        //obj.references = new string[dependencies.Length];
        //for (int i = 0; i < dependencies.Length; i++)
        //{
        //    obj.references[i] = dependencies[i].name.ToString();
        //}

        if (obj != null)
        {
            int index;
            try
            {
                index = methods
                    .Select((v, i) => new { Name = v, Index = i })
                    .First(x => x.Name == obj.MethodToCall)
                    .Index;
                AssignMethod();
                if (!obj.methodSet)
                {
                    obj.lockedMethod = index;
                }
                //else
                //{
                //    //searchi index by the curren tmethod name
                //    obj.lockedMethod = methods
                //    .Select((v, i) => new { Name = v, Index = i })
                //    .First(x => x.Name == obj.MethodToCall)
                //    .Index;
                //}
            }
            catch
            {
                index = 0;
            }

            obj.MethodToCall = methods[EditorGUILayout.Popup(obj.lockedMethod, methods)];
            //if (obj.methodSet)
            //{

            //}
            //else
            //{
            //    obj.MethodToCall = methods[EditorGUILayout.Popup(index, methods)];
            //}
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(obj);
        }
    }
}