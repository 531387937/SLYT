using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSwitch : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            GetComponentInChildren<Cannon>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponentInChildren<Cannon>().enabled = false;
        }
    }
}
