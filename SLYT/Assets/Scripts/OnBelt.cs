using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBelt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "Conveyor belt")
        {
            this.gameObject.GetComponent<PlayerCtr>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Conveyor belt")
        {
            this.gameObject.GetComponent<PlayerCtr>().enabled = true;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
