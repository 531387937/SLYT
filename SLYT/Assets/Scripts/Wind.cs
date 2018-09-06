using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {
    public float windPower;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        other.GetComponent<Rigidbody>().AddForce(Vector3.up* windPower/(other.transform.position.y-transform.position.y), ForceMode.Acceleration);
    }
}
