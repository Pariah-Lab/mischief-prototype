using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace DataSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "FloatValue", menuName = "Values/FloatValue")]
    public class FloatValue : ScriptableObject, ISaveDataHolderJson
    {
        public string Name;
        public float Value;
        public UnityAction<float> MyValueChanged;
        public bool savable;
        public float MyValue
        {
            get
            {
                return Value;
            }
            set
            {
                Value = value;
                MyValueChanged?.Invoke(Value);
                // do the saving part;
            }
        }
        private void OnEnable()
        {
            Name = this.name;
            if (!savable)
            {
                Value = 0;
            }
        }

        public Tuple<string, float> GetSavableData()
        {
            Tuple<string, float> result = new Tuple<string, float>(Name, Value);
            return result;
        }
        public void SetSavable(Tuple<string, float> tple, bool reset)
        {
            if (tple.Item1 == Name)
            {
                MyValue = tple.Item2;
            }
        }

        public SaveDataHolder GetMyData()
        {
            FloatBasic tmp = new FloatBasic(Name, Value);
            SaveDataHolder saveData = new SaveDataHolder(Name, JsonUtility.ToJson(tmp));
            return saveData;
        }

        public void SetMyData(SaveDataHolder loadedData)
        {
            string tmp = loadedData.jsondata.ToString();
            Debug.Log("Float value: " + tmp);
            FloatBasic tmpBInt = new FloatBasic("", 0);
            tmpBInt = JsonUtility.FromJson<FloatBasic>(tmp);
            Value = tmpBInt.Value;

        }
        public void ResetMyData()
        {
            Value = 0;
        }
    } 
}
