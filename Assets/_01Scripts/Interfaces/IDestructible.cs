using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestructible 
{
    void TakeDamage(int damage, IMischievable mischievable);
}
