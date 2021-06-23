using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="SoundClips", menuName ="SoundClip")]
public class SoundClipsHolder : ScriptableObject
{
    public List<AudioClip> allClips;
}
