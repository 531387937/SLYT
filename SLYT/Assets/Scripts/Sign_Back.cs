using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign_Back : MonoBehaviour {
    public GameObject player;
    private void Awake()
    {
     
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="sign")
        {
            player.gameObject.SendMessage("back");
        }
    }
}
