using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "WorldHolder", menuName = "WorldHolder")]
    public class WorldHolder : ScriptableObject
    {
        public int world_ID;
        public List<GameObject> targetElements;
        public GameObject finishCheckPoint;
        public GameObject checkPoint;
    }

}