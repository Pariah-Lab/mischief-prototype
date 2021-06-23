using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSystem;

[RequireComponent(typeof(AudioSource))]
public class SounderMixer : MonoBehaviour
{
    [SerializeField] BoolValue soundON;
    [SerializeField] AudioSource[] sources;
    [SerializeField] SoundClipsHolder audioClips;
    public float volume;
    int counter;
    int sourcesCounter = 0;
    public int maxCutsToMaxPitch;
    float lastCount;
    bool stopped;
    private void Awake()
    {
        foreach (var src in sources)
        {
            src.Stop();
            src.enabled = false;
        }
    }
    private void Start()
    {
        soundON.MyValueChanged += OnSoundValuechangedBool;

        foreach (var src in sources)
        {
            if (!soundON.MyValue)
            {
                src.Stop();
                src.enabled = false;
            }
            else
            {
                src.enabled = true;
                src.Play();
                src.volume = volume;
            }
        }
        
    }
    private void OnSoundValuechangedBool(bool value)
    {
        foreach (var src in sources)
        {
            if (!soundON.MyValue)
            {
                src.Stop();
                src.enabled = false;
            }
            else
            {
                src.enabled = true;
                src.Play();
                src.volume = volume;
            }
        }
    }
    [ContextMenu("TestAudio")]
    public void testAudio()
    {
        sources[0].PlayOneShot(audioClips.allClips[Random.Range(0, audioClips.allClips.Count)]);
    }
    public void PlaySound(int soundID)
    {
        if (!soundON.MyValue)
        {   
            return;
        }
        else
        {
            if (!sources[sourcesCounter].enabled)
            {
                sources[sourcesCounter].enabled = true;
            }   
            CancelInvoke("PitchHandler");
            sources[sourcesCounter].pitch = Utility.RemapValues(0, maxCutsToMaxPitch, 1f, 2f, Mathf.Clamp(counter, 0, maxCutsToMaxPitch)) + Random.Range(-0.2f, 0.2f);
            sources[sourcesCounter].PlayOneShot(audioClips.allClips[soundID]);
            counter++;
            sourcesCounter++;
            if (sourcesCounter >= sources.Length - 1)
            {
                sourcesCounter = 0;
            }
        
            //blender.PlaySequence(audioClips.allClips[soundID].name);
            Invoke("PitchHandler", 0.6f);
        }
    }
    private void PitchHandler()
    {
        counter = 0;
    }
    private void OnDisable()
    {
        soundON.MyValueChanged -= OnSoundValuechangedBool;
    }

}
