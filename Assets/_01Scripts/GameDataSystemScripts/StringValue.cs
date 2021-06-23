using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace DataSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "StringValue", menuName = "Values/StringValue")]
    public class StringValue : ScriptableObject
    {
        public string Name;
        public string Value;
        public UnityAction<string> MyValueChanged;
        public bool savable;
        public string defaultValue;
        public string MyValue
        {
            get
            {
                return Value;
            }
            set
            {
                //Debug.LogError($"Value set : {Name} - Value: {Value}");
                Value = value;
                MyValueChanged?.Invoke(Value);
            }
        }
    } 
}
