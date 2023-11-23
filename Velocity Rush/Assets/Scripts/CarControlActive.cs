using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlActive : MonoBehaviour
{
    [SerializeField] private GameObject prometeoCarControl;
    [SerializeField] private GameObject aiCarControl;

    private void Start()
    {
        prometeoCarControl.GetComponent<PrometeoCarController>().enabled = true;
        aiCarControl.GetComponent<AICarControllerSpline>().enabled = true;
    }
}
