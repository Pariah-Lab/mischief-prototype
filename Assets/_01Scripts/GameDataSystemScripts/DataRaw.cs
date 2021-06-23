using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DataSystem
{

    [System.Serializable]
    public class DataRaw
    {
        // public List<IntBasic> intValues = new List<IntBasic>();
        // public List<FloatBasic> floatValues = new List<FloatBasic>();
        // public List<WeaponStats> weaponDataStats;
        public List<SaveDataHolder> saveDataHolders = new List<SaveDataHolder>();
    }
    [Serializable]
    public class IntBasic
    {
        public string Name;
        public int Value;
        public void FollowThisMethid()
        {
            Debug.Log("Successfully invoked from editor script and reflection");
        }
        public IntBasic(string nme, int vlue)
        {
            Name = nme;
            Value = vlue;
        }
    }
    [Serializable]
    public class FloatBasic
    {
        public string Name;
        public float Value;

        public FloatBasic(string nme, float vlue)
        {
            Name = nme;
            Value = vlue;
        }
    }
    [Serializable]
    public class SaveDataHolder
    {
        public string name;
        public string jsondata;
        public SaveDataHolder(string nme, string dta)
        {
            name = nme;
            jsondata = dta;
        }
    } 
}