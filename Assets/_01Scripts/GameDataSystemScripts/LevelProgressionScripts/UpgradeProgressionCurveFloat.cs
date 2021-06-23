using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ProgressionCurveFloat", menuName = "ScriptableObjects/ProgressionCurveFloat")]
public class UpgradeProgressionCurveFloat : ScriptableObject
{
    public string Name;
    public AnimationCurve lvlProgressionCurve;
    public int numberOfLevels;
    public float maxLevel;
    public float startLevel;
    public float[] levels;
    public int Level;

    public void SetLevelPoints()
    {
        levels = new float[numberOfLevels];
        for (int i = 0; i < numberOfLevels; i++)
        {
            float curveAtPoint = Utility.RemapValues(0f, 1f, startLevel, maxLevel, lvlProgressionCurve.Evaluate(Utility.RemapValues(0, numberOfLevels, 0, 1, i)));
            levels[i] = curveAtPoint;
            //lvlMark = levels[i];
        }
    }
    public float GetValueAtLevel(int level)
    {
        if (levels.Length > 0)
        {
            if (level > levels.Length - 1)
            {
                float finalResultIncrement = levels[levels.Length -1];
                //float differenceInOverReachedLevel = level - levels.Length - 1;
                //finalResultIncrement = levels[levels.Length - 1] - levels[levels.Length - 2];
                //finalResultIncrement = levels[levels.Length - 1] + (finalResultIncrement * differenceInOverReachedLevel);
                return finalResultIncrement;
            }
            else
            {
                return levels[level];
            }
        }
        else
        {
            SetLevelPoints();
            if (level < levels.Length - 1)
            {
                return levels[level];
            }
            else
            {
                return levels[levels.Length - 1];
            }
        }
    }
    private void OnEnable()
    {
        Name = this.name;
        SetLevelPoints();
    }
    public Tuple<string, int> GetSavableData()
    {
        Tuple<string, int> result = new Tuple<string, int>(Name, Level);
        return result;
    }
    public void SetSavable(Tuple<string, int> tple)
    {
        if (tple.Item1 == Name)
        {
            Level = tple.Item2;
        }
    }
}