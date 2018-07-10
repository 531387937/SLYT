using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent_set : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        collision.gameObject.transform.SetParent(this.gameObject.transform);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        { collision.gameObject.transform.SetParent(null);
            collision.gameObject.transform.eulerAngles = Vector3.zero;
        }
    }
}
