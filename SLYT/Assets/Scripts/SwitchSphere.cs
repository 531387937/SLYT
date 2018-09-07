using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSphere : MonoBehaviour {
    public float speed;
    private bool go = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(go)
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            go = true;
        }
    }
}
