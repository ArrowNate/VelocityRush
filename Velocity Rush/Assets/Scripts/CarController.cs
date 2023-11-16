using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float accelerationForce = 20f;
    [SerializeField] private float steeringForce = 5f;
    [SerializeField] private float brakingForce = 10f;
    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        // Get player input
        float acceleration = Input.GetAxis("Vertical");
        float steering = Input.GetAxis("Horizontal");

        // Apply acceleration
        Accelerate(acceleration);

        // Apply steering
        Steer(steering);

        // Apply braking
        if (Input.GetKey(KeyCode.Space))
        {
            Brake();
        }
    }

    private void Accelerate(float accelerationInput)
    {
        // Use rigidbody velocity for more realistic acceleration
        Vector3 force = transform.forward * accelerationInput * accelerationForce;
        GetComponent<Rigidbody>().AddForce(force);

        Debug.Log("Acceleration: " + accelerationInput);
    }

    private void Steer(float steeringInput)
    {
        // Use rigidbody torque for steering
        Vector3 torque = Vector3.up * steeringInput * steeringForce;
        GetComponent<Rigidbody>().AddTorque(torque);

        Debug.Log("Steering: " + steeringInput);
    }

    private void Brake()
    {
        // Apply braking force to slow down the car
        GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity.normalized * brakingForce);

        Debug.Log("Braking");
    }
}
