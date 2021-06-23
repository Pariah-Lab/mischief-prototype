using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DataSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Restart", menuName = "ScriptableObjects/Restart")]
    public class RestartScriptableObject : ScriptableObject
    {
        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }
        public void LoadSceneAditive(int index)
        {
            SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        }
    }
}