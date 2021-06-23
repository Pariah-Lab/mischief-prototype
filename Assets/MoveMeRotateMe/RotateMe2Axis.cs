using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.SocialPlatforms;

public class RotateMe2Axis : MonoBehaviour
{
    public bool onOff;
    public bool invertAxis;
    float xRot, yRot;
    public bool DualJoystic;
    public float rotationSmooth;
    [Range(0f, 5f)]
    public float rotationSensitivity;


    private enum Directions
    {
        X,
        Y,
        Z
    }
    public void TurnOn()
    {
        onOff = true;
    }
    void Start()
    {

        LeanTouch.OnFingerUpdate += RotateCam;
    }
    public void RotateCam(LeanFinger obj)
    {
        if (!onOff) return;

        if (!DualJoystic)
        {
            HandleRotation(obj);
        }
        else
        {
            if (obj.ScreenPosition.x > Screen.width / 2)
            {
                HandleRotation(obj);
            }
        }
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerUpdate -= RotateCam;
    }

    public void HandleRotation(LeanFinger obj)
    {
        if (invertAxis)
        {
            xRot = Mathf.Lerp(xRot, obj.ScaledDelta.y * rotationSensitivity, Time.deltaTime * rotationSmooth);
        }
        else
        {
            xRot = Mathf.Lerp(xRot, obj.ScaledDelta.y * -rotationSensitivity, Time.deltaTime * rotationSmooth);
        }
        yRot = Mathf.Lerp(yRot, obj.ScaledDelta.x * rotationSensitivity, Time.deltaTime * rotationSmooth);
        // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x + xRot, transform.rotation.eulerAngles.y + yRot, 0f), Time.deltaTime * rotationSmooth);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + xRot, transform.rotation.eulerAngles.y + yRot, 0f);
    }
}
