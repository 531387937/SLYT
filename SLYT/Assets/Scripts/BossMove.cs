﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {
    public Transform[] trs;
    private bool move=false;
    private bool Touch=true;
    public static int pos = 0;
    public static int i = 0;
    // Use this for initialization
    void Awake()
    {
        if (i == 0)
        {
            PlayerPrefs.SetFloat("boss_x", transform.position.x);
            PlayerPrefs.SetFloat("boss_y", transform.position.y);
            i++;
        }
        else;
    }
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(PlayerPrefs.GetFloat("boss_x"), PlayerPrefs.GetFloat("boss_y"), 0);
    }
	
	// Update is called once per frame
	void Update () {
		if(move)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, trs[pos - 1].position, 5f*Time.deltaTime);
            if (gameObject.transform.position==trs[pos-1].position)
            {
                move = false;
                Touch = true;
                this.GetComponent<boss_shoot>().enabled = true;
            }
        }
       
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"&&Touch)
        {
            pos += 1;
            move = true;
            this.GetComponent<boss_shoot>().enabled = false;
            Touch = false;
        }
    }
}