using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSystem;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
//using UnityEngine.ResourceManagement.ResourceLocations;


public class LevleLoader : MonoBehaviour
{
    //public List<AssetReference> Levels;
    public List<GameObject> LevelsGameObjects;
    public GameObject PinyataLevel;
    public BoolValue pinyataLevelPending_bool;
    public IntReferenceValue playerLevel;
    public GameEvent OnLoadLevelCompleted;
    public BoolValue levelLoaded;
    public IntReferenceValue circleLevelValue;
    public int levelValue;
    public bool manualLevelLoad;
    public bool repeatMinMax;
    public int minLevelToRepeat;
    public int maxLevelToRepeat;
    public int loopStartLevel;

    private void Awake()
    {
        if (manualLevelLoad)
        {
            if (repeatMinMax)
            {
                RepeatTheseLevels();
            }
            else
            {
                LoadMinLevel();
            }
        }
        else
        {
            LoadLevelsHardCore();
            //if (!pinyataLevelPending_bool.MyValue)
            //{

            //}
            //else
            //{
            //    LoadPinyataLevel();
            //}
        }
        //OnLoadLevelCompleted.RaiseEmpty();
        levelLoaded.MyValue = true;
    }
    private void Start()
    {
        //LoadLevelAsync();

    }
    public void LoadMinLevel()
    {
        GameObject tmp = Instantiate(LevelsGameObjects[minLevelToRepeat], new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void RepeatTheseLevels()
    {
        circleLevelValue.Value++;

        if (circleLevelValue.Value > maxLevelToRepeat)
        {
            circleLevelValue.Value = minLevelToRepeat;
        }
        GameObject tmp = Instantiate(LevelsGameObjects[circleLevelValue.Value], new Vector3(0, 0, 0), Quaternion.identity);

    }
    public void OnLevelSuccessful()
    {
        if (!repeatMinMax || !manualLevelLoad)
        {
            //playerLevel.Value++;
            //circleLevelValue.Value++;
            
            if (circleLevelValue.Value > LevelsGameObjects.Count - 1)
            {
                circleLevelValue.Value = loopStartLevel;
            }
        }
    }
    public void LoadPinyataLevel()
    {   
        GameObject tmp = Instantiate(PinyataLevel, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void LoadLevelsHardCore()
    {
        if (playerLevel.Value < LevelsGameObjects.Count - 1)
        {
            GameObject tmp = Instantiate(LevelsGameObjects[playerLevel.Value], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            if (circleLevelValue.Value > LevelsGameObjects.Count - 1 || circleLevelValue.Value < loopStartLevel)
            {
                circleLevelValue.Value = loopStartLevel;
            }
            GameObject tmp = Instantiate(LevelsGameObjects[circleLevelValue.Value], new Vector3(0, 0, 0), Quaternion.identity);
        }
        //if (!repeatMinMax || !manualLevelLoad)
        //{
        //    if (playerLevel.Value < LevelsGameObjects.Count)
        //    {
        //        GameObject tmp = Instantiate(LevelsGameObjects[playerLevel.Value], new Vector3(0, -95f, 0), Quaternion.identity);
        //    }
        //    else
        //    {
        //        GameObject tmp = Instantiate(LevelsGameObjects[circleLevelValue.Value], new Vector3(0, -95f, 0), Quaternion.identity);
        //    } 
        //}
        //else
        //{
        //    if (circleLevelValue.Value < maxLevelToRepeat)
        //    {
        //        circleLevelValue.Value++;
        //    }
        //    else
        //    {
        //        circleLevelValue.Value = minLevelToRepeat;
        //    }
        //    GameObject tmp = Instantiate(LevelsGameObjects[circleLevelValue.Value], new Vector3(0, -95f, 0), Quaternion.identity);
        //}
    }
    public void LoadThisLevel(int levelNumber)
    {
        if (levelNumber < LevelsGameObjects.Count)
        {
            GameObject tmp = Instantiate(LevelsGameObjects[levelNumber], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Debug.Log("Exceeded level number");
        }
        circleLevelValue.Value++;
    }
    //public void LoadLevelAsync()
    //{
    //    Levels[playerLevel.Value].InstantiateAsync(new Vector3(0, -95f, 0), Quaternion.identity).Completed += (asyncOperationHandle) =>
    //    {
    //        Debug.LogError("Level loaded");

    //        OnLoadLevelCompleted.Raise();
    //    };

    //}
    private void OnDisable()
    {
        //Levels[playerLevel.Value].ReleaseAsset();
        levelLoaded.MyValue = false;
    }

}
