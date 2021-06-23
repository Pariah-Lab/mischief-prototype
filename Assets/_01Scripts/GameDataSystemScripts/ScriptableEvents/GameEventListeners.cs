using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace DataSystem
{
    [System.Serializable]
    public class EventVector3 : UnityEvent<Vector3> { }
    [System.Serializable]
    public class EventInt : UnityEvent<int> { }
    [System.Serializable]
    public class EventFloat : UnityEvent<float> { }
    [System.Serializable]
    public class EventString : UnityEvent<string> { }
    [System.Serializable]
    public class EventBool : UnityEvent<bool> { }


    [System.Serializable]
    public class EventSomeoneDied : UnityEvent<GameObject, float> { }

    [System.Serializable]
    public class EventIntIntVector3 : UnityEvent<int, Vector3> { }
    [System.Serializable]
    public class EventTransform : UnityEvent<Transform> { }
    [System.Serializable]
    public class EventISwarmable : UnityEvent<ISwarmable> { }





    public class GameEventListeners : MonoBehaviour
    {
        public float delay = 0;
        public GameEvent Event;
        public UnityEvent OnRaiseEmpty;
        public EventVector3 OnRaiseVector3;
        public EventInt OnRaiseInt;
        public EventFloat OnRaiseFloat;
        public EventString OnRaiseString;
        public EventBool OnRaiseBool;
        public EventSomeoneDied OnRaiseGameObjectFloat;
        public EventIntIntVector3 OnRaiseIntVector3;
        public EventTransform OnRaiseTransform;
        public EventISwarmable OnRaiseISwarmable;
        public delegate void OnDelay();
        public string MethodToCall;

        public void RaiseEmpty()
        {
            if (delay > 0)
            {
                StartCoroutine(Delay(() => OnRaiseEmpty.Invoke()));
            }
            else
            {
                OnRaiseEmpty.Invoke();
            }
        }
        public void RaiseVector3(Vector3 position)
        {
            OnRaiseVector3?.Invoke(position);
        }
        public void RaiseInt(int value)
        {
            if (delay > 0)
            {
                StartCoroutine(Delay(() => OnRaiseInt?.Invoke(value)));
            }
            else
            {
                OnRaiseInt?.Invoke(value);
            }
        }
        public void RaiseFloat(float value)
        {
            OnRaiseFloat?.Invoke(value);
        }

        public void RaiseBool(bool value)
        {
            OnRaiseBool?.Invoke(value);
        }

        internal void RaiseISwarmable(ISwarmable swarmable)
        {
            OnRaiseISwarmable?.Invoke(swarmable);
        }

        public void RaiseString(string value)
        {
            OnRaiseString?.Invoke(value);
        }
        public void RaiseGameObjectFloat(GameObject go, float respawnDelay)
        {
            OnRaiseGameObjectFloat?.Invoke(go, respawnDelay);
        }
        public void RaiseIntVector3(int v1, Vector3 pos)
        {
            OnRaiseIntVector3?.Invoke(v1, pos);
        }
        public void RaiseTransform(Transform value)
        {
            OnRaiseTransform?.Invoke(value);
        }
        public IEnumerator Delay(OnDelay delayDelegate)
        {
            yield return new WaitForSeconds(delay);
            delayDelegate?.Invoke();

        }
        private void OnEnable()
        {
            Event.RegisterListener(this);
        }
        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }
    } 
}
