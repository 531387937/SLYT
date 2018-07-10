using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creat_Self : MonoBehaviour {
    public GameObject creat;
    private float timer=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timer<3)
        {
            timer += Time.deltaTime;
        }
        if(timer>3)
        {
            Instantiate(creat, this.transform.position,this.transform.rotation);
            timer = 0;
        }
	}
}
