using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfLapTrigger : MonoBehaviour
{
    [SerializeField] private GameObject lapCompleteTrigger;
    [SerializeField] private GameObject halfLapTrigger;

    private void OnTriggerEnter(Collider other)
    {
        lapCompleteTrigger.SetActive(true);
        halfLapTrigger.SetActive(false);
    }
}