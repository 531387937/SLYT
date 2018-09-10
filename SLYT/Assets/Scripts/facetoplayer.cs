using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facetoplayer : MonoBehaviour {
    public GameObject player;
    Quaternion target;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
        if(player.transform.position.x>this.transform.position.x)
        {
            target = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            target = Quaternion.Euler(new Vector3(0, 105, 0));
        }
        this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation, target, 0.05f);
	}
}
