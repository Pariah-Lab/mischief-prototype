using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class RotateMe : MonoBehaviour
{
    private Vector3 rotationAxis;
    public bool invertAxis;
    [SerializeField] Directions myDirection;
    public float rotationSpeed;
    public bool rotateContinuously;

    public bool DualJoystic;
    public bool rotationRecenter;

    private enum Directions
    {
        X,
        Y,
        Z
    }

    void Start()
    {

        switch (myDirection)
        {
            case Directions.X:
                rotationAxis = new Vector3(1, 0, 0);
                break;
            case Directions.Y:
                rotationAxis = new Vector3(0, 1, 0);
                break;
            case Directions.Z:
                rotationAxis = new Vector3(0, 0, 1);
                break;
            default:
                break;
        }
        if (!rotateContinuously)
        {
            LeanTouch.OnFingerUpdate += RotateCam;
            if (rotationRecenter)
            {
                StartCoroutine(RotationRecenter());
            }
        }
        else
        {
            StartCoroutine(RotateFOrever());
        }

    }
    
    public IEnumerator RotationRecenter()
    {
        while (true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 8f);
            yield return null;
        }
    }
    public IEnumerator RotateFOrever()
    {
        while (true)
        {

            transform.Rotate(rotationAxis, Time.deltaTime * rotationSpeed);
            yield return null;
        }
    }
    public void RotateCam(LeanFinger obj)
    {
        if (!DualJoystic)
        {
            //transform.Rotate(rotationAxis, AxisHandler(myDirection, obj.ScaledDelta));
            transform.forward = Vector3.Lerp(transform.forward, new Vector3(obj.ScaledDelta.x, 0f, obj.ScaledDelta.y), Time.deltaTime * 2f);

        }
        else
        {
            if (obj.ScreenPosition.x < Screen.width / 2)
            {
                //transform.forward = Vector3.Lerp(transform.forward, new Vector3(obj.ScaledDelta.x, 0f, obj.ScaledDelta.y), Time.deltaTime * 2f);
                Vector3 targetDirection = (transform.forward * obj.ScaledDelta.y + transform.right * obj.ScaledDelta.x);
                targetDirection = Vector3.ProjectOnPlane(targetDirection, transform.up);

                transform.position = Vector3.Lerp(transform.position, targetDirection.normalized * 8f, Time.deltaTime * 4f);
                
                transform.forward = Vector3.Lerp(transform.forward, targetDirection.normalized, Time.deltaTime * 8f);
                Debug.DrawRay(transform.position, (transform.position + targetDirection )* 15f, Color.black, 1f);
            }
        }
    }
    private float AxisHandler(Directions mydirection, Vector2 inputAxis)
    {
        float axisRotationAmount = 0;
        if (!invertAxis)
        {
            switch (mydirection)
            {
                case Directions.X:
                    axisRotationAmount = -inputAxis.y;
                    break;
                case Directions.Y:
                    axisRotationAmount = inputAxis.x;
                    break;
                case Directions.Z:
                    axisRotationAmount = inputAxis.x;
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (mydirection)
            {
                case Directions.X:
                    axisRotationAmount = inputAxis.y;
                    break;
                case Directions.Y:
                    axisRotationAmount = inputAxis.x;
                    break;
                case Directions.Z:
                    axisRotationAmount = inputAxis.x;
                    break;
                default:
                    break;
            }
        }
        return axisRotationAmount;
    }
    private void OnDisable()
    {
        LeanTouch.OnFingerUpdate -= RotateCam;
    }
}
