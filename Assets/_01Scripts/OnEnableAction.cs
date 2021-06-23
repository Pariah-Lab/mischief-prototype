
using UnityEngine;
using UnityEngine.Events;

public class OnEnableAction : MonoBehaviour
{
    [SerializeField] UnityEvent OnEnableActionInvoker;
    private void OnEnable()
    {
        OnEnableActionInvoker?.Invoke();
    }
}
