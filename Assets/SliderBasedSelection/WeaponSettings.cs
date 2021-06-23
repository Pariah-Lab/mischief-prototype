using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataSystem;

[System.Serializable]
[CreateAssetMenu(fileName = "WeaponSettings", menuName = "WeaponConfig/WeaponSettings")]
public class WeaponSettings : ScriptableObject, ISaveDataHolderJson
{
    public int weapon_Id;
    public float fireRate;
    public float initialRotation;
    public int bulletsInClip;
    public float bulletPower;
    public int bulletDamage;
    public float bulletSpeed;
    public int clipSize;
    public GameObject bulletModel;
    public int unlockLevel;
    public bool unlocked;
    public bool reported;
    public float unlockProgression;
    public Sprite weaponImg;

    public SaveDataHolder GetMyData()
    {
        WeaponSettingsSavable svble = new WeaponSettingsSavable();
        svble.unlocked = unlocked;
        svble.unlockProgression = unlockProgression;
        svble.reported = reported;
        string data = JsonUtility.ToJson(svble);
        SaveDataHolder dataArray = new SaveDataHolder(name, data);
        return dataArray;

       
    }

    public void ResetMyData()
    {

        unlocked = false;
        reported = false;
        unlockProgression = 0f;
        if (this.name == "Gun_Settings")
        {
            unlockProgression = 100;
            unlocked = true;
            reported = true;
        }
    }

    public void SetMyData(SaveDataHolder loadedData)
    {
        WeaponSettingsSavable stat = new WeaponSettingsSavable();
        JsonUtility.FromJsonOverwrite(loadedData.jsondata, stat);
        unlocked = stat.unlocked;
        reported = stat.reported;
        unlockProgression = stat.unlockProgression;
    }
}
