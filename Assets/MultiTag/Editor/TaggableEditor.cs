using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Taggable)), CanEditMultipleObjects]

public class TaggableEditor : Editor
{
    static string[] SelectedItems;
    SerializedProperty ParticlesList;
    int index = 0;


    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        Taggable pm = target as Taggable;
        if (pm.tHolder != null)
        {
            //Debug.LogError($"Selection length {Selection.gameObjects.Length}");
            DrawDefaultInspector();

            for (int i = 0; i < pm.selectedTags.Count; i++)
            {
                pm.selectedTags[i] = EditorGUILayout.Popup(pm.selectedTags[i], pm.tHolder.tags);

            }
            for (int j = 0; j < pm.selectedTags.Count; j++)
            {
                if (pm.selectedTags[j] != pm.oldTags[j])
                {
                    pm.oldTags[j] = pm.selectedTags[j];
                    EditorUtility.SetDirty(pm);
                }
            }
            //pm.selectedTag = EditorGUILayout.Popup(pm.selectedTag, pm.tHolder.tags);


            if (pm.selectedTag != pm.index)
            {
                pm.index = pm.selectedTag;
                EditorUtility.SetDirty(pm);
            }
            serializedObject.Update();
        }
        else
        {
            pm.tHolder = Resources.Load<TagsHolder>("GameSettings/TagsHolder");
        }

        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            Taggable slctionTgble = Selection.gameObjects[i].GetComponent<Taggable>();
            if (slctionTgble != null && slctionTgble != pm)
            {
                if (slctionTgble.selectedTags != pm.selectedTags)
                {
                    slctionTgble.selectedTags = pm.selectedTags;
                    EditorUtility.SetDirty(slctionTgble);

                }
                if (slctionTgble.oldTags != pm.oldTags)
                {
                    slctionTgble.oldTags = pm.oldTags;
                    EditorUtility.SetDirty(slctionTgble);
                }
            }
        }
        if (GUILayout.Button("Add Tag"))
        {
            //for (int i = 0; i < Selection.gameObjects.Length; i++)
            //{
            //    Taggable slctionTgble = Selection.gameObjects[i].GetComponent<Taggable>();
            //    if (slctionTgble != null && slctionTgble != pm)
            //    {
            //        slctionTgble.selectedTags.Add(0);
            //        slctionTgble.oldTags.Add(0);
            //        EditorUtility.SetDirty(slctionTgble);
            //    }
            //}
            pm.selectedTags.Add(0);
            pm.oldTags.Add(0);
            EditorUtility.SetDirty(pm);
        }
        if (GUILayout.Button("Remove Tag"))
        {
            //for (int i = 0; i < Selection.gameObjects.Length; i++)
            //{
            //    Taggable slctionTgble = Selection.gameObjects[i].GetComponent<Taggable>();
            //    if (slctionTgble != null && slctionTgble != pm)
            //    {
            //        slctionTgble.selectedTags.RemoveAt(slctionTgble.selectedTags.Count - 1);
            //        slctionTgble.oldTags.RemoveAt(slctionTgble.selectedTags.Count - 1);
            //        EditorUtility.SetDirty(slctionTgble);
            //    } 
            //}
            pm.selectedTags.RemoveAt(pm.selectedTags.Count - 1);
            pm.oldTags.RemoveAt(pm.oldTags.Count - 1);
            EditorUtility.SetDirty(pm);
        }
        serializedObject.Update();
    }
}
