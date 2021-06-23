using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Sounder)), CanEditMultipleObjects]
public class Sounder_Editor : Editor
{
    public SoundClipsHolder soundClipsHolder;
    static string[] selectedSounds;
    public override void OnInspectorGUI()
    {
        Sounder snd = target as Sounder;
        selectedSounds = new string[soundClipsHolder.allClips.Count];
        for (int z = 0; z < soundClipsHolder.allClips.Count; z++)
        {
            selectedSounds[z] = z.ToString() + " - " + soundClipsHolder.allClips[z].name;
        }
        for (int j = 0; j < snd.MySounds.Count; j++)
        {
            if (snd.MySounds.Count > 0)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(snd.MySounds[j].Name);
                snd.MySounds[j].index = EditorGUILayout.Popup(snd.MySounds[j].index, selectedSounds);
                if (GUILayout.Button("Play"))
                {
                    AudioSource asource = FindObjectOfType<AudioSource>();
                    if (asource != null)
                    {
                        asource.PlayOneShot(soundClipsHolder.allClips[snd.MySounds[j].index]); 
                    }
                }
                if (GUILayout.Button("Stop"))
                {
                    AudioSource asource = FindObjectOfType<AudioSource>();
                    if (asource != null)
                    {
                        asource.Stop();
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        if (snd.playOnEnable)
        {
            bool onEnableAssigned = false;
            for (int i = 0; i < snd.MySounds.Count; i++)
            {
                if (snd.MySounds[i].Name == "OnEnable")
                {
                    onEnableAssigned = true;
                }
            }
            if (!onEnableAssigned)
            {
                SoundIndexerHolder sndIndx = new SoundIndexerHolder();
                sndIndx.index = 0;
                sndIndx.Name = "OnEnable";
                snd.MySounds.Add(sndIndx);
                onEnableAssigned = true;
            }
        }
        else
        {   
            for (int i = 0; i < snd.MySounds.Count; i++)
            {
                if (snd.MySounds[i].Name == "OnEnable")
                {
                    snd.MySounds.RemoveAt(i);
                }
            }
            
        }
        if (snd.playOnDisable)
        {
            bool onDisableAssigned = false;
            for (int i = 0; i < snd.MySounds.Count; i++)
            {
                if (snd.MySounds[i].Name == "OnDisable")
                {
                    onDisableAssigned = true;
                }
            }
            if (!onDisableAssigned)
            {
                SoundIndexerHolder sndIndx = new SoundIndexerHolder();
                sndIndx.index = 0;
                sndIndx.Name = "OnDisable";
                snd.MySounds.Add(sndIndx);
                onDisableAssigned = true;
            }
        }
        else
        {
            for (int i = 0; i < snd.MySounds.Count; i++)
            {
                if (snd.MySounds[i].Name == "OnDisable")
                {
                    snd.MySounds.RemoveAt(i);
                }
            }
        }
        if (GUILayout.Button("Save"))
        {   
            EditorUtility.SetDirty(snd);
        }
        DrawDefaultInspector();
    }
}
