using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGround : MonoBehaviour {
    public GameObject ground;
    private BoxCollider col;
	// Use this for initialization
	void Start () {
        col = ground.GetComponent<BoxCollider>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "switch")
        {
            col.isTrigger = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "switch")
        {
            col.isTrigger = true;
        }
    }
}
