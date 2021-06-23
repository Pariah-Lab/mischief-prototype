using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSystem;
public class GlobalEventHolder : MonoBehaviour
{

    public static GlobalEventHolder _aInstance { get; set; }

    public GameEvent OnSwarmableCreated;
    public GameEvent OnSwarmableDied;
    public GameEvent OnGameSuccess;
    public GameEvent OnGameFailed;

    private void Awake()
    {   
        _aInstance = this;
    }

  
}
