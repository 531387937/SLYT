using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bianse1 : MonoBehaviour {
    public GameObject player;
    bool faf = false;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(this.transform.position, player.transform.position)<2f)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_MKGlowColor", Color.yellow);
            faf = true;
        }
        else if(faf)
        {
            StartCoroutine(yanchi());
        }





	}
    //private void OnCollisionEnter(Collision player)
    //{
    //   if(player.gameObject.tag=="Player")
    //    {
    //        this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_MKGlowColor",Color.yellow);
    //    }


    //}
    //private void OnCollisionExit(Collision player)
    //{
    //    if (player.gameObject.tag == "Player")
    //    {
    //        StartCoroutine(yanchi());
            
    //    }
    //}
    IEnumerator yanchi()
    {
        yield return new WaitForSeconds(0.6f);
        this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_MKGlowColor", new Color(0, 0.65f, 1, 1));
        faf = false;
        yield break;
    }
}
