using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateMeAfter : MonoBehaviour
{
    public float timer;

    private void OnEnable()
    {
        Invoke("Deactivate", timer);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
