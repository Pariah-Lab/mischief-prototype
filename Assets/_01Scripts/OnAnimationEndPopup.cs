using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAnimationEndPopup : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnAnimationEndEvent;
    public void OnAnimationEnded()
    {
        OnAnimationEndEvent?.Invoke();
        //Test backupa
    }
}
