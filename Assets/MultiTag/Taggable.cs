using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Taggable : MonoBehaviour
{
    public TagsHolder tHolder;
    public List<int> selectedTags;
    public List<int> oldTags;
    public int selectedTag;
    public int index;
    public bool CompareMyTag(string comparer)
    {
        bool contains = false;
        foreach (var item in selectedTags)
        {
            if (tHolder.tags[item] == comparer)
            {
                contains = true;
            }
        }
        return contains;
    }
    public bool ContainTag(string comparer)
    {
        bool contains = false;
        foreach (var item in selectedTags)
        {
            if (tHolder.tags[item] == comparer)
            {
                contains = true;
            }
        }
        return contains;
    }
}
