using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwarmManager
{
    void OnSwarmableCreated(ISwarmable swarmable);
    void OnSwarmableDied(ISwarmable died);
    Transform GetMyTransform();
}
