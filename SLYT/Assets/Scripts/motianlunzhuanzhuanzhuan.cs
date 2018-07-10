using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motianlunzhuanzhuanzhuan : MonoBehaviour {

    public float rospeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, 0, rospeed * Time.deltaTime));
	}
}
