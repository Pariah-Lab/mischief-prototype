using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DataSystem;
public class Sounder : MonoBehaviour
{
    [SerializeField] UnityEvent OnSoundPlayed;
    public List<SoundIndexerHolder> MySounds = new List<SoundIndexerHolder> ();
    GameEvent OnSoundRequested;
    List<int> rndmizer = new List<int>();
    public bool playOnEnable;
    public bool playOnDisable;
    SounderMixer mixer;
    private void Awake()
    {
        mixer = FindObjectOfType<SounderMixer>();
    }
   

   
    private void OnEnable()
    {
        if (playOnEnable)
        {
            PlaySoundHandler(GetRandomIndexOfThisName("OnEnable"));
        }
    }
    private void OnDisable()
    {
        if (playOnDisable)
        {
            PlaySoundHandler(GetRandomIndexOfThisName("OnDisable"));
        }
    }

    public void PlayRandom()
    {
        PlaySoundHandler(GetRandomIndexOfThisName("OnDefault"));
    }
    public void PlayDefault()
    {
        PlaySoundHandler(GetRandomIndexOfThisName("OnDefault"));
    }
    
    public void PlaySoundHandler(int id)
    {
        if (mixer != null)
        {
            mixer.PlaySound(id);
        }
        else
        {
            mixer = FindObjectOfType<SounderMixer>();
            if (mixer != null)
            {
                mixer.PlaySound(id); 
            }
        }
        OnSoundPlayed?.Invoke();
    }
    public void PlaySoundHandler(string criteria)
    {
        if (mixer != null)
        {
            mixer.PlaySound(GetRandomIndexOfThisName(criteria));
        }
        OnSoundPlayed?.Invoke();
    }
    public int GetRandomIndexOfThisName(string namer)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < MySounds.Count; i++)
        {
            if (MySounds[i].Name == namer)
            {
                indexes.Add(MySounds[i].index);
            }
        }
        return indexes[Random.Range(0, indexes.Count)];
    }
    public List<int> GetIndexOfThisName(string namer)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < MySounds.Count; i++)
        {
            if (MySounds[i].Name == namer)
            {
                indexes.Add(MySounds[i].index);
            }
        }
        return indexes;
    }
}
