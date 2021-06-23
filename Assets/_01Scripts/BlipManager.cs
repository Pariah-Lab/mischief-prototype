using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlipManager : MonoBehaviour
{
    MeshRenderer meshRenderer;
    SkinnedMeshRenderer skinnedMeshRenderer;
    public Material blipToMat;
    [Header("Repeated blipping settings")]
    public float repeatedBlippingSpeed;
    [Header("Duration")]
    [Header("========================")]
    public float blipDuration;
    
    bool useMeshRenderer = false;
    bool useSkinnedMeshRenderer = false;
    private void Start()
    {
        if ((meshRenderer = GetComponent<MeshRenderer>())!= null)
        {
            useMeshRenderer = true;
            useSkinnedMeshRenderer = false;
        }
        else if ((skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>()) != null)
        {
            useMeshRenderer = false;
            useSkinnedMeshRenderer = true;
        }
        if (!useMeshRenderer && !useSkinnedMeshRenderer)
        {
            Debug.LogError($"No mesh renderer set on {gameObject.name}");
        }
    }
    [ContextMenu("Blip once")]
    public void ColorBlipOnce()
    {
        StartCoroutine(ColorBlipOnceRunner());
    }
    [ContextMenu("Blip repeadetly")]
    public void ColorBlippingRepeatedly()
    {
        StartCoroutine(ColorBlipRepeatedlyRunner());
    }
    IEnumerator ColorBlipOnceRunner()
    {
        Material startMat;
        if (useMeshRenderer)
        {
            startMat = new Material(meshRenderer.material);
        }
        else
        {
            startMat = new Material(skinnedMeshRenderer.material);
        }
        float counter = 0;
        while (counter <= blipDuration)
        {
            counter += Time.deltaTime;
            if (useMeshRenderer)
            {
                meshRenderer.material.Lerp(startMat, blipToMat, Utility.RemapValues(0f, blipDuration, 0f, 1f, counter)); 
            }
            else
            {
                skinnedMeshRenderer.material.Lerp(startMat, blipToMat, Utility.RemapValues(0f, blipDuration, 0f, 1f, counter));
            }
            yield return null;
        }
        while (counter >= 0)
        {
            counter -= Time.deltaTime;
            if (useMeshRenderer)
            {
                meshRenderer.material.Lerp(blipToMat, startMat, Utility.RemapValues(blipDuration, 0, 0f, 1f, counter)); 
            }
            else
            {
                skinnedMeshRenderer.material.Lerp(blipToMat, startMat, Utility.RemapValues(blipDuration, 0, 0f, 1f, counter));
            }
            yield return null;
        }
    }
    IEnumerator ColorBlipRepeatedlyRunner()
    {
        Material startMat;
        if (useMeshRenderer)
        {
            startMat = new Material(meshRenderer.material);
        }
        else
        {
            startMat = new Material(skinnedMeshRenderer.material);
        }
        float counter = 0;
        while (counter <= blipDuration)
        {
            counter += Time.deltaTime;
            if (useMeshRenderer)
            {
                meshRenderer.material.Lerp(startMat, blipToMat, Utility.RemapValues(-1, 1, 0f, 1f, Mathf.Sin(Time.time * repeatedBlippingSpeed))); 
            }
            else
            {
                meshRenderer.material.Lerp(startMat, blipToMat, Utility.RemapValues(-1, 1, 0f, 1f, Mathf.Sin(Time.time * repeatedBlippingSpeed)));
            }
            yield return null;
        }
        counter = 0;
        while (counter <= 0.5f)
        {
            counter += Time.deltaTime;
            if (useMeshRenderer)
            {
                meshRenderer.material.Lerp(blipToMat, startMat, Utility.RemapValues(0, 0.5f, 0f, 1f, counter)); 
            }
            else
            {
                meshRenderer.material.Lerp(blipToMat, startMat, Utility.RemapValues(0, 0.5f, 0f, 1f, counter)); 
            }
            yield return null;
        }
    }

}
