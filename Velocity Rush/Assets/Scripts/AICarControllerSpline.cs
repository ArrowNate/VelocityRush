using BezierSolution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarControllerSpline : MonoBehaviour
{
    [SerializeField] private BezierSpline spline;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float distanceThreshold = 1f;

    private float t = 0f;

    void Update()
    {
        if (spline == null)
        {
            Debug.LogError("No spline assigned for AICarController");
            return;
        }

        MoveAlongSpline();
    }

    void MoveAlongSpline()
    {
        t += speed * Time.deltaTime / spline.length;

        if (t > 1f)
        {
            t = 1f;
        }

        Vector3 position = spline.GetPoint(t);
        transform.position = position;

        // Rotate towards the next point on the spline
        Quaternion targetRotation = Quaternion.LookRotation(spline.GetDirection(t));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Check if the car is close to the end of the spline
        if (t >= 1f && Vector3.Distance(transform.position, spline.GetPoint(0f)) < distanceThreshold)
        {
            t = 0f;
        }
    }
}