
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//using Boomlagoon.JSON;


namespace DataSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "IntValue", menuName = "Values/IntValue")]
    public class IntValue : ScriptableObject, ISaveDataHolderJson
    {
        public string Name;
        public int Value;
        public UnityAction<int> MyValueChanged;
        public bool savable;
        public int defaultValue;
        public int MyValue
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
                if (defaultValue != 0)
                {
                    Value = defaultValue;
                }
                else
                {
                    Value = 0;
                }
            }
        }
        public void AutoIncreaseByOne()
        {
            MyValue++;
        }

        public void SetName()
        {
            Name = this.name;
        }

        public SaveDataHolder GetMyData()
        {
            IntBasic tmp = new IntBasic(Name, Value);
            SaveDataHolder saveData = new SaveDataHolder(Name, JsonUtility.ToJson(tmp));
            return saveData;
        }

        public void SetMyData(SaveDataHolder loadedData)
        {
            // if (loadedData != null)
            // {
            //     Debug.Log("Loaded data not null: " + loadedData.name);
            //     if (loadedData.jsondata != null)
            //     {
            //         Debug.Log("Loaded data  DATA not null: " + loadedData.jsondata.ToString());

            //     }
            //     else
            //     {

            //         Debug.Log("Loaded data  DATA null ");
            //     }
            // }
            // else
            // {
            //     Debug.Log("Loaded data null");

            // }
            string tmp = loadedData.jsondata.ToString();
            IntBasic tmpBInt = new IntBasic("", 0);
            tmpBInt = JsonUtility.FromJson<IntBasic>(tmp);
            Value = tmpBInt.Value;

        }
        public void ResetMyData()
        {
            Value = defaultValue;
        }
    }

}