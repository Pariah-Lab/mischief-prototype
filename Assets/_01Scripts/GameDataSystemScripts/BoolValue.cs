using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DataSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "BoolValue", menuName = "Values/BoolValue")]
    public class BoolValue : ScriptableObject, ISaveDataHolderJson
    {
        public string Name;
        public bool Value;
        public UnityAction<bool> MyValueChanged;
        public bool savable;
        public bool defaultValue;
        public bool MyValue
        {
            get
            {
                return Value;
            }
            set
            {
                Value = value;
                MyValueChanged?.Invoke(Value);
            }
        }

        private void OnEnable()
        {
            Name = this.name;
            if (!savable)
            {
                Value = false;
            }
        }


        public void SetName()
        {
            Name = this.name;
        }
        //public Tuple<string, int> GetSavableData()
        //{
        //    Tuple<string, int> result = new Tuple<string, int>(Name, Value);
        //    return result;
        //}
        //public void SetSavable(Tuple<string, int> tple, bool reset)
        //{
        //    if (tple.Item1 == Name)
        //    {
        //        MyValue = tple.Item2;
        //    }
        //}
        class Booler
        {
            public string Name;
            public bool value;

            public Booler(string nme, bool vlue)
            {
                Name = nme;
                value = vlue;
            }
        }
        public SaveDataHolder GetMyData()
        {

            Booler tmp = new Booler(Name, Value);
            SaveDataHolder saveData = new SaveDataHolder(Name, JsonUtility.ToJson(tmp));
            return saveData;
        }

        public void SetMyData(SaveDataHolder loadedData)
        {
            string tmp = loadedData.jsondata.ToString();
            Booler tmpBInt = new Booler("", false);
            tmpBInt = JsonUtility.FromJson<Booler>(tmp);
            Value = tmpBInt.value;

        }
        public void ResetMyData()
        {
            Value = defaultValue;
        }
    } 
}
