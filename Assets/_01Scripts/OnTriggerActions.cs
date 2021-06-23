using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerActions : MonoBehaviour
{
    public UnityEvent OnTriggerEnterAction;
    public UnityEvent OnTriggerExitAction;



    private void OnTriggerEnter(Collider other)
    {
            OnTriggerEnterAction?.Invoke();
        
    }
    private void OnTriggerExit(Collider other)
    {
            OnTriggerExitAction?.Invoke();
        
    }
}
