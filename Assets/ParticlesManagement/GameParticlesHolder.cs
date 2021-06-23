using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "ParticlesHolder", menuName = "ParticlesHolder")]
public class GameParticlesHolder : ScriptableObject
{
    public List<GameObject> particles;
}
