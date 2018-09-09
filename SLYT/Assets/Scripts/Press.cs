using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour {
    public GameObject trap;
    public float trapSpeed;
    public float backSpeed;
    [SerializeField]
    private bool canPress;
    public float DownTime;
    [SerializeField]
    private float timer = 0;
    private bool press = false;
	// Use this for initialization
	void Start () {
        canPress = true;
	}
    private void Update()
    {
        if(press)
        {
            timer += Time.deltaTime;
            if (timer < DownTime)
            {
                trap.transform.Translate(Vector3.down * trapSpeed * Time.deltaTime);
            }
            else
            {
                canPress = false;
                press = false;
                timer = 0;
            }
        }
        if(!canPress)
        {
            timer += Time.deltaTime;
            if (timer < DownTime * trapSpeed / backSpeed)
            {
                trap.transform.Translate(Vector3.up * backSpeed * Time.deltaTime);
            }
            else
            {
                timer = 0;
                canPress = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if((other.tag=="Player"||other.tag=="Shell")&&canPress)
        {
            press = true;           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Shell") && canPress)
        {
            press = true;
        }
    }
}
