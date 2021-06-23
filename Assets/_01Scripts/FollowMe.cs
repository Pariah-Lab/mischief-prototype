using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour
{

    public Transform objectToFollow;
    public Vector3 folowAxes;
    public float smoothFollow;


    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(folowAxes.x * objectToFollow.position.x, folowAxes.y * objectToFollow.position.y, folowAxes.z * objectToFollow.position.z), Time.deltaTime * smoothFollow);    
    }
    [ContextMenu("Snap to position")]
    private void SnapToPlace()
    {
        transform.position = new Vector3(folowAxes.x * objectToFollow.position.x, folowAxes.y * objectToFollow.position.y, folowAxes.z * objectToFollow.position.z);
    }
}
