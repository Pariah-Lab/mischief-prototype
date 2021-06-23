using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class RotatorScript : MonoBehaviour
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
            transform.Rotate(rotationAxis, AxisHandler(myDirection, obj.ScaledDelta));
        }
        else
        {
            if (obj.ScreenPosition.x > Screen.width / 2)
            {
                transform.Rotate(rotationAxis, AxisHandler(myDirection, obj.ScaledDelta));
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
