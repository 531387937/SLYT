using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign_Back : MonoBehaviour {
    public GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sign")
        {
            player.gameObject.SendMessage("back");
        }
    }
}
