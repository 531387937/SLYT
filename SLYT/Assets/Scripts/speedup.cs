using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerCtr>().movespeed = 15;
            other.GetComponent<TrailRenderer>().material.SetColor("_MKGlowColor", Color.red);
            other.GetComponent<PlayerCtr>().speedup = true;

            Destroy(this.gameObject);


        }

    }

}
