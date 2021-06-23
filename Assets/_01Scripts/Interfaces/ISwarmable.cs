using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwarmable
{
   
    Transform GetMyTransform();
    void SetMyDestination(Transform followPoint);
    void Die();
}
