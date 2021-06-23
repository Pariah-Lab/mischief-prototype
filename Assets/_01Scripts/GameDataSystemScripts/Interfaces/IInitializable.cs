using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



//Implement this interface by any class and assign the init order id, so it can be initialized through gameinitializer class. 
public interface IInitializable
{
    
    string myName { get; }
    int InitOrder { get; set; }
    void OnInitialized(UnityAction onInitialiezd);
    GameObject GetMyGameObject();
    string GetScriptName();
}
