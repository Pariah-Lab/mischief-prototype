using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoverScript : MonoBehaviour
{

    public Rigidbody myRigidBody;
    public float movementSpeed;
    public bool ManualStart;
    public bool DualJoystic;
    public bool useRigidBody;
    public bool constantMovement;
    public bool repetitive;
    public bool swipeMovement;
    private bool changeDirection;

    public float swipeSensitivity;
    public Vector3 movementAxis;
    float nextChange;
    public float minMaxRepetitive;

    [Space(30)]

    public float swipeDeltaScaled;
    public float xSwipeMovement;

    void Start()
    {
       
        if (!constantMovement)
        {
            if (!swipeMovement)
            {
                LeanTouch.OnFingerUpdate += MoveHandler;
            }
            else
            {

                LeanTouch.OnFingerUpdate += SwipeMove;
            }
        }
        else
        {
            if (!ManualStart)
            {
                StartCoroutine(ConstantMovement()); 
            }
        }
    }
    public void StartScript()
    {
        StartCoroutine(ConstantMovement());
    }
    public IEnumerator ConstantMovement()
    {
        while (true)
        {
            if (!stop)
            {
                if (useRigidBody)
                {
                    myRigidBody.velocity = transform.forward * movementSpeed;
                }
                else
                {
                    if (repetitive)
                    {
                        if (changeDirection)
                        {
                            transform.localPosition += new Vector3(movementAxis.x, movementAxis.y, movementAxis.z) * movementSpeed * Time.deltaTime;
                            if (transform.localPosition.x >= minMaxRepetitive)
                            {
                                changeDirection = !changeDirection;
                            }
                        }
                        else
                        {
                            transform.localPosition -= new Vector3(movementAxis.x, movementAxis.y, movementAxis.z) * movementSpeed * Time.deltaTime;
                            if (transform.localPosition.x <= -minMaxRepetitive)
                            {
                                changeDirection = !changeDirection;
                            }
                        }
                    }
                    else
                    {
                        transform.position += movementAxis * (Time.deltaTime * movementSpeed);
                    }
                } 
            }
            yield return null;
        }
    }
    public void MoveHandler(LeanFinger obj)
    {
        if (!DualJoystic)
        {
            Move(obj);
        }
        else
        {
            if (obj.ScreenPosition.x < Screen.width / 2)
            {
                Move(obj);
            }
        }
    }
    public virtual void Move(LeanFinger obj)
    {
        Vector3 targetDirection = Vector3.ProjectOnPlane(transform.forward * obj.SwipeScaledDelta.y + transform.right * obj.SwipeScaledDelta.x, transform.up).FlattenedXY();
        if (useRigidBody)
        {
            myRigidBody.velocity = targetDirection * movementSpeed;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetDirection * movementSpeed, Time.deltaTime * 5f);
        }
    }
    public virtual void SwipeMove(LeanFinger obj)
    {
        Vector3 targetDirection = Vector3.ProjectOnPlane(transform.right * obj.SwipeScaledDelta.x, transform.up).FlattenedXY().normalized;
        if (useRigidBody)
        {
            xSwipeMovement += obj.ScaledDelta.x * swipeSensitivity;
            swipeDeltaScaled = obj.ScaledDelta.x;

            //vHandler.LateralVelocity(new Vector3(xSwipeMovement, 0, 0));
        }
        else
        {
            xSwipeMovement += obj.ScaledDelta.x * swipeSensitivity;
            swipeDeltaScaled = obj.ScaledDelta.x;
            transform.localPosition = new Vector3(xSwipeMovement, 0f, 0f);

        }
    }
    bool stop;
    public void Stop()
    {
        stop = true;
    }

    public void Go()
    {
        stop = false;
    }
    private void OnDisable()
    {
        if (swipeMovement)
        {
            LeanTouch.OnFingerUpdate -= SwipeMove;
        }
        else
        {

            LeanTouch.OnFingerUpdate -= MoveHandler;
        }
    }
}
