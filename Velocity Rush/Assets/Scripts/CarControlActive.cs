using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlActive : MonoBehaviour
{
    [SerializeField] private GameObject prometeoCarControl;

    private void Update()
    {
        /*PrometeoCarController controller = GetComponent<PrometeoCarController>();*/
        prometeoCarControl.GetComponent<PrometeoCarController>().enabled = true;
    }
}
