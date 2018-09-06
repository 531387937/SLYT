using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindLeft : MonoBehaviour {
    public float windPower;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<Rigidbody>().AddForce(Vector3.right * windPower / (other.transform.position.x - transform.position.x), ForceMode.Acceleration);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<Rigidbody>().AddForce(Vector3.right * windPower / (other.transform.position.x - transform.position.x), ForceMode.Acceleration);
    }
}

