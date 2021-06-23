using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[CreateAssetMenu(fileName = "EventSystem", menuName = "ScriptableObjects/EventMessenger")]
public class EventSystemScriptable : ScriptableObject
{

    public static EventSystemScriptable aInstance { get; private set; }

    public UnityAction<int, int> OnWallDownSoreMultiplier;



    [RuntimeInitializeOnLoadMethod]
    public static void Init()
    {
        //aInstance = Resources.Load("EventSystemScriptable") as EventSystemScriptable;
        //Debug.LogError("Event system loaded: " + aInstance.name);
    }
}
