using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
[CreateAssetMenu(fileName = "TagsHolder", menuName = "TagsHolder")]
public class TagsHolder : ScriptableObject
{
    public string[] tags;
    
}
