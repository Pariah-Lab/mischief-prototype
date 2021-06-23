using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSystem;
using System.Linq;


namespace GameLogic
{
    public class GameInitializer : MonoBehaviour
    {
        public List<GameObject> gameLogic;
        public GameEvent OnGameInitialized;
        IInitializable[] sorted;
        int counter = -1;
        void Start()
        {
            InitializeGame();
        }
        void InitializeGame()
        {
            IInitializable[] initializables = FindObjectsOfType<MonoBehaviour>().OfType<IInitializable>().ToArray<IInitializable>();
            sorted = initializables.OrderBy(x => x.InitOrder).ToArray<IInitializable>();
            InitializerCall();
            for (int i = 0; i < gameLogic.Count; i++)
            {
                Instantiate(gameLogic[i], new Vector3(0, -500f, 0), Quaternion.identity);
            }
            //OnGameInitialized.RaiseEmpty();
        }
        private void InitializerCall()
        {
            counter++;
            if (counter < sorted.Length)
            {
                Debug.Log($"Initialized {counter}");
                sorted[counter].OnInitialized(() => { InitializerCall(); });
            }
            else
            {
                OnGameInitialized.RaiseEmpty();
            }
        }
    }
}
