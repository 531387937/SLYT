using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bianse : MonoBehaviour {
    Color ccc;

	// Use this for initialization
	void Start () {
        ccc = this.gameObject.GetComponent<MeshRenderer>().material.GetColor("_MKGlowColor");
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
    //new Color(0, 0.65f, 1, 1)
    IEnumerator yanchi()
    {
        yield return new WaitForSeconds(0.6f);
        this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_MKGlowColor", ccc);
        yield break;
    }
}
