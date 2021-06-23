using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class SwarmManager : MonoBehaviour, ISwarmManager, IInitializable
{
    public List<ISwarmable> mySwarmables = new List<ISwarmable>();

    public string myName => gameObject.name;
    public int initOrder;
    public int InitOrder { get => initOrder; set => initOrder = value; }

    private void Update()
    {
        ManageSwarmPositions();
    }
    public void OnSwarmableCreated(ISwarmable swarmable)
    {
        if (mySwarmables != null && !mySwarmables.Contains(swarmable))
        {
            mySwarmables.Add(swarmable);
            //implement swarm point to follow
        }
    }
    
    public void OnSwarmableDied(ISwarmable swarmable)
    {
        if (mySwarmables != null && mySwarmables.Contains(swarmable))
        {
            mySwarmables.Remove(swarmable);
            //implement swarm point to follow
        }
    }
    void ManageSwarmPositions()
    {
        for (int i = 0; i < mySwarmables.Count; i++)
        {
            mySwarmables[i].SetMyDestination(transform);
        }
    }
    public Transform GetMyTransform()
    {
        return transform;
    }

    public void OnInitialized(UnityAction onInitialiezd)
    {
        IEnumerable<IReferenceInjector<ISwarmManager>> references = FindObjectsOfType<MonoBehaviour>().OfType<IReferenceInjector<ISwarmManager>>();
        foreach (var rfc in references)
        {
            rfc.SetMeUp(this);
        }
        onInitialiezd?.Invoke();
    }

    public GameObject GetMyGameObject()
    {
        return gameObject;
    }

    public string GetScriptName()
    {
        return this.GetComponent<MonoBehaviour>().name;
    }
}
