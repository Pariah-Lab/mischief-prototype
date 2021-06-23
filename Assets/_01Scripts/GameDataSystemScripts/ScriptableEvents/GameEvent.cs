using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace DataSystem
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        public string MethodToCall;
        public List<GameEventListeners> listeners = new List<GameEventListeners>();
        public UnityAction OnRaiseEmpty;
        public UnityAction<Vector3> OnRaiseVector3;
        public UnityAction<int> OnRaiseInt;
        public UnityAction<float> OnRaiseFloat;
        public UnityAction<string> OnRaiseString;
        public UnityAction<bool> OnRaiseBool;
        public UnityAction<GameObject, float> OnSomeoneDied;
        public UnityAction<int, Vector3> OnRaiseIntVector3;
        public UnityAction<Transform> OnRaiseTransform;
        public UnityAction<ISwarmable> OnRaiseISwarmable;
        public EventHandler OnRequestedComponent;
        public bool methodSet;
        public int lockedMethod;
        public List<string> registeredListeners;
        public GameEvent DefaultGameEventTOCall;
        public string[] references;
        public string GetMethodToCall { get => MethodToCall; }

        //public UnityAction<Tuple> OnPlayableCrashed; 
        public void RaiseEmpty()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].RaiseEmpty();

            }
            OnRaiseEmpty?.Invoke();
            if (DefaultGameEventTOCall != null)
            {
                DefaultGameEventTOCall.RaiseEmpty();
            }
        }
        public void RaiseIntVector3(int value1,Vector3 pos)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].RaiseIntVector3(value1, pos);
            }
            OnRaiseIntVector3?.Invoke(value1,  pos);
            if (DefaultGameEventTOCall != null)
            {
                DefaultGameEventTOCall.RaiseEmpty();
            }
        }
        public void RaiseISwarmable(ISwarmable swarmable)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].RaiseISwarmable(swarmable);
            }
            OnRaiseISwarmable?.Invoke(swarmable);
            if (DefaultGameEventTOCall != null)
            {
                DefaultGameEventTOCall.RaiseEmpty();
            }
        }
        public void RaiseVector3(Vector3 position)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].RaiseVector3(position);
            }
            OnRaiseVector3?.Invoke(position);
            if (DefaultGameEventTOCall != null)
            {
                DefaultGameEventTOCall.RaiseEmpty();
            }
        }

        public void RaiseInt(int value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].RaiseInt(value);
            }
            OnRaiseInt?.Invoke(value);
            if (DefaultGameEventTOCall != null)
            {
                DefaultGameEventTOCall.RaiseEmpty();
            }
        }
        public void RaiseTransform(Transform value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].RaiseTransform(value);
            }
            OnRaiseTransform?.Invoke(value);
            if (DefaultGameEventTOCall != null)
            {
                DefaultGameEventTOCall.RaiseEmpty();
            }
        }
        public void RaiseFloat(float value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].RaiseFloat(value);
            }
            OnRaiseFloat?.Invoke(value);
            if (DefaultGameEventTOCall != null)
            {
                DefaultGameEventTOCall.RaiseEmpty();
            }
        }

        public void RaiseString(string value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].RaiseString(value);
            }
            OnRaiseString?.Invoke(value);
            if (DefaultGameEventTOCall != null)
            {
                DefaultGameEventTOCall.RaiseEmpty();
            }
        }
        public void RaiseBool(bool value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].RaiseBool(value);
            }
            OnRaiseBool?.Invoke(value);
            if (DefaultGameEventTOCall != null)
            {
                DefaultGameEventTOCall.RaiseEmpty();
            }
        }
        public void RaiseGameObjectFloat(GameObject go, float respawnDelay)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].RaiseGameObjectFloat(go, respawnDelay);
            }
            OnSomeoneDied?.Invoke(go, respawnDelay);
            if (DefaultGameEventTOCall != null)
            {
                DefaultGameEventTOCall.RaiseEmpty();
            }
        }

        public void RegisterListener(GameEventListeners listener)
        {
            if (registeredListeners != null && !registeredListeners.Contains(listener.gameObject.name))
            {
                registeredListeners.Add(listener.gameObject.name);
            }
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }
        public void UnregisterListener(GameEventListeners listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
            //if (registeredListeners != null && registeredListeners.Contains(listener.gameObject.name))
            //{
            //    registeredListeners.Remove(listener.gameObject.name);
            //}
        }

    } 
}
