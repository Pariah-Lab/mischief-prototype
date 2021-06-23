using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReferenceInjector<T>
{
    void SetMeUp(T myReference);
}