using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace DataSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Vector3Value", menuName = "Values/Vector3Value")]
    public class Vector3Value : ScriptableObject
    {
        public string Name;
        public Vector3 Value;
        public UnityAction<Vector3> MyValueChanged;
        public bool savable;
        public Vector3 defaultValue;
        public Vector3 MyValue
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

        private void OnEnable()
        {
            Name = this.name;
            if (!savable)
            {
                Value = Vector3.zero;
            }
        }
        
        public void SetName()
        {
            Name = this.name;
        }

    }

}