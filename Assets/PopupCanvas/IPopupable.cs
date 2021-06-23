using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPopupable
{
    void PopHere(Vector3 worldSpacePosition, string value);
}
