using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear : MonoBehaviour {
    private float zero;
	// Use this for initialization
	void Start () {
        zero = 0;
	}
	
	// Update is called once per frame
	void Update () {
        zero += Time.deltaTime;
        if(zero>10)
        {
            Destroy(this.gameObject);
        }
	}
}
