using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGround : MonoBehaviour {
    public GameObject ground;
    private BoxCollider col;
    private MeshRenderer me;
	// Use this for initialization
	void Start () {
        col = ground.GetComponent<BoxCollider>();
        me = ground.GetComponent<MeshRenderer>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "switch")
        {
            col.isTrigger = false;
            me.enabled = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "switch")
        {
            col.isTrigger = true;
            me.enabled = false;
        }
    }
}
