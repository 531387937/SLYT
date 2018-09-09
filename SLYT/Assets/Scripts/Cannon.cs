using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    public GameObject Player;
    public float moveSpeed;
    public float shoot_time;
    private float timer=0;
    public GameObject Shell;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Player.transform.position.x, this.transform.position.y, 0), moveSpeed*Time.deltaTime);
        if(timer<shoot_time)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(Shell,this.transform.position,Shell.transform.rotation,null);
            timer = 0;
        }
	}
}
