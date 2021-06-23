using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeactivateAfterANimationEnd : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] public UnityAction OnAnimationEnded;
    [SerializeField] public UnityAction OnAnimationStarted;
    public bool destroyObjectONEnd;

    public void OnClipStarted()
    {
        OnAnimationStarted?.Invoke();
    }
    public void OnClipEnd()
    {
        OnAnimationEnded?.Invoke();
        if (destroyObjectONEnd)
        {
            Destroy(gameObject, 0.01f);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
