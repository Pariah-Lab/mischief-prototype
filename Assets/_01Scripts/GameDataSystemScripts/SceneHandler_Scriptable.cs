using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
[CreateAssetMenu(fileName = "SceneHandler", menuName = "SceneHandler")]
public class SceneHandler_Scriptable : ScriptableObject
{
   public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
