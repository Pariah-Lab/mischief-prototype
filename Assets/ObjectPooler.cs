using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;

namespace GameLogic
{
    public class ObjectPooler : MonoBehaviour, IPooler
    {
        public List<PoolObjectHolder> poolObjects = new List<PoolObjectHolder>();
        public GameParticlesHolder gameParticles;
        public static ObjectPooler _aIns {get; private set;}

        private void Awake()
        {
            _aIns = this;
        }
        public bool useCUbe;
        private void Start()
        {
            for (int j = 0; j < gameParticles.particles.Count; j++)
            {
                bool contains = false;
                for (int z = 0; z < poolObjects.Count; z++)
                {
                    if (poolObjects[z].prefab == gameParticles.particles[j])
                    {
                        contains = true;
                    }
                }
                    if (!contains)
                    {
                        PoolObjectHolder poh = new PoolObjectHolder();
                        poh.maxCount = 10;
                        poh.prefab = gameParticles.particles[j];
                        poolObjects.Add(poh);
                    }
            }
            for (int i = 0; i < poolObjects.Count; i++)
            {
                poolObjects[i].Initialize();
            }
            List<IReferenceInjector<IPooler>> poolers = FindObjectsOfType<MonoBehaviour>().OfType<IReferenceInjector<IPooler>>().ToList<IReferenceInjector<IPooler>>();
            foreach (var pool in poolers)
            {
                pool.SetMeUp(this);
            }
        }

        /// <summary>
        /// pool index 
        /// 0 - Tap Bomb
        /// 1 - Hold Bomb
        /// </summary>    
        public GameObject GetObjectFromPool(int objectIndex)
        {
            if (objectIndex <= poolObjects.Count - 1)
            {
                return poolObjects[objectIndex].GetPooledObject(); 
            }
            else
            {
                return poolObjects[0].GetPooledObject();
            }
        }

    }
    [System.Serializable]
    public class PoolObjectHolder
    {
        // public AssetReference myObject;
        public GameObject prefab;
        private List<GameObject> pooledObjects = new List<GameObject>();
        private Queue<GameObject> requestPooedObject = new Queue<GameObject>();
        public int maxCount;
        public int counter;

        bool initialized = false;

        private void AddTOPool(GameObject poolPrefab)
        {
            // poolPrefab.SetActive(false);
            pooledObjects.Add(poolPrefab);
        }
        public void Initialize()
        {
            if (!initialized)
            {
                initialized = true;
                for (int i = 0; i < maxCount; i++)
                {
                    GameObject tmp = MonoBehaviour.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
                    tmp.SetActive(false);
                    AddTOPool(tmp);
                }
            }
        }
        public void RequestOneObject(ref GameObject assignor)
        {
            requestPooedObject.Enqueue(assignor);
            for (int i = 0; i < requestPooedObject.Count; i++)
            {
                assignor = GetPooledObject();
            }
        }
        public GameObject GetPooledObject()
        {
            counter++;
            if (counter > pooledObjects.Count - 1)
            {
                counter = 0;
            }
            return pooledObjects[counter];
        }
    }
    

    public interface IPooler
    {
        GameObject GetObjectFromPool(int objectIndex);
    }
}