using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public delegate int OnInitializedDoneCallback1();
[System.Serializable]
public class InitializablesHolder
{
    public string Name;
    public int intOrder;
    public IInitializable initializableObject;
    public GameObject myInitializable;
    public IInitializable GetInitializable()
    {
        //intOrder = initializableObject.InitOrder;
        //return initializableObject;
        return myInitializable.GetComponent<IInitializable>();
    }
    public InitializablesHolder(IInitializable init, GameObject myInit, string nme)
    {

        initializableObject = init;
        intOrder = initializableObject.InitOrder;
        myInitializable = myInit;
        Name = nme;
    }
}
//[System.Serializable]
//public class InitializablesHolderList: ReorderableArray<InitializablesHolder>
//{

//}
public interface ITestMeList
{
    string myName { get; set; }
    int  tesTNumber{ get; set; }
    void OnInitialized(UnityAction onInitialiezd);
    GameObject GetMyGameObject();
}