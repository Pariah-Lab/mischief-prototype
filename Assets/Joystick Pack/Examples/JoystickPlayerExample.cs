using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        transform.Rotate(transform.up, variableJoystick.Horizontal * Time.deltaTime * 88f);
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rb.velocity = transform.forward * ( variableJoystick.Vertical * speed * Time.fixedDeltaTime); 
        //rb.velocity = (rb.transform.forward * variableJoystick.Vertical + rb.transform.right * variableJoystick.Horizontal).normalized * speed * Time.fixedDeltaTime;
        //transform.forward = rb.velocity;
        //rb.velocity = Vector3.ProjectOnPlane(direction, Vector3.down) * speed * Time.fixedDeltaTime;
        //transform.forward = rb.velocity;
    }
}