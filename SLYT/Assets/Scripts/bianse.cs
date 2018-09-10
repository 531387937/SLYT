using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bianse : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision player)
    {
       if(player.gameObject.tag=="Player")
        {
            this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_MKGlowColor",Color.yellow);
        }


    }
    private void OnCollisionExit(Collision player)
    {
        if (player.gameObject.tag == "Player")
        {
            StartCoroutine(yanchi());
            
        }
    }
    IEnumerator yanchi()
    {
        yield return new WaitForSeconds(0.6f);
        this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_MKGlowColor", new Color(0, 0.65f, 1, 1));
        yield break;
    }
}
