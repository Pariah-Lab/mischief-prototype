using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DataSystem;

[CustomEditor(typeof(ParticleWorker)), CanEditMultipleObjects]
public class ParticleWorker_Editor : Editor
{
    public GameParticlesHolder particlesHolder;
    static string[] SelectedItems;
    SerializedProperty ParticlesList;
    public IntValue syncIDParticleID;
    int index = 0;

    private void OnEnable()
    {

        ParticleWorker pm = target as ParticleWorker;
        index = pm.selectedid;
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ParticleWorker pm = target as ParticleWorker;
        
        DrawDefaultInspector();
        SelectedItems = new string[particlesHolder.particles.Count];
        for (int i = 0; i < particlesHolder.particles.Count; i++)
        {
            SelectedItems[i] = particlesHolder.particles[i].name;
        }
        pm.selectedid = EditorGUILayout.Popup(pm.selectedid, SelectedItems);
        if (GUILayout.Button("Set Values"))
        {
            syncIDParticleID.MyValue = pm.selectedid;
            pm.selectedName = SelectedItems[pm.selectedid];
            EditorUtility.SetDirty(pm);
        }
        if (Selection.gameObjects.Length > 1)
        {
            if (GUILayout.Button($"Set To all -{SelectedItems[syncIDParticleID.MyValue]}"))
            {
                for (int i = 0; i < Selection.gameObjects.Length; i++)
                {
                    if (Selection.gameObjects[i].GetComponent<ParticleWorker>() != null)
                    {
                        Selection.gameObjects[i].GetComponent<ParticleWorker>().selectedid = syncIDParticleID.MyValue;
                        Selection.gameObjects[i].GetComponent<ParticleWorker>().selectedName = SelectedItems[syncIDParticleID.MyValue];
                    }
                }
                pm.selectedName = SelectedItems[pm.selectedid];
                EditorUtility.SetDirty(pm);
            }
        }
        serializedObject.Update();
    }
}
