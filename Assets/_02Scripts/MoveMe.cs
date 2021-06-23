using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveMe : MonoBehaviour
{

    public Rigidbody myRigidBody;
    public float movementSpeed;
    public bool DualJoystic;
    public bool useRigidBody;

    void Start()
    {
        LeanTouch.OnFingerUpdate += MoveHandler;
    }

    
    public void MoveHandler(LeanFinger obj)
    {
        if (!DualJoystic)
        {
            Move(obj);
        }
        else
        {
            if (obj.ScreenPosition.x < Screen.width/2)
            {
                Move(obj);
            }
        }
    }
    public virtual void Move(LeanFinger obj)
    {
        //Vector3 targetDirection = Vector3.ProjectOnPlane(transform.forward * obj.SwipeScaledDelta.y + transform.right * obj.SwipeScaledDelta.x, transform.up).normalized;
        if (useRigidBody)
        {
            Vector3 targetDirection = (transform.forward * obj.ScaledDelta.y + transform.right * obj.ScaledDelta.x);
            targetDirection = Vector3.ProjectOnPlane(targetDirection, transform.up);
            myRigidBody.velocity = targetDirection * movementSpeed;
            myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, movementSpeed);

        }
        else
        {
            Vector3 targetDirection = (transform.forward * obj.ScaledDelta.y + transform.right * obj.ScaledDelta.x);
            targetDirection = Vector3.ProjectOnPlane(targetDirection, transform.up);

            transform.position += targetDirection.normalized * 0.5f;

            transform.forward = Vector3.Lerp(transform.forward, targetDirection.normalized, Time.deltaTime * 8f);
            Debug.DrawRay(transform.position, (transform.position + targetDirection) * 15f, Color.black, 1f);
        }
    }
    private void OnDisable()
    {
        LeanTouch.OnFingerUpdate -= MoveHandler;
    }
}
