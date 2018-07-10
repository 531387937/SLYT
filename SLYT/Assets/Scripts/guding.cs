using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guding : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - 1);
	}
}
