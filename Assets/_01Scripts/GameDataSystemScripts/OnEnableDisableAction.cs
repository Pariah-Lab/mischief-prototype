using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableDisableAction : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnEnableAction;
    [SerializeField]
    public UnityEvent OnDisableAction;

    private void Start()
    {
        OnEnableAction?.Invoke();
    }
    private void OnEnable()
    {
        OnEnableAction?.Invoke();
    }
    private void OnDisable()
    {
        OnDisableAction?.Invoke();
    }
}
