using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    public Vector3 vec;
    private Vector3 target1;
    private Vector3 target2;
    private bool go = true;
    private float TimeCount = 0;
    public bool tar1 = false;
    public bool tar2 = true;
    public float moveSpeed;
    public float waitTime;
    // Use this for initialization
    void Start () {
        target1 = transform.position - vec;
        target2 = transform.position + vec;
	}
	
	// Update is called once per frame
	void Update () {
        if (go)
        {
            if (!tar1)
            {
                transform.position = Vector3.MoveTowards(transform.position, target1, moveSpeed * Time.deltaTime);
            }
            if (!tar2)
            {
                transform.position = Vector3.MoveTowards(transform.position, target2, moveSpeed * Time.deltaTime);
            }
        }
        if (transform.position==target1)
        {
            tar1 = true;
            tar2 = false;
            go = false;
        }
        if (transform.position == target2)
        {
            tar1 = false;
            tar2 = true;
            go = false;
        }
        if(!go)
        {
            TimeCount += Time.deltaTime;
            if(TimeCount>=waitTime)
            {
                TimeCount = 0;
                go = true;
            }
        }
    }
}
