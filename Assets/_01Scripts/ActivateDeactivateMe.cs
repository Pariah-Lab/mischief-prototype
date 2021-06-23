using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ActivateDeactivateMe : MonoBehaviour, IActivatable
{
    bool visited = false;
    private void Start()
    {
        if (!visited)
        {
            DeactivateMe();
        }
    }
    public void ActivateMe()
    {
        visited = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void DeactivateMe()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
