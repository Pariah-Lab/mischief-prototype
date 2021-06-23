using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawnerHandler : MonoBehaviour, IReferenceInjector<ISwarmManager>
{
    public GameObject ratPrefab;
    ISwarmManager swarmManager;
    GameObject tmpRat;
    public void SetMeUp(ISwarmManager myReference)
    {
        swarmManager = myReference;
        SpawnRat();
    }
    [ContextMenu("Spawn rat")]
    public void SpawnRat()
    {
        tmpRat = Instantiate(ratPrefab, swarmManager.GetMyTransform().position, Quaternion.identity);
    }
}
