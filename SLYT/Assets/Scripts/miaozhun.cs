using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miaozhun : MonoBehaviour {
    public GameObject player;
    public GameObject boss;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("boss");
	}
	
	// Update is called once per frame
	void Update () {
        float z = boss.GetComponent<boss_shoot>().z;
        this.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x)/2, (player.transform.position.y + boss.transform.position.y)/2, 0);
        this.transform.localScale = new Vector3(this.transform.localScale.x, Vector3.Distance(player.transform.position, boss.transform.position) / 2, this.transform.localScale.z);
        this.transform.localRotation =Quaternion.Euler(new Vector3(0, 0, z+ 180));
	}
}
