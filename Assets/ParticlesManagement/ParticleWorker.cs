using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic;

public class ParticleWorker : MonoBehaviour
{
    public List<string> ParticlesList;
    public int selectedid;
    public string selectedName;

    public void PlayParticle()
    {
        GameObject tmp = ObjectPooler._aIns.GetObjectFromPool(selectedid);
        tmp.SetActive(true);
        tmp.transform.rotation = transform.rotation;
        tmp.transform.position = transform.position;

        tmp.GetComponent<ParticleSystem>().Emit(10);
    }
}
