using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataSystem;
using UnityEngine;

namespace DataSystem
{
    [System.Serializable]
    public class DataCenter : MonoBehaviour
    {
        public List<ScriptableObject> dataContainers;

        public DataRaw rawData;

        public bool FRESHBUILD;

        private void Awake()
        {

            //masterSwitch.dataCenter = this;
            //masterSwitch.rawData = rawData;
            if (PlayerPrefs.GetInt("FRESHBUILD") == 0)
            {
                ResetData();
                //Debug.LogError($"Fresh build : {FRESHBUILD}");
                PlayerPrefs.SetInt("FRESHBUILD", 1);
            }
            else
            {
                LoadUsingSaveDataHolder();
            }
        }
        public void SetDataCenter()
        {
            // if (PlayerPrefs.GetInt("FirstTime") == 0)
            // {
            //     PlayerPrefs.SetInt("FirstTime", 1);
            //     SaveData();
            // }
            // else
            // {
            //     LoadData();
            // }
        }


        public void SaveUsingSaveDataHolder()
        {
            //TODO: always adding new data - not really good, check for existing names.
            rawData = new DataRaw();
            for (int i = 0; i < dataContainers.Count; i++)
            {
                ISaveDataHolderJson iSaveData = dataContainers[i] as ISaveDataHolderJson;
                rawData.saveDataHolders.Add(iSaveData.GetMyData());
            }
            PlayerPrefs.SetString("JsonData", JsonUtility.ToJson(rawData));
            // print("Saved to player prefs: " + PlayerPrefs.GetString("JsonData"));
        }


        public void LoadUsingSaveDataHolder()
        {
            //TODO: implement get raw data from json;
            string playerPrefs = PlayerPrefs.GetString("JsonData");
            //Debug.LogError($"Loading data:  { playerPrefs}");
            if (string.IsNullOrEmpty(playerPrefs))
            {
                SaveUsingSaveDataHolder();
                return;

            }
            DataRaw tmp = JsonUtility.FromJson<DataRaw>(playerPrefs);

            if (dataContainers.Count == tmp.saveDataHolders.Count)
            {
                // same number of data sync all with save game;
                for (int i = 0; i < dataContainers.Count; i++)
                {
                    ISaveDataHolderJson iSaveData = dataContainers[i] as ISaveDataHolderJson;
                    if (iSaveData.GetMyData().name == tmp.saveDataHolders[i].name)
                    {
                        //Debug.LogError($"Data loaded: {tmp.saveDataHolders[i].jsondata.ToString()}");
                        iSaveData.SetMyData(tmp.saveDataHolders[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataContainers.Count; i++)
                {
                    ISaveDataHolderJson iSaveData = dataContainers[i] as ISaveDataHolderJson;
                    if (i < tmp.saveDataHolders.Count)
                    {
                        iSaveData.SetMyData(tmp.saveDataHolders[i]);
                    }
                }
            }
        }
        public void ResetData()
        {
            for (int i = 0; i < dataContainers.Count; i++)
            {
                ISaveDataHolderJson iSaveData = dataContainers[i] as ISaveDataHolderJson;
                //Debug.LogError($"Reset: {iSaveData.GetMyData().jsondata.ToString()}");
                iSaveData.ResetMyData();
            }
            PlayerPrefs.DeleteAll();
            SaveUsingSaveDataHolder();
        }

    } 
}