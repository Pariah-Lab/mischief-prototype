using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSystem;

namespace DataSystem
{
    public interface ISaveDataHolderJson
    {
        SaveDataHolder GetMyData();
        void SetMyData(SaveDataHolder loadedData);
        void ResetMyData();
    } 
}
