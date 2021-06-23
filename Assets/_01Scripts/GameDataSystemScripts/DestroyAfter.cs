using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float timer = 5f;
    private void OnEnable()
    {
        Destroy(gameObject, timer);
    }

   
}
