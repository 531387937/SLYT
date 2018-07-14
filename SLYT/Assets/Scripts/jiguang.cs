using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jiguang : MonoBehaviour {
    public Transform jiguang1;
    public Transform jiguang2;
    public GameObject player;
    float jiange = 0.7f;
    float tttttt;
    Color intitc;
    Vector3 pos;
    public AudioSource rua;
    bool fashe = false;
    // Use this for initialization
    private void Awake()
    {
        jiguang1 = this.gameObject.transform.GetChild(0);
        jiguang2 = this.gameObject.transform.GetChild(1);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start () {
        Color intitc = this.GetComponentInChildren<MeshRenderer>().material.GetColor("_MKGlowColor");
        pos = jiguang2.localPosition;
        jiguang1.localScale = new Vector3(0f, 0, 0);
        jiguang1.localPosition = new Vector3(0, 0, 0);
        jiguang2.localScale = new Vector3(0, 0, 0);
        jiguang2.localPosition = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x>this.transform.position.x)
        {
            
            fashe = true;

        }
        else
        {
            if (tttttt > jiange * 3)
            {
                tttttt = 0;
                fashe = false;
            }


        }
        if(fashe)
        {rua.Play();
            tttttt += Time.deltaTime;
            if (tttttt > jiange && tttttt < jiange * 2)
            {
                shoot();

            }
            else if (tttttt > jiange * 2)
            {
                stop();

                if (this.GetComponentInChildren<MeshRenderer>().material.GetColor("_MKGlowColor") != intitc)
                {

                    this.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowColor", intitc);

                }
            }
            else if (tttttt < jiange)
            {
                yujing();
            }

        }


    }
    void yujing()
    {
        Color c = Color.white;
        if (this.GetComponentInChildren<MeshRenderer>().material.GetColor("_MKGlowColor") != c)
            this.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowColor", c);
        else this.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowColor", intitc);

    }
    void shoot()
    {
        jiguang1.localScale = new Vector3(0.5f, 10, 0.5f);
        jiguang1.localPosition = new Vector3(0, 10, 0);
        jiguang2.localScale = new Vector3(0.5f, 10, 0.5f);
        jiguang2.localPosition = pos;
    }
    void stop()
    {
        jiguang1.localScale = new Vector3(0f, 0, 0);
        jiguang1.localPosition = new Vector3(0, 0, 0);
        jiguang2.localScale = new Vector3(0, 0, 0);
        jiguang2.localPosition = new Vector3(0, 0, 0);
    }
}
